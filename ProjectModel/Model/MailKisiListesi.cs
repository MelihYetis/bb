using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    [Table("MailKisiListesi")]
    public class MailKisiListesi
    {
        [Key]
        public int MailKisiKistesiId { get; set; }

        public string MailKisilistesiAdiSoyadi { get; set; }

        public string MailKisiListesiMailAdres { get; set; }
    }
}
