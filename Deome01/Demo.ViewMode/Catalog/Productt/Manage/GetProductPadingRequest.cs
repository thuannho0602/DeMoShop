
using Demo.ViewMode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewMode.Productt.Manage
{
    public class GetProductPadingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }

        public string LanguageId { get; set; }

        public int CategoryIds { get; set; }
    }
}
