using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    public class ViewModelMusteriSiparis
    {
        public string SiparisUrunAdi { get; set; }

        public int SiparisAdet { get; set; }

        public double SiparisUrunFiyat { get; set; }

        public double SiparisSum { get; set; }

        public string UyeAdi { get; set; }

        public string UyeSoyadi { get; set; }

        public int SiparisMusteriId { get; set; }

        public string UyeTelNo { get; set; }

        public string UyeAdres { get; set; }

        public string UyeEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SiparisTarihi { get; set; }

        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }

        public int SiparisDurum { get; set; }
    }
}
