using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class TiecModel
    {
        public string maTiec { get; set; }
        public string tenTiec { get; set; }
        public DateTime? ngayDat {get; set;}
        [Column("makh")]
        public string maKhachHang { get; set; }
        [ForeignKey("maKhachHang")]
        public KhachHangModel KhachHang { get; set; }
        public ICollection<BookPhongModel> BookPhongs { get; set; }
    }
}
