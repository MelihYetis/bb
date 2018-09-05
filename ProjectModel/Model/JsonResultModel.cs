using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Model
{
    public class JsonResultModel
    {
        public bool IsSuccess { get; set; }

        public string UserMessage { get; set; }

        public List<Konum> Konums   { get; set; }
    }
}
