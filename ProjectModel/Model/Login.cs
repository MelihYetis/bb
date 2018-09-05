using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("Login")]
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        
        public string LoginKullaniciAdi { get; set; }
        
        public string LoginSifre { get; set; }
    }
}
