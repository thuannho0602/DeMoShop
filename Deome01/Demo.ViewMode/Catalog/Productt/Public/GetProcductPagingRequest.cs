using Demo.ViewMode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewMode.Productt.Public
{
    public class GetProcductPagingRequest:PagingRequestBase
    {
        public int? CategoryIds { get; set; }
    }
}
