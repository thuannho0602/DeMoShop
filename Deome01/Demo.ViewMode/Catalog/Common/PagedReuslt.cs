﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.ViewMode.Common
{
    public class PagedReuslt<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
