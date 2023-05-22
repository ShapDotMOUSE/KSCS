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
        public Dictionary<string, HashSet<string>> Categorys = new Dictionary<string, HashSet<string>>();
        public Hashtable SubCategorys = new Hashtable();
        public Hashtable Tabs = new Hashtable();

        public void TestCategory()
        {
            HashSet<string> SchoolCategories = new HashSet<string>();
            SchoolCategories.Add("학사일정");
            SchoolCategories.Add("과제");
            SchoolCategories.Add("퀴즈");
            SchoolCategories.Add("온라인강의");
            HashSet<string> PersonalCategories = new HashSet<string>();
            PersonalCategories.Add("생일");
            PersonalCategories.Add("약속");
            PersonalCategories.Add("식사");
            HashSet<string> EtcCatergories = new HashSet<string>();
            EtcCatergories.Add("기타1");
            EtcCatergories.Add("기타2");
            EtcCatergories.Add("기타3");

            Categorys["SchoolCategory"] = SchoolCategories;
            Categorys["PersonalCategory"] = PersonalCategories;
            Categorys["EtcCategory"] = EtcCatergories;

            HashSet<String> TabCategory1 = new HashSet<String>();
            TabCategory1.Add("학사일정");
            TabCategory1.Add("온라인강의");
            TabCategory1.Add("약속");
            TabCategory1.Add("기타1");
            Tabs["btnTab1"] = TabCategory1;

            HashSet<String> TabCategory2 = new HashSet<String>();
            TabCategory2.Add("학사일정");
            TabCategory2.Add("과제");
            TabCategory2.Add("퀴즈");
            TabCategory2.Add("온라인강의");
            TabCategory2.Add("기타1");
            TabCategory2.Add("기타2");
            Tabs["btnTab2"] = TabCategory2;

            HashSet<String> TabCategory3 = new HashSet<String>();
            TabCategory3.Add("학사일정");
            TabCategory3.Add("과제");
            TabCategory3.Add("퀴즈");
            TabCategory3.Add("온라인강의");
            TabCategory3.Add("생일");
            TabCategory3.Add("약속");
            TabCategory3.Add("식사");
            TabCategory3.Add("기타1");
            TabCategory3.Add("기타2");
            TabCategory3.Add("기타3");
            Tabs["btnTab3"] = TabCategory3;
        }

        //하위 카테고리 추가
        public void AddSubdivision(string Main, string Sub)
        {
            Categorys[Main].Add(Sub);
        }


        //하위 카테고리 이름 변경
        public void ChageSubdivisionName(string Parent, string Old, string New)
        {
            Categorys[Parent].Remove(Old);
            Categorys[Parent].Add(Old);

            foreach (DictionaryEntry tab in Tabs)
            {
                HashSet<string> tabCategorys = tab.Value as HashSet<string>;
                if (tabCategorys.Contains(Old))
                {
                    tabCategorys.Remove(Old);
                    tabCategorys.Add(New);
                }
            }
        }


        //하위 카테고리가 속한 상위 카테고리 변경
        //Sub의 소속을 OldParent에서 NewParent로 변경
        public void ChangeParentOfSub(string OldParent, string NewParent, string Sub)
        {
            //기존 main에서 sub 제거
            Categorys[OldParent].Remove(Sub);
            //새로운 main에 sub 추가
            Categorys[NewParent].Add(Sub);
        }

        //탭에 카테고리가 속해있는지 판단
        public bool IsChecked(string Tab, string Sub)
        {
            HashSet<string> TabCategory = Tabs[Tab] as HashSet<string>;
            return TabCategory.Contains(Sub);
        }

        //탭에 하위 카테고리 추가
        public void AddChecked(string Tab, string Sub)
        {
            HashSet<string> TabCategory = Tabs[Tab] as HashSet<string>;
            TabCategory.Add(Sub);
        }

        //탭에 하위 카테고리 제거
        public void DeletChecked(string Tab, string Sub)
        {
            HashSet<string> TabCategory = Tabs[Tab] as HashSet<string>;
            if (TabCategory.Contains(Sub))
            {
                TabCategory.Remove(Sub);
            }
        }
    }
}
