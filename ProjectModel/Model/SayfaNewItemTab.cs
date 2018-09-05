using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaNewItemTab")]
    public class SayfaNewItemTab
    {
        [Key]
        public int SayfaNewItemTabId { get; set; }

        public int SayfalarNewItemId { get; set; }

        public int SayfaNewItemTabAdet { get; set; }

        public string SayfaNewItemTabAdi { get; set; }
       
    }
}
