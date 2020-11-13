using Microsoft.AspNetCore.Mvc.Rendering;
using QuanLiSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiSach.Viewmodel
{
    public class HomeIndex
    {
        public Book Book { set; get; }
        public IEnumerable<SelectListItem> CategoriesSelectList { set; get; }
    }
}
