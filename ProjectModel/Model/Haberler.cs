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
    [Table ("Haberler")]
    public class Haberler
    {
        [Key]
        public int HaberId { get; set; }

        public int SayfaId { get; set; }

        public string HaberAdi { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string HaberAciklama { get; set; }
    }
}
