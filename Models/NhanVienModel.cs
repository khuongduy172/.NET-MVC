using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class NhanVienModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int manv { get; set; }
        public string tennv { get; set; }
        public string gioitinh { get; set;}
        public DateTime ngaysinh {get; set;}
    }
}
