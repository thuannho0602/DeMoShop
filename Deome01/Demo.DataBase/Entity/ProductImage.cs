using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }//FK
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public long Filesize { get; set; }

        // Đi Đến Entity Product Xét Khóa Ngoại
        public Product Product { get; set; }
    }
}
