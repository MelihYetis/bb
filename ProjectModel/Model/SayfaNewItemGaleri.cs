using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaNewItemGaleri")]
    public class SayfaNewItemGaleri
    {
        [Key]
        public int SayfaNewItemGaleriId { get; set; }

        public int SayfalarNewItemId { get; set; }

        public string SayfalarNewItemResimPath { get; set; }

        public string SayfalarNewItemResimAciklama { get; set; }
    }
}
