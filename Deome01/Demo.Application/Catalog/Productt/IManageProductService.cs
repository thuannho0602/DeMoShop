
using Demo.Application.Catalog.Productt.Dtos;
using Demo.ViewMode.Common;
using Demo.ViewMode.Productt.Manage;
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

        Task<int> Update(ProductUpdateRequest reguest);

        Task<int> Delete(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdataStock(int productId, int addQuantity);

        Task AddViewCount(int productId);

       

        Task<PagedReuslt<ProductViewMode>> GetAllPaging(GetProductPadingRequest request);
    }
}
