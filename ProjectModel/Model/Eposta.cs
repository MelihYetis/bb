using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    public class Eposta
    {
        public int EpostaId { get; set; }

        public string EpostaGonderenAdres { get; set; }

        public string EpostaAliciAdres { get; set; }

        public string EpostaSifre { get; set; }

        public string EpostaGidenPostaSunucusu { get; set; }

        public int EpostaPort { get; set; }

        public string EpostaGondericiAdi { get; set; }
    }
}
