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
        public Hashtable ParentCategory = new Hashtable();
        public Hashtable SubCategory = new Hashtable();
        public HashSet<string> Checked = new HashSet<string>();

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

            ParentCategory["SchoolCategory"] = SchoolCategories;
            ParentCategory["PersonalCategory"] = PersonalCategories;
            ParentCategory["EtcCategory"] = EtcCatergories;

            SubCategory["학사일정"] = "SchoolCategory";
            SubCategory["과제"] = "SchoolCategory";
            SubCategory["퀴즈"] = "SchoolCategory";
            SubCategory["온라인 강의"] = "SchoolCategory";

            SubCategory["생일"] = "PersonalCategory";
            SubCategory["약속"] = "PersonalCategory";
            SubCategory["식사"] = "PersonalCategory";

            SubCategory["기타1"] = "EtcCategory";
            SubCategory["기타2"] = "EtcCategory";
            SubCategory["기타3"] = "EtcCategory";

            Checked.Add("학사일정");
            Checked.Add("과제");
            Checked.Add("퀴즈");
            Checked.Add("온라인강의");
            Checked.Add("생일");
            Checked.Add("약속");
            Checked.Add("식사");
            Checked.Add("기타1");
            Checked.Add("기타2");
            Checked.Add("기타3");
        }

        public void TestTab1()
        {
            Checked.Clear();
            Checked.Add("학사일정");
            Checked.Add("온라인강의");
            Checked.Add("약속");
            Checked.Add("기타1");
        }

        public void TestTab2()
        {
            Checked.Clear();
            Checked.Add("학사일정");
            Checked.Add("과제");
            Checked.Add("퀴즈");
            Checked.Add("온라인강의");
            Checked.Add("기타1");
            Checked.Add("기타2");
        }

        public void TestTab3()
        {
            Checked.Clear();
            Checked.Add("학사일정");
            Checked.Add("과제");
            Checked.Add("퀴즈");
            Checked.Add("온라인강의");
            Checked.Add("생일");
            Checked.Add("약속");
            Checked.Add("식사");
            Checked.Add("기타1");
            Checked.Add("기타2");
            Checked.Add("기타3");
        }

        public void AddSubdivision(string Main, string Sub)
        {
            HashSet<string> SubdivisionSet = ParentCategory[Main] as HashSet<string>;
            SubdivisionSet.Add(Sub);
            ParentCategory[Main] = SubdivisionSet;
            SubCategory[Sub] = Main;
        }

        public void ChageSubdivisionName(string Old, string New)
        {
            string ParentCategory = KSCS.Category.SubCategory[Old] as string;
            //대분류단에서 이름 수정
            HashSet<string> Set = KSCS.Category.ParentCategory[ParentCategory] as HashSet<string>;
            Set.Remove(Old);
            Set.Add(New);
            KSCS.Category.ParentCategory[ParentCategory] = Set;
            //하위 카테고리 단에서의 수정
            KSCS.Category.SubCategory.Remove(Old);
            KSCS.Category.SubCategory.Add(New, ParentCategory);
        }

        public void ChangeParentOfSub(string NewMain, string Sub)
        {
            string sourcsMain = SubCategory[Sub] as string;
            //기존 main에서 sub 제거
            HashSet<string> deleteSubformSourceMain = ParentCategory[sourcsMain] as HashSet<string>;
            deleteSubformSourceMain.Remove(Sub);
            ParentCategory[sourcsMain] = deleteSubformSourceMain;
            //sub에 대한 main 변경
            SubCategory[Sub] = NewMain;
            //새로운 main에 sub 추가
            HashSet<string> AddSubIntoNewParent = ParentCategory[NewMain] as HashSet<string>;
            AddSubIntoNewParent.Add(Sub);
            ParentCategory[NewMain] = AddSubIntoNewParent;
        }

        public void AddChecked(string Sub)
        {
            Checked.Add(Sub);
        }

        public void DeletChecked(string Sub)
        {
            if (Checked.Contains(Sub))
            {
                Checked.Remove(Sub);
            }
        }
    }
}
