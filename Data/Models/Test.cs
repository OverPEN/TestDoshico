using System;

namespace Data.Models
{
    public class Test
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid IDCliente { get; set; }
        public Prakriti QuesitiPrakriti { get; set; }
        public Vikriti QuesitiVikriti { get; set; }
        public Mente QuesitiMente { get; set; }
        public Emozioni QuesitiEmozioni { get; set; }
        public DateTime DataTest { get; set; } = DateTime.Today;
    }
}
