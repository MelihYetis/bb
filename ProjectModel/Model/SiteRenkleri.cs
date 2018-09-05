using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("SiteRenkleri")]
    public class SiteRenkleri
    {
        [Key]
        public int SiteRenkId { get; set; }

        public string SiteRenkYeri { get; set; }

        public string SiteRenkKodu { get; set; }

        public string BodyRenkKodu { get; set; }

        public string MenuRenkKodu { get; set; }

        public string FooterRenkKodu { get; set; }
    }
}
