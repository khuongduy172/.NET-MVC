using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class PhongModel
    {
        public string maPhong { get; set; }
        public string tenPhong { get; set; }
        public int sucChua { get; set; }
        public string loaiPhong { get; set; }
        public string maSanh { get; set; } 
        [ForeignKey("maSanh")]
        public SanhModel sanh { get; set; }
        public ICollection<BookPhongModel> BookPhongs { get; set; }
    }
}
