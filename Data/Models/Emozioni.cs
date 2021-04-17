using CommonClasses.BaseClasses;
using CommonClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Emozioni : BaseNotifyPropertyChanged
    {
        public TipoCaratteristicaEnum Sentimento { get; set; }
        public TipoCaratteristicaEnum Indole { get; set; }
        public TipoCaratteristicaEnum Istinto { get; set; }
        public TipoCaratteristicaEnum ReazStress { get; set; }
        public TipoCaratteristicaEnum Vizio { get; set; }
        public TipoCaratteristicaEnum TendEmozionale { get; set; }
        public TipoCaratteristicaEnum Virtù { get; set; }
        public TipoCaratteristicaEnum GestioneEmozioni { get; set; }
        public TipoCaratteristicaEnum PuntoDiForza { get; set; }
        public TipoCaratteristicaEnum Reazione { get; set; }
        public TipoCaratteristicaEnum Sogni { get; set; }
    }
}
