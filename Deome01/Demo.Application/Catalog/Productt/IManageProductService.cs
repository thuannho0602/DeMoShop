using Demo.ViewMode.Catalog.Common;
using Demo.ViewMode.Catalog.Productt;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Catalog.Productt
{
    //Dùng Cho Admin
    public interface IManageProductService
    {
        Task<int> Creact(ProductCraectRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdataStock(int productId, int addQuantity);

        Task AddViewCount(int productId);

        Task<ProductViewMode> GetById(int productId);

        Task<PagedReuslt<ProductViewMode>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int>AddImage(int productId,List<FormFile>files);

        Task<int> RemevoImage(int imageId );

        Task<int> UpdateImage(int imageId,string caption,bool IDefault);
        Task<List<ProductImageViewModel>> GetListImage(int productId);
    }
}
