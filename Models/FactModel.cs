using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Alvarez_ExamenProgreso3.Models
{
    public class FactModel
    {
        public int JA_Id { get; set; }
        public string JA_FactText { get; set; }

        public override string ToString()
        {
            return JA_FactText; 
        }
    }

}
