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
    [Table("Bannerlar")]
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }

        public string BannerBaslik { get; set; }

        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string BannerMetin { get; set; }

        public string BannerUrl { get; set; }

        public byte[] BannerImage { get; set; }

        public string BannerImagePath { get; set; }
    }
}
