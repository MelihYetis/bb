using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{

    [Table("SayfaNewItemTabGaleri")]
    public class SayfaNewItemTabGaleri
    {
        [Key]
        public int SayfaNewItemTabGaleriId { get; set; }

        public int SayfaNewItemTabItemId { get; set; }
        public string SayfalarNewItemTabResimPath { get; set; }

        public string SayfalarNewItemTabResimAciklama { get; set; }
    }
}
