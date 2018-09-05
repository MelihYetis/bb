using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    public class ViewModelUrun
    {
        public int UrunId { get; set; }

        public string UrunAdi { get; set; }

        public int UstKategoriId { get; set; }

        public string UstKategoriAdi { get; set; }

        public int AltKategoriId { get; set; }

        public string AltKategoriAdi { get; set; }

        public int UrunMatchKategoriId { get; set; }

        public byte[] UrunResimImageByte { get; set; }

        public string UrunKisaAciklama { get; set; }

        public string UrunPiyasaFiyati { get; set; }

        public string UrunSatisFiyati { get; set; }

        public string UrunAciklama { get; set; }

        public int UrunAdet { get; set; }

        public double UrunSum { get; set; }

        public string BirAltKategoriAdi { get; set; }
        
        [NotMapped]
        public List<string> ResimPath { get; set; }
        [NotMapped]
        public List<string> BedenList { get; set; }

        public int BedenId { get; set; }

        public string BedenAciklama { get; set; }
        public int UrunMatchBedenId { get; set; }

        public int TabAdet { get; set; }
        public string UrunKodu { get; set; }

        public string OnlineLink { get; set; }
        
    }
}
