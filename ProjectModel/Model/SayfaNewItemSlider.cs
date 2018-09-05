using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SayfaNewItemSlider")]
    public class SayfaNewItemSlider
    {
        [Key]
        public int SayfaNewItemSliderId { get; set; }

        public int SayfalarNewItemId { get; set; }

        public string SayfalarNewSliderResimPath { get; set; }

        public string SayfalarNewItemSliderAciklama { get; set; }
    }
}
