using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("GaleriSayfaResimler")]
    public class GaleriSayfaResimler
    {
        [Key]
        public int GaleriSayfaResimlerId { get; set; }

        public int SayfaId { get; set; }

        public byte[] GaleriSayfaResimImageByte { get; set; }

        public string GaleriSayfaResimAciklama { get; set; }


    }
}
