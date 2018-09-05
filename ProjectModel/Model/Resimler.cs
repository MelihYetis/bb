using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("Resimler")]
    public class Resimler
    {
        [Key]
        public int ResimId { get; set; }

        public int SayfaId { get; set; }

        public byte [] ImageByte { get; set; }

        public byte[] ResimImageByte { get; set; }

        public int SayfaSatirNumarasi { get; set; }

        public string ResimAciklama { get; set; }

        public int LinkSayfaId { get; set; }

        public string LinkAdres { get; set; }
    }
}
