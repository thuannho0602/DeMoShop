using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ViewMode.Catalog.Productt;
using Demo.ViewMode.Catalog.Common;

namespace Demo.Application.Catalog.Productt
{

    // Dùng Phương Thức Bên Ngoài Cho Khách Hàng Đọc
    public interface IPublicProductService
    {
       Task< PagedReuslt<ProductViewMode>> GetAllByCategoryId(GetPublicProcductPagingRequest request);
        Task<List<ProductViewMode>> GetAll();
    }
}
