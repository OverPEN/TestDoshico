using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Test
    {
        public Cliente Cliente { get; set; }
        public Prakriti QuesitiPrakriti { get; set; }
        public Vikriti QuesitiVikriti { get; set; }
        public Mente QuesitiMente { get; set; }
        public Emozioni QuesitiEmozioni { get; set; }
        public DateTime DataTest { get; set; } = DateTime.Today;

    }
}
