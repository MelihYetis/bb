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
    [Table("SayfaNewItemTabMetin")]
    public class SayfaNewItemTabMetin
    {
        [Key]
        public int SayfaNewItemTabMetinId { get; set; }

        public int SayfaNewItemTabItemId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemTabItemMetinAciklama { get; set; }
    }
}
