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
    [Table ("SosyalMedyalar")]
    public class SosyalMedya
    {
        [Key]
        public int SosyalMedyaId { get; set; }


        public string FaceBookUrl { get; set; }


        public string TwitterUrl { get; set; }


        public string InstagramUrl { get; set; }

        public string YoutubeUrl { get; set; }

        public string LinkedinUrl { get; set; }

        public string IletisimTel { get; set; }

        public string IletisimFax { get; set; }

        public string IletisimEmail { get; set; }

        public string IletisimAdres { get; set; }

        public string IletisimGoogleMaps { get; set; }

        public string GooglePlusUrl { get; set; }

    }
}
