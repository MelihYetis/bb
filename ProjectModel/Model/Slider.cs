using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        public int SliderSayfaId { get; set; }

        public string SliderAdi { get; set; }

        public string SliderYeri { get; set; }

        public bool SliderAktifPasif { get; set; }

        public bool SliderUrunAktifPasif { get; set; }

        
    }
}
