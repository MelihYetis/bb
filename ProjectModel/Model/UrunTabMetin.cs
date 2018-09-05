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
    [Table("UrunTabMetin")]
    public class UrunTabMetin
    {
        [Key]
        public int UrunMetinId { get; set; }

        public int UrunTabId { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string UrunTabMetinAciklama { get; set; }

        [NotMapped]
        public string UrunTabBaslik { get; set; }
    }
}
