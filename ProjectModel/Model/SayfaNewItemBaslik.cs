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
    [Table("SayfaNewItemBaslik")]
    public class SayfaNewItemBaslik
    {
        [Key]
        public int SayfaNewItemBaslikId { get; set; }
        
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string SayfaNewItemBaslikAciklama { get; set; }

        public string SayfaNewItemBaslikLink { get; set; }
        public int SayfalarNewItemId { get; set; }
    }
}
