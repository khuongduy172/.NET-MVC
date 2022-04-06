using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class SanhModel
    {
        public string maSanh { get; set; }
        public string tenSanh { get; set; }

        public ICollection<PhongModel> Phongs { get; set; }
    }
}
