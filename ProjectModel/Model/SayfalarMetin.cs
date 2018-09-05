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
    [Table("SayfalarMetin")]
    public class SayfalarMetin
    {
        [Key]
        public int SayfalarMetinId { get; set; }

        public int SayfaId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfalarMetinAciklama { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string AnahtarKelimeler { get; set; }
    }
}
