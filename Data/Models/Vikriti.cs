using CommonClasses.BaseClasses;
using CommonClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Vikriti : BaseNotifyPropertyChanged
    {
        public TipoCaratteristicaEnum Peso { get; set; }
        public TipoCaratteristicaEnum Temperatura { get; set; }
        public TipoCaratteristicaEnum TendPelle { get; set; }
        public TipoCaratteristicaEnum Labbra { get; set; }
        public TipoCaratteristicaEnum Capelli { get; set; }
        public TipoCaratteristicaEnum Luoghi { get; set; }
        public TipoCaratteristicaEnum Lingua { get; set; }
        public TipoCaratteristicaEnum BiancoOcchi { get; set; }
        public TipoCaratteristicaEnum Evacuazione { get; set; }
        public TipoCaratteristicaEnum Malattie { get; set; }
        public TipoCaratteristicaEnum InteresseSessuale { get; set; }
        public TipoCaratteristicaEnum Mestruazioni { get; set; }
        public TipoCaratteristicaEnum Cibo { get; set; }
        public TipoCaratteristicaEnum Gengive { get; set; }
        public TipoCaratteristicaEnum Articolazioni { get; set; }
    }
}
