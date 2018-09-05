using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("TasarimSablon")]
    public class TasarimSablon
    {
        [Key]
        public int SablonId { get; set; }

        public string SablonAdi { get; set; }

        public int SablonSecimi { get; set; }
    }
}
