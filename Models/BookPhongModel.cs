using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class BookPhongModel
    {
        public string maTiec { get; set; }
        public string maPhong { get; set; }
        [Column("slnuocuong")]
        public int slNuoc { get; set; }
        [ForeignKey("maPhong")]
        public PhongModel Phong { get; set; }
        [ForeignKey("maTiec")]
        public TiecModel Tiec { get; set; }
    }
}
