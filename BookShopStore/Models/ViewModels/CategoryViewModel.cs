using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopStore.Models.ViewModels
{
    public class TreeViewCategory
    {
        public TreeViewCategory()
        {
            SubCategories = new List<TreeViewCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TreeViewCategory> SubCategories { get; set; }
    }
}
