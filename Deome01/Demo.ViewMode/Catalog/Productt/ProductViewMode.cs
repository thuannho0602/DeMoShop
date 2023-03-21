using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewMode.Catalog.Productt
{
    public class ProductViewMode
    {
        //Entity Product
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Originalprice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreacted { get; set; }


        //Entity ProductTranslaion
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
    }
}
