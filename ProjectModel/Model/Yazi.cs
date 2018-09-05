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
    [Table("Yazilar")]
    public class Yazi
    {
        [Key]
        public int YaziId { get; set; }

        public int YaziKategoriId { get; set; }

        public string YaziBaslik { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string YaziAciklama { get; set; }

        public string YaziSeoLink { get; set; }

        public string YaziImagePath { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string YaziKisaAciklama { get; set; }
    }
}
