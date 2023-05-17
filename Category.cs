using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSCS
{
    public class Category
    {
        public Hashtable MainCategory = new Hashtable();
        public Hashtable Subdivision = new Hashtable();

        public Category() { 
            HashSet<string> SchoolCategories = new HashSet<string>();
            SchoolCategories.Add("학사일정");
            SchoolCategories.Add("과제");
            SchoolCategories.Add("퀴즈");
            SchoolCategories.Add("온라인 강의");
            HashSet<string> PersonalCategories = new HashSet<string>();
            PersonalCategories.Add("생일");
            PersonalCategories.Add("약속");
            PersonalCategories.Add("식사");
            HashSet<string> EtcCatergories = new HashSet<string>();
            EtcCatergories.Add("기타1");
            EtcCatergories.Add("기타2");
            EtcCatergories.Add("기타3");

            MainCategory["ShcoolCategory"] = SchoolCategories;
            MainCategory["PersonalCategory"] = PersonalCategories;
            MainCategory["EtcCategory"] = EtcCatergories;

            Subdivision["학사일정"] = "ShcoolCategory";
            Subdivision["과제"] = "ShcoolCategory";
            Subdivision["퀴즈"] = "ShcoolCategory";
            Subdivision["온라인 강의"] = "ShcoolCategory";

            Subdivision["생일"] = "PersonalCategory";
            Subdivision["약속"] = "PersonalCategory";
            Subdivision["식사"] = "PersonalCategory";

            Subdivision["기타1"] = "EtcCategory";
            Subdivision["기타2"] = "EtcCategory";
            Subdivision["기타3"] = "EtcCategory";

        }
        public void AddSubdivision(string Main, string Sub)
        {
            HashSet<string> SubdivisionSet = MainCategory[Main] as HashSet<string>;
            SubdivisionSet.Add(Sub);
            MainCategory[Main] = SubdivisionSet;
            Subdivision[Sub] = Main;
        }

        public HashSet<string> GetSubdivisionSetByMainCategory(string Main)
        {
            return MainCategory[Main] as HashSet<string>;
        }

        public string GetMainCategoryBySubdivision(string Sub)
        {
            return Subdivision[Sub] as string;
        }

        public void ChangeSubdivision(string NewMain, string Sub)
        {
            string sourcsMain = Subdivision[Sub] as string;
            //기존 main에서 sub 제거
            HashSet<string> deleteSubformSourceMain = MainCategory[sourcsMain] as HashSet<string>;
            deleteSubformSourceMain.Remove(Sub);
            MainCategory[sourcsMain] = deleteSubformSourceMain;
            //sub에 대한 main 변경
            Subdivision[Sub] = NewMain;
            //새로운 main에 sub 추가
            HashSet<string> AddSubIntoNewMain = MainCategory[NewMain] as HashSet<string>;
            AddSubIntoNewMain.Add(Sub);
            MainCategory[NewMain] = AddSubIntoNewMain;
        }
    }
}
