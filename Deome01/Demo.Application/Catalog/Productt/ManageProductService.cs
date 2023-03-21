using Deme.Unitities.Exceptions;
using Demo.Application.Common;
using Demo.DataBase.EF;
using Demo.DataBase.Entity;
using Demo.ViewMode.Catalog.Common;
using Demo.ViewMode.Catalog.Productt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Data.SqlClient;
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
            //luu ảnh
            if(request.ThumbnailImage!=null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption="ThumbnailImage",
                        DateCreated=DateTime.Now,
                        FileSize=request.ThumbnailImage.Length,
                        ImagePath=await this.SaveFile(request.ThumbnailImage),
                        IsDefault=true,
                        SortOrder=1


                    }
                };
            }
            _context.Products.Add(product);
             await _context.SaveChangesAsync();
            return (product.Id);


        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new DemoExceptions($"cannot find a product:{productId}");
            }
            var images = _context.ProductImages.Where(i =>i.ProductId == productId);
           foreach(var image in images)
            {


                _storageService.DeleteFileAsync(image.ImagePath);
                
            }
            _context.Remove(product);
           
           
            return await _context.SaveChangesAsync();
        }

       


        public async Task<PagedReuslt<ProductViewMode>> GetAllPaging(GetManageProductPagingRequest request)
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


        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
            && x.LanguageId == request.LanguageId);
            if (product == null || productTranslations == null)
            {
                throw new DemoExceptions($"cannot find a product:{request.Id}");
            }
            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;
            //update
            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }

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

        public async  Task<int> AddImage(int productId, List<FormFile> files)
        {
            //var product = await _context.Products.FindAsync(productId);
            //return product;
            throw new NotImplementedException();
        }

        public Task<int> RemevoImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImage(int imageId, string caption, bool IDefault)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageViewModel>> GetListImage(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewMode> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedReuslt<ProductViewMode>> GetAllByCategoryId(GetPublicProcductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductViewMode>> GetAll()
        {
            throw new NotImplementedException();
        }
    }


}

