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
    [Table("SayfalarNewItemPersonel")]
    public class SayfalarNewItemPersonel
    {
        [Key]
        public int SayfalarNewItemPersonelId { get; set; }

        public int SayfalarNewItemId { get; set; }

        public string SayfalarNewItemPersonelResimPath { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfalarNewItemPersonelAciklama { get; set; }
    }
}
