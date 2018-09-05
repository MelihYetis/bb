using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjectModel.Model
{
    public class ViewModelYaziKategori
    {
        public int YaziId { get; set; }

        public int YaziKategoriId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string YaziAciklama { get; set; }

        public string YaziKategoriAciklama { get; set; }

        public string YaziBaslik { get; set; }

        public string YaziKisaAciklama { get; set; }

        public string YaziImagePath { get; set; }
    }
}
