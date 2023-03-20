using Demo.Application.Catalog.Productt.Dtos;
using Demo.ViewMode.Productt.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.ViewMode.Common;

namespace Demo.Application.Catalog.Productt
{

    // Dùng Phương Thức Bên Ngoài Cho Khách Hàng Đọc
    public interface IPublicProductService
    {
       Task< PagedReuslt<ProductViewMode>> GetAllByCategoryId(GetProcductPagingRequest request);
    }
}
