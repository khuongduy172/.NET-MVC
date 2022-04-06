using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class KhachHangModel
    {
        public string maKh { get; set; }
        [Column("tenk")]
        public string tenKh { get; set; }
        public DateTime? ngaySinh { get; set; }
        public string? diaChi { get; set; }
        public ICollection<TiecModel> Tiecs { get; set; }
    }
}
