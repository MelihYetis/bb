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
    [Table("SayfaNewItemMetin")]
    public class SayfaNewItemMetin
    {
        [Key]
        public int SayfaNewItemMetinId { get; set; }

        public int SayfalarNewItemId { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemMetinAciklama { get; set; }
    }
}
