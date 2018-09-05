using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("YaziKategoriler")]
    public class YaziKategori
    {
        [Key]
        public int YaziKategoriId { get; set; }

        public string YaziKategoriAciklama { get; set; }
    }
}
