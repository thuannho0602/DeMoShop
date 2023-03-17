using Demo.DataBase.Configurations;
using Demo.DataBase.Emum;
using Demo.DataBase.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appconfig>().HasData(
               new Appconfig() { Key = "Nguyen Minh Thuan", Value = "afdfdfds" },
               new Appconfig() { Key = " Minh Thuan", Value = "afdfdfvddfdds" },
               new Appconfig() { Key = "Nguyen Minh ", Value = "afdfdfds" }
                );

            modelBuilder.Entity<Language>().HasData(
               new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
               new Language() { Id = "en", Name = "English", IsDefault = false });
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowonHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,

                },

                 new Category()
                 {
                     Id = 2,
                     IsShowonHome = true,
                     ParentId = null,
                     SortOrder = 1,
                     Status = Status.Active,
                 });
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation(){
                    Id=1,
                    CategoryId = 1,
                    Name = "Áo Nam", 
                    LanguageId = "vi",
                    SeoAlias="Ao-Nam",
                    SeoDesCription="Sẩn Phẩm Thời Trang Nam ",
                    SeoTile= "Sẩn Phẩm Thời Trang Nam"
                },
                 new CategoryTranslation()
                 {
                     Id=2,
                     CategoryId = 2,
                     Name = "Men-Shirt",
                     LanguageId = "en",
                     SeoAlias = "Men-Shirt",
                     SeoDesCription = "Men's Fashion Products ",
                     SeoTile = "Men's Fashion Products"
                 }

                );
            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   DateCreacted = DateTime.Now,
                   Originalprice = 10000,
                   Price = 2000,
                   Stock = 0,
                   ViewCount = 0,
               },
               new Product()
               {
                   Id = 2,
                   DateCreacted = DateTime.Now,
                   Originalprice = 10000,
                   Price = 2000,
                   Stock = 0,
                   ViewCount = 0,
               }
               );
            modelBuilder.Entity<ProductTranslation>().HasData(
                  new ProductTranslation()
                  {
                      Id=1,
                      ProductId = 1,
                      Name = "Áo Sơ Mi Nam Trắng Minh Thuận",
                      LanguageId = "vi",
                      SeoAlias = "ao-so-mi-nam-trang-minh-thuan",
                      SeoDescription = "Áo Sơ Mi Nam Trắng Minh Thuận ",
                      SeoTitle = "Áo Sơ Mi Nam Trắng Minh Thuận",
                      Description = "Áo Sơ Mi Nam Trắng Minh Thuận",
                      Details = "Áo Sơ Mi Nam Trắng Minh Thuận"
                  },
                  new ProductTranslation()
                  {
                      Id=2,
                      ProductId=2,
                      Name = "Minh Thuan Men's White Shirt",
                      LanguageId = "en",
                      SeoAlias = "minh-thuan-men's-white-shirt",
                      SeoDescription = "Minh Thuan Men's White Shirt ",
                      SeoTitle = "Minh Thuan Men's White Shirt",
                      Description = "Minh Thuan Men's White Shirt",
                      Details = "Minh Thuan Men's White Shirt"
                  }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory()
                {
                    ProductId = 1,
                    CategoryId = 1,
                }
                
                );
            //       ProductTranslations = new List<ProductTranslation>()
            //       {
            //           new ProductTranslation()
            //           {

            //               Name = "Áo Sơ Mi Nam Trắng Minh Thuận",
            //               LanguageId = "vi",
            //               SeoAlias = "ao-so-mi-nam-trang-minh-thuan",
            //               SeoDescription = "Áo Sơ Mi Nam Trắng Minh Thuận ",
            //               SeoTitle = "Áo Sơ Mi Nam Trắng Minh Thuận",
            //               Description="Áo Sơ Mi Nam Trắng Minh Thuận",
            //               Details="Áo Sơ Mi Nam Trắng Minh Thuận"
            //           },
            //           new ProductTranslation()
            //           {

            //              Name = "Minh Thuan Men's White Shirt",
            //              LanguageId = "en",
            //              SeoAlias = "minh-thuan-men's-white-shirt",
            //              SeoDescription = "Minh Thuan Men's White Shirt ",
            //              SeoTitle = "Minh Thuan Men's White Shirt",
            //              Description="Minh Thuan Men's White Shirt",
            //              Details="Minh Thuan Men's White Shirt"
            //           }
            //       },
            //   }) ;
            //modelBuilder.Entity<ProductInCategory>().HasData( 
            //    new ProductInCategory()
            //    {
            //        ProductId = 1,
            //        CategoryId= 1,
            //    }
            //    );





        }
    }
}
