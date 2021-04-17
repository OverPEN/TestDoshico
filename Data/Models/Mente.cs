using CommonClasses.Enums;
using CommonClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Mente : BaseNotifyPropertyChanged
    {
        public TipoCaratteristicaEnum Memoria { get; set; }
        public TipoCaratteristicaEnum Routine { get; set; }
        public TipoCaratteristicaEnum Decisioni { get; set; }
        public TipoCaratteristicaEnum Carattere { get; set; }
        public TipoCaratteristicaEnum Pensiero { get; set; }
        public TipoCaratteristicaEnum Organizzazione { get; set; }
        public TipoCaratteristicaEnum Amicizia { get; set; }
        public TipoCaratteristicaEnum Denaro { get; set; }
    }
}
