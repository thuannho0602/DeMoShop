using Demo.ViewMode.Catalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewMode.Catalog.Productt
{
    public class GetPublicProcductPagingRequest : PagingRequestBase
    {
        public int? CategoryIds { get; set; }
    }
}
