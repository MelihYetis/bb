using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("Parallax")]
    public class Parallax
    {
        [Key]
        public int ParallaxId { get; set; }

        public byte[] ParallaxResimImageByte { get; set; }

        public string ParallaxAciklama { get; set; }

        public string ParallaxYeri { get; set; }

        public bool ParallaxAktifPasif { get; set; }
    }
}
