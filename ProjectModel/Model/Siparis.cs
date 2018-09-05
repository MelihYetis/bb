using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("siparis")]
    public class Siparis
    {
        [Key]
        public int SiparisId { get; set; }

        public int SiparisUrunId { get; set; }

        public string SiparisUrunAdi { get; set; }

        public int SiparisUrunAdet { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double SiparisSum { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SiparisTarihi { get; set; }

        public string SiparisMusteriAdi { get; set; }

        public string SiparisMusteriSoyadi { get; set; }

        public string SiparisMusteriMail { get; set; }

        public string SiparisMusteriTel { get; set; }

        public string SiparisMusteriAdres { get; set; }

        public string SiparsiMusteriAciklama { get; set; }
    }
}
