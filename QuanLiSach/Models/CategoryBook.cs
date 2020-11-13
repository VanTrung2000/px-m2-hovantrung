using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiSach.Models
{
    public class CategoryBook
    {
        public int Id { set; get; }
        public string Category { set; get; }
        public List<Book> Books { get; set; }
    }
}
