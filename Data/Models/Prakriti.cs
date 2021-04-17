using CommonClasses.BaseClasses;
using CommonClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Prakriti : BaseNotifyPropertyChanged
    {
        public TipoCaratteristicaEnum Corporatura { get; set; }
        public TipoCaratteristicaEnum StruttOssea { get; set; }
        public TipoCaratteristicaEnum Mani { get; set; }
        public TipoCaratteristicaEnum CorporaturaFanc { get; set; }
        public TipoCaratteristicaEnum Accumulo { get; set; }
        public TipoCaratteristicaEnum Pelle { get; set; }
        public TipoCaratteristicaEnum CapelliFanc { get; set; }
        public TipoCaratteristicaEnum Fronte { get; set; }
        public TipoCaratteristicaEnum Occhi { get; set; }
        public TipoCaratteristicaEnum Denti { get; set; }
        public TipoCaratteristicaEnum Collo { get; set; }
        public TipoCaratteristicaEnum Mento { get; set; }
    }
}
