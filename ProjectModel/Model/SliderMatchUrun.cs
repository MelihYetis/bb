using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SliderMatchUrun")]
    public class SliderMatchUrun
    {
        [Key]
        public int SliderMatchUrunId { get; set; }

        public int SliderId { get; set; }
        public int UrunId { get; set; }

        public string SliderUrunAdi { get; set; }
    }
}
