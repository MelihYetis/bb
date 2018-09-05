using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("MusteriSiparis")]
    public class MusteriSiparis
    {
        [Key]
        public int MusteriSiparisId { get; set; }

        public int MusterId { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.##}")]
        public double SiparisSum { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime SiparisTarihi { get; set; }

        public int SiparisDurum { get; set; }

        public string MisafirUyeAdresAciklama { get; set; }
    }
}
