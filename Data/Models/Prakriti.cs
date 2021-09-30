using CommonClasses.Enums;
using Data.Interfaces;
using System.ComponentModel;

namespace Data.Models
{

    public class Prakriti : IQuesiti
    {
        #region private properties
        private TipoCaratteristicaEnum corporatura;
        private TipoCaratteristicaEnum struttOssea;
        private TipoCaratteristicaEnum mani;
        private TipoCaratteristicaEnum corporaturaFanc;
        private TipoCaratteristicaEnum accumulo;
        private TipoCaratteristicaEnum pelle;
        private TipoCaratteristicaEnum capelliFanc;
        private TipoCaratteristicaEnum fronte;
        private TipoCaratteristicaEnum occhi;
        private TipoCaratteristicaEnum denti;
        private TipoCaratteristicaEnum collo;
        private TipoCaratteristicaEnum mento;
        #endregion
 
        [DisplayName("Corporatura")]
        public TipoCaratteristicaEnum Corporatura
        {
            get { return corporatura; }
            set
            {
                corporatura = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }       
        [DisplayName("Struttura Ossea")]
        public TipoCaratteristicaEnum StruttOssea
        {
            get { return struttOssea; }
            set
            {
                struttOssea = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }        
        [DisplayName("Mani")]
        public TipoCaratteristicaEnum Mani
        {
            get { return mani; }
            set
            {
                mani = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }        
        [DisplayName("Corporatura in Fanciullezza")]
        public TipoCaratteristicaEnum CorporaturaFanc
        {
            get { return corporaturaFanc; }
            set
            {
                corporaturaFanc = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }        
        [DisplayName("Accumulo")]
        public TipoCaratteristicaEnum Accumulo
        {
            get { return accumulo; }
            set
            {
                accumulo = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }        
        [DisplayName("Pelle")]
        public TipoCaratteristicaEnum Pelle
        {
            get { return pelle; }
            set
            {
                pelle = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }        
        [DisplayName("Capelli in Fanciullezza")]
        public TipoCaratteristicaEnum CapelliFanc
        {
            get { return capelliFanc; }
            set
            {
                capelliFanc = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }        
        [DisplayName("Fronte")]
        public TipoCaratteristicaEnum Fronte
        {
            get { return fronte; }
            set
            {
                fronte = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }        
        [DisplayName("Occhi")]
        public TipoCaratteristicaEnum Occhi
        {
            get { return occhi; }
            set
            {
                occhi = value;
                OnPropertyChanged();
            }
        }       
        [DisplayName("Denti")]
        public TipoCaratteristicaEnum Denti
        {
            get { return denti; }
            set
            {
                denti = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Collo")]
        public TipoCaratteristicaEnum Collo
        {
            get { return collo; }
            set
            {
                collo = value;
                OnPropertyChanged();
            }
        }        
        [DisplayName("Mento")]
        public TipoCaratteristicaEnum Mento
        {
            get { return mento; }
            set
            {
                mento = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        
    }
}
