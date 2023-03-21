using Demo.DataBase.EF;
using Demo.ViewMode.Catalog.Common;
using Demo.ViewMode.Catalog.Productt;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Demo.Application.Catalog.Productt
{
    public class PublicProductSerivce : IManageProductService
    {
        private readonly DemoDbcontext _context;
        public PublicProductSerivce(DemoDbcontext context)
        {
            _context = context;
        }

        public Task<int> AddImage(int productId, List<FormFile> files)
        {
            throw new NotImplementedException();
        }

        public Task AddViewCount(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Creact(ProductCraectRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewMode>> GetAll()
        {
            // 1 select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            var data =await query
                .Select(x => new ProductViewMode()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreacted = x.p.DateCreacted,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    Originalprice = x.p.Originalprice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,

                }).ToListAsync();
            return data;
        }

        public async Task<PagedReuslt<ProductViewMode>> GetAllByCategoryId(GetPublicProcductPagingRequest request)
        {
            //1 select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            //2filter


            if (request.CategoryIds != null && request.CategoryIds != 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryIds);
            }
            //3 Paging 
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndext - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewMode()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreacted = x.p.DateCreacted,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    Originalprice = x.p.Originalprice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,

                }).ToListAsync();

            //4 select projection
            var paredRequest = new PagedReuslt<ProductViewMode>()
            {
                TotalRecord = totalRow,
                Items = await data
            };
            return paredRequest;
        }

        public Task<PagedReuslt<ProductViewMode>> GetAllPaging(GetManageProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewMode> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemevoImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdataStock(int productId, int addQuantity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool IDefault)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }
    }
}
