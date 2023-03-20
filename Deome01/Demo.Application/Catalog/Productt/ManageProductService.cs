using Deme.Unitities.Exceptions;
using Demo.Application.Catalog.Productt.Dtos;
using Demo.Application.Common;
using Demo.DataBase.EF;
using Demo.DataBase.Entity;
using Demo.ViewMode.Common;
using Demo.ViewMode.Productt.Manage;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Catalog.Productt
{
    public class ManageProductService : IManageProductService
    {
        private readonly DemoDbcontext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public ManageProductService(DemoDbcontext context, IStorageService storageService)
        {
            _context = context;
            storageService = _storageService;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Creact(ProductCraectRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                Originalprice = request.Originalprice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreacted = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name=request.Name,
                        Description=request.Description,
                        Details=request.Details,
                        SeoDescription=request.SeoDescription,
                        SeoAlias=request.SeoAlias,
                        SeoTitle=request.SeoTitle,
                        LanguageId=request.LanguageId,
                    }
                }

            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();


        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new DemoExceptions($"cannot find a product:{productId}");
            }
            _context.Remove(product);
            return await _context.SaveChangesAsync();
        }

       


        public async Task<PagedReuslt<ProductViewMode>> GetAllPaging(GetProductPadingRequest request)
        {
            //1 select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            //2filter
            if (!string.IsNullOrEmpty(request.Keyword))

                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

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

        public async Task<bool> UpdataStock(int productId, int addQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new DemoExceptions($"cannot find a product:{productId}");
            }
            product.Stock = addQuantity;
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<int> Update(ProductUpdateRequest reguest)
        {
            var product = await _context.Products.FindAsync(reguest.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == reguest.Id
            && x.LanguageId == reguest.LanguageId);
            if (product == null || productTranslations == null)
            {
                throw new DemoExceptions($"cannot find a product:{reguest.Id}");
            }
            productTranslations.Name = reguest.Name;
            productTranslations.SeoAlias = reguest.SeoAlias;
            productTranslations.SeoDescription = reguest.SeoDescription;
            productTranslations.SeoTitle = reguest.SeoTitle;
            productTranslations.Description = reguest.Description;
            productTranslations.Details = reguest.Details;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
          var product=await _context.Products.FindAsync(productId);
            if(product == null)
            {
                throw new DemoExceptions($"cannot find a product:{productId}");
            }
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;


        }

        public Task UpdateViewCount(int productId)
        {
            throw new NotImplementedException();
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

    }


}

