using Newtonsoft.Json;
using System;

namespace Data.Models
{
    public class Test
    {
        [JsonRequired, JsonProperty]
        public Guid ID { get; set; } = Guid.NewGuid();
        [JsonProperty]
        public Guid IDCliente { get; set; }
        [JsonProperty]
        public Prakriti QuesitiPrakriti { get; set; }
        [JsonProperty]
        public Vikriti QuesitiVikriti { get; set; }
        [JsonProperty]
        public Mente QuesitiMente { get; set; }
        [JsonProperty]
        public Emozioni QuesitiEmozioni { get; set; }
        [JsonProperty]
        public DateTime DataTest { get; set; } = DateTime.Today;
    }
}
