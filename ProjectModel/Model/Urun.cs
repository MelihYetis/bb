using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("webkonumtaleptmp")]
    public class Urun
    {
        public int Id { get; set; }


        public string MARKA { get; set; }

        public string ADSOYAD { get; set; }

        public string GSM { get; set; }

        public string LAT { get; set; }

        public string LNG { get; set; }

        public int DURUM { get; set; }

        public string SMSKODU { get; set; }
    }
}
