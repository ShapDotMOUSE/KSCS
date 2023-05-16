using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSCS
{
    internal class Category
    {
        public Hashtable MainCategory = new Hashtable();
        public Hashtable Subdivision = new Hashtable();

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
    }
}
