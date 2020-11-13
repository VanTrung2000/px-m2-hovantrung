using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiSach.Models
{
    public class Book
    {
        public int Id { set; get; }
        [DisplayName("Namebook")]
        [Required]
        [MinLength(3)]
        public string Namebook { set; get; }
        public string Author { set; get; }
        public string Despition { set; get; }
        public int Publishingyear {set;get;}
        public int Count { set; get; }
        public int CategorybookId { set; get; }
        public CategoryBook categoryBook { set; get; }
    }
}
