using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("AltKategoriler")]
    public class AltKategoriler
    {
        [Key]
        public int AltKategoriId { get; set; }

        public string AltKategoriAdi { get; set; }

        public int UstKategoriId{ get; set; }
        public string SeoLink { get; set; }

        public int SayfaId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int SiraNo { get; set; }
    }
}
