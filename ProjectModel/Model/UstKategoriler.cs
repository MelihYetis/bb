using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectModel.Model
{
    [Table ("UstKategoriler")]
    public class UstKategoriler
    {
        [Key]
        public int UstKategoriId { get; set; }

        public string UstKategoriAdi { get; set; }

        public int SayfaId { get; set; }
        
        public string SeoLink { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SiraNo { get; set; }
        
    }
}
