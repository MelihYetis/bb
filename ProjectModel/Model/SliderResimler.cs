using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SliderResimler")]
    public class SliderResimler
    {
        [Key]
        public int SliderResimlerId { get; set; }

        public int SliderId { get; set; }
        public int SayfaId { get; set; }

        public byte[] SliderResimImageByte { get; set; }

        public string SliderResimAciklama { get; set; }
    }
}
