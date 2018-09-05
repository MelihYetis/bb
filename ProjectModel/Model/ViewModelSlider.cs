using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    public class ViewModelSlider
    {
        public int SliderId { get; set; }

        public int SliderSayfaId { get; set; }

        public string SliderAdi { get; set; }

        public int SliderResimlerId { get; set; }

        public byte[] SliderResimImageByte { get; set; }

        public string SliderResimAciklama { get; set; }
    }
}
