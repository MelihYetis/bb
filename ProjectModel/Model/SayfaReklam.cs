using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaReklam")]
    public class SayfaReklam
    {
        [Key]
        public int SayfaReklamId { get; set; }

        public string SayfaReklamYeri { get; set; }

        public string SayfaReklamResimPath { get; set; }
        
        public int SayfaNewId { get; set; }

        public string SayfaReklamUrl { get; set; }

        public string TestAlan
        {
            get;
            set;
        }   


    }
}
