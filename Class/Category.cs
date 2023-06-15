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

            CategoryColor.Add(New, CategoryColor[Old]);
            CategoryColor.Remove(Old);
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

        //하위 카테고리 이미 존재 여부
        public bool IsExitsSubCategory(string Sub)
        {
            return CategoryColor.ContainsKey(Sub);
        }

    }
}
