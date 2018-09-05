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
    [Table("SayfaNewItemMetinIkili")]
    public class SayfaNewItemMetinIkili
    {
        [Key]
        public int SayfaNewItemMetinIkiliId { get; set; }

        public int SayfalarNewItemId { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemMetinIkiliAciklamaBir { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemMetinIkiliAciklamaIki { get; set; }
    }
}
