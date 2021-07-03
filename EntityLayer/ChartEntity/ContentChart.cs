using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer.Concrete;

namespace MvcPorject.Models
{
    public class ContentChart
    {
        public string HeadingName { get; set; }
        public int ContentCount { get; set; }
        public int WriterCount { get; set; }

    }
}