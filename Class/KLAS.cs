using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static KSCS.Class.KSCS_static;

namespace KSCS.Class
{
    public class KLAS
    {
        public static Dictionary<string, string> KLAS_URL = new Dictionary<string, string>
            {
                { "LoginSecurity", "https://klas.kw.ac.kr/usr/cmn/login/LoginSecurity.do" },
                { "LoginConfirm","https://klas.kw.ac.kr/usr/cmn/login/LoginConfirm.do" },
                { "StdHome","https://klas.kw.ac.kr/std/cmn/frame/StdHome.do" },
                { "OnlineStdList","https://klas.kw.ac.kr/std/lis/evltn/SelectOnlineCntntsStdList.do" },
                { "TaskStdList","https://klas.kw.ac.kr/std/lis/evltn/TaskStdList.do" },
                { "PrjctStdList","https://klas.kw.ac.kr/std/lis/evltn/PrjctStdList.do"},
                { "QuizStdList","https://klas.kw.ac.kr/std/lis/evltn/AnytmQuizStdList.do" }
            };
        public static Dictionary<string, string> klasMagamNames = new Dictionary<string, string>()
        {
            { "Task","과제" },
            { "Quiz","퀴즈" },
            { "Online","강의" },
            { "Prjct","팀플" }
        };
        public static Dictionary<string, string> KLAS_LECTURE_NUM = new Dictionary<string, string>();
        public static HttpClientHandler httpClientHandler;
        public static HttpClient httpClient;
        public static CookieContainer cookieContainer;

        public static void ClearKlasSchedule()
        {
            KlasSchedule["Task"].Clear();
            KlasSchedule["Quiz"].Clear();
            KlasSchedule["Online"].Clear();
            KlasSchedule["Prjct"].Clear();
            KlasSchedule["Personal"].Clear();
        }

        public static void initializeKLAS()
        {
            cookieContainer = new CookieContainer();
            httpClientHandler = new HttpClientHandler()
            {
                UseProxy = true,
                UseCookies = true,
                UseDefaultCredentials = true,
                PreAuthenticate = true
            };

            httpClientHandler.CookieContainer = cookieContainer;
            httpClient = new HttpClient(httpClientHandler)
            {
                Timeout = TimeSpan.FromSeconds(30),
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36 Edge/16.16299");
        }



        //KLAS 로그인 함수
        public static async Task<bool> LoginKLAS(string ID, string PW)
        {
            string publicKeyJson = await CreateRequestAsync("LoginSecurity", "POST", "{}"); //klas 공개키 얻어오기
            if (string.IsNullOrEmpty(publicKeyJson)) //네트워크 비정상 상태 로그인 불가능
                return false;

            JObject security = JObject.Parse(publicKeyJson);
            byte[] publicKeyBytes = Convert.FromBase64String(security["publicKey"].ToString());
            AsymmetricKeyParameter publicKey = PublicKeyFactory.CreateKey(publicKeyBytes);
            var loginJson = JsonConvert.SerializeObject(new
            {
                loginId = ID,
                loginPwd = PW,
                storeIdYn = "N"
            });

            //로그인 데이터 암호화
            IBufferedCipher cipher = CipherUtilities.GetCipher("RSA/None/PKCS1Padding");
            cipher.Init(true, publicKey);
            byte[] encryptedBytes = cipher.DoFinal(Encoding.UTF8.GetBytes(loginJson));
            string loginToken = JsonConvert.SerializeObject(new
            {
                loginToken = Convert.ToBase64String(encryptedBytes),
                redirectUrl = "",
                redirectTabUrl = ""
            });
            string result = await CreateRequestAsync("LoginConfirm", "POST", loginToken);
            if (string.IsNullOrEmpty(result)) return false;

            JObject loginResult = JObject.Parse(result);
            if (int.Parse(loginResult["errorCount"].ToString()) > 0)//로그인에 에러가 있을 경우
            {
                MessageBox.Show(loginResult["fieldErrors"][0]["message"].ToString());
                return false;
            }
            stdNum = ID;
            return true;
        }

        //KLAS 사이트로 HTTP 요청하는 함수
        public static async Task<string> CreateRequestAsync(string urlName, string type, string data)
        {
            HttpRequestMessage request;
            switch (type)
            {
                case "POST":
                    request = new HttpRequestMessage(HttpMethod.Post, KLAS_URL[urlName]) { Content = new StringContent(data, Encoding.UTF8, "application/json") };
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    string responseBody;
                    if (response.IsSuccessStatusCode)
                        responseBody = await response.Content.ReadAsStringAsync();
                    else
                    {
                        MessageBox.Show("네트워크 오류입니다.");
                        responseBody = "";
                    }
                    return responseBody;
                case "GET":
                    request = new HttpRequestMessage(HttpMethod.Get, KLAS_URL[urlName]);

                    break;
            }
            return "";
        }

        public static async Task LoadMagamData()
        {
            ClearKlasSchedule();
            string list = await CreateRequestAsync("StdHome", "POST", "{\"searchYearhakgi\":\"2023,1\"}");
            JObject sbjectList = JObject.Parse(list);
            foreach (JToken subj in sbjectList["atnlcSbjectList"])
            {
                KLAS_LECTURE_NUM.Add(subj["subjNm"].ToString(), subj["subj"].ToString());
                var magamContent = new
                {
                    selectSubj = subj["subj"].ToString(),
                    selectYearhakgi = "2023,1",
                    selectChangeYn = "Y"
                };
                Schedule schedule;
                string taskData = await CreateRequestAsync("TaskStdList", "POST", JsonConvert.SerializeObject(magamContent));
                foreach (JToken task in JArray.Parse(taskData))
                {
                    schedule = Schedule.KLAS_Schedule(task["title"].ToString(), "Task", subj["subjNm"].ToString(), task["expiredate"].ToString());
                    if (schedule.MagamBeforeNow() && string.Equals(task["submityn"].ToString(),"N")) KlasSchedule["Task"].Add(schedule);
                }
                string quizData = await CreateRequestAsync("QuizStdList", "POST", JsonConvert.SerializeObject(magamContent));
                foreach (JToken quiz in JArray.Parse(quizData))
                {
                    schedule = Schedule.KLAS_Schedule(quiz["papernm"].ToString(), "Quiz", subj["subjNm"].ToString(), quiz["edt"].ToString());
                    if (schedule.MagamBeforeNow() && string.Equals(quiz["issubmit"].ToString(),"N")) KlasSchedule["Quiz"].Add(schedule);
                }
                string onlineData = await CreateRequestAsync("OnlineStdList", "POST", JsonConvert.SerializeObject(magamContent));
                foreach (JToken online in JArray.Parse(onlineData))
                {
                    schedule = Schedule.KLAS_Schedule(online["moduletitle"].ToString(), "Online", subj["subjNm"].ToString(), online["endDate"].ToString());
                    if (schedule.MagamBeforeNow() && string.Equals(online["ispreview"]?.ToString(),"N")) KlasSchedule["Online"].Add(schedule);
                }
                string prjctData = await CreateRequestAsync("PrjctStdList", "POST", JsonConvert.SerializeObject(magamContent));
                foreach (JToken prjct in JArray.Parse(prjctData))
                {
                    schedule = Schedule.KLAS_Schedule(prjct["title"].ToString(), "Prjct", subj["subjNm"].ToString(), prjct["expiredate"].ToString());
                    if (schedule.MagamBeforeNow() && string.Equals(prjct["submityn"].ToString(), "N")) KlasSchedule["Prjct"].Add(schedule);
                }
            }
        }
    }
}
