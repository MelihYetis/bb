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
    [Table("SayfaNewItemParallax")]
    public class SayfaNewItemParallax
    {
        [Key]
        public int SayfaNewItemParallaxId { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemParallaxAciklama { get; set; }

        public string SayfalarNewItemParallaxResimPath { get; set; }

        public int SayfalarNewItemId { get; set; }
    }
}
