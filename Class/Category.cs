using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KSCS.Class.KSCS_static;

namespace KSCS
{
    public class Category
    {
        public Dictionary<string, HashSet<string>> Categories=new Dictionary<string, HashSet<string>>();
        public Dictionary<string, Color> CategoryColor= new Dictionary<string, Color>();
        public Hashtable Tabs=new Hashtable();

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

            Categories["학교"] = SchoolCategories;
            Categories["개인"] = PersonalCategories;
            Categories["기타"] = EtcCatergories;

            HashSet<String> TabCategory1 = new HashSet<String>();
            TabCategory1.Add("학사일정");
            TabCategory1.Add("과제");
            TabCategory1.Add("퀴즈");
            TabCategory1.Add("온라인강의");
            TabCategory1.Add("생일");
            TabCategory1.Add("약속");
            TabCategory1.Add("식사");
            TabCategory1.Add("기타1");
            TabCategory1.Add("기타2");
            TabCategory1.Add("기타3");
            Tabs["TabAll"] = TabCategory1;

            HashSet<String> TabCategory2 = new HashSet<String>();
            TabCategory2.Add("학사일정");
            TabCategory2.Add("과제");
            TabCategory2.Add("퀴즈");
            TabCategory2.Add("온라인강의");
            TabCategory2.Add("기타1");
            TabCategory2.Add("기타2");
            Tabs["Tab1"] = TabCategory2;

            HashSet<String> TabCategory3 = new HashSet<String>();
            TabCategory3.Add("학사일정");
            TabCategory3.Add("과제");
            TabCategory3.Add("퀴즈");
            TabCategory3.Add("온라인강의");
            Tabs["Tab2"] = TabCategory3; 
            
            HashSet<String> TabCategory4 = new HashSet<String>();
            TabCategory4.Add("생일");
            TabCategory4.Add("약속");
            TabCategory4.Add("식사");
            Tabs["Tab3"] = TabCategory4; 
            
            HashSet<String> TabCategory5 = new HashSet<String>();
            TabCategory5.Add("기타1");
            TabCategory5.Add("기타2");
            TabCategory5.Add("기타3");
            Tabs["Tab4"] = TabCategory5;
        }

        //카테고리 Color 
        public void SetColor(string Sub,Color color)
        {
            if (CategoryColor.ContainsKey(Sub))
            {
                CategoryColor[Sub] = color;
            }
            else
            {
                CategoryColor.Add(Sub, color);
            }
           
        }

        public Color GetColor(string Sub)
        {
            return CategoryColor[Sub];
        }

        //탭에 카테고리 설정
        public void LoadTab(Hashtable tabs)
        {
            Tabs = tabs;
        }
        public void AddParent(string Main)
        {
            if (!Categories.ContainsKey(Main))
            {
                Categories.Add(Main, new HashSet<string>());
            }
        }

        //하위 카테고리 추가
        public void AddSubdivision(string Main, string Sub)
        {
            if (!Categories.ContainsKey(Main))
            {
                Categories.Add(Main,new HashSet<string>());
            }
            Categories[Main].Add(Sub);
            CategoryColor.Add(Sub, Color.Black);

        }


        //하위 카테고리 이름 변경
        public void ChageSubdivisionName(string Parent, string Old, string New)
        {
            Categories[Parent].Remove(Old);
            Categories[Parent].Add(Old);

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
            Categories[OldParent].Remove(Sub);
            //새로운 main에 sub 추가
            Categories[NewParent].Add(Sub);
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
            if (!TabCategory.Contains(Sub))
            { 
                Database.InsertTabCategory(Tab, Sub);
                TabCategory.Add(Sub);
            }
        }

        //탭에 하위 카테고리 제거
        public void DeletChecked(string Tab, string Sub)
        {
            HashSet<string> TabCategory = Tabs[Tab] as HashSet<string>;
            if (TabCategory.Contains(Sub))
            {
                Database.DeleteTabCategory(Tab, Sub);
                TabCategory.Remove(Sub);
            }
        }

        //상위 카테고리 이름 변경
        public void ChangeMainName(string Old, string New)
        {
            Categories[New] = Categories[Old];
            Categories.Remove(Old);
        }

        //탭이름 변경
        public void ChangeTabName(string Old, string New)
        {
            Tabs[New] = Tabs[Old];
            Tabs.Remove(Old);
        }

        //하위 카테고리 이미 존재 여부
        public bool IsExitsSubCategory(string Sub)
        {
            return CategoryColor.ContainsKey(Sub);
        }

    }
}
