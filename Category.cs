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
        public Hashtable ParentCategorys = new Hashtable();
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

            ParentCategorys["SchoolCategory"] = SchoolCategories;
            ParentCategorys["PersonalCategory"] = PersonalCategories;
            ParentCategorys["EtcCategory"] = EtcCatergories;

            SubCategorys["학사일정"] = "SchoolCategory";
            SubCategorys["과제"] = "SchoolCategory";
            SubCategorys["퀴즈"] = "SchoolCategory";
            SubCategorys["온라인 강의"] = "SchoolCategory";

            SubCategorys["생일"] = "PersonalCategory";
            SubCategorys["약속"] = "PersonalCategory";
            SubCategorys["식사"] = "PersonalCategory";

            SubCategorys["기타1"] = "EtcCategory";
            SubCategorys["기타2"] = "EtcCategory";
            SubCategorys["기타3"] = "EtcCategory";

            HashSet<String> TabCategory1 = new HashSet<String>();
            TabCategory1.Add("학사일정");
            TabCategory1.Add("온라인강의");
            TabCategory1.Add("약속");
            TabCategory1.Add("기타1");
            Tabs["btnTestTab1"] = TabCategory1;

            HashSet<String> TabCategory2 = new HashSet<String>();
            TabCategory2.Add("학사일정");
            TabCategory2.Add("과제");
            TabCategory2.Add("퀴즈");
            TabCategory2.Add("온라인강의");
            TabCategory2.Add("기타1");
            TabCategory2.Add("기타2");
            Tabs["btnTestTab2"] = TabCategory2;

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
            Tabs["btnTestTab3"] = TabCategory3;
        }

        public void AddSubdivision(string Main, string Sub)
        {
            HashSet<string> SubdivisionSet = ParentCategorys[Main] as HashSet<string>;
            SubdivisionSet.Add(Sub);
            SubCategorys[Sub] = Main;
        }

        public void ChageSubdivisionName(string Old, string New)
        {
            string ParentCategory = KSCS.Category.SubCategorys[Old] as string;
            //대분류단에서 이름 수정
            HashSet<string> Set = KSCS.Category.ParentCategorys[ParentCategory] as HashSet<string>;
            Set.Remove(Old);
            Set.Add(New);
            //하위 카테고리 단에서의 수정
            KSCS.Category.SubCategorys.Remove(Old);
            KSCS.Category.SubCategorys.Add(New, ParentCategory);

            foreach(DictionaryEntry tab in Tabs)
            {
                HashSet<string> tabCategorys = tab.Value as HashSet<string>;
                if (tabCategorys.Contains(Old))
                {
                    tabCategorys.Remove(Old);
                    tabCategorys.Add(New);
                }
            }
        }

        public void ChangeParentOfSub(string NewMain, string Sub)
        {
            string sourcsMain = SubCategorys[Sub] as string;
            //기존 main에서 sub 제거
            HashSet<string> deleteSubformSourceMain = ParentCategorys[sourcsMain] as HashSet<string>;
            deleteSubformSourceMain.Remove(Sub);
            //sub에 대한 main 변경
            SubCategorys[Sub] = NewMain;
            //새로운 main에 sub 추가
            HashSet<string> AddSubIntoNewParent = ParentCategorys[NewMain] as HashSet<string>;
            AddSubIntoNewParent.Add(Sub);
        }

        public bool IsChecked(string Tab, string Sub)
        {
            HashSet<string> TabCategory = Tabs[Tab] as HashSet<string>;
            return TabCategory.Contains(Sub);
        }
        public void AddChecked(string Tab, string Sub)
        {
            HashSet<string> TabCategory = Tabs[Tab] as HashSet<string>;
            TabCategory.Add(Sub);
        }

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
