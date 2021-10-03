using Data.Enums;
using Data.Interfaces;
using System.ComponentModel;

namespace Data.Models
{
    public class Vikriti : IQuesiti
    {
        #region Private properties
        private TipoCaratteristicaEnum peso;
        private TipoCaratteristicaEnum temperatura;
        private TipoCaratteristicaEnum tendPelle;
        private TipoCaratteristicaEnum labbra;
        private TipoCaratteristicaEnum capelli;
        private TipoCaratteristicaEnum luoghi;
        private TipoCaratteristicaEnum lingua;
        private TipoCaratteristicaEnum biancoOcchi;
        private TipoCaratteristicaEnum evacuazione;
        private TipoCaratteristicaEnum malattie;
        private TipoCaratteristicaEnum interesseSessuale;
        private TipoCaratteristicaEnum mestruazioni;
        private TipoCaratteristicaEnum cibo;
        private TipoCaratteristicaEnum gengive;
        private TipoCaratteristicaEnum articolazioni;
        #endregion
        [DisplayName("Peso")]
        public TipoCaratteristicaEnum Peso
        {
            get { return peso; }
            set
            {
                peso = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Temperatura")]
        public TipoCaratteristicaEnum Temperatura
        {
            get { return temperatura; }
            set
            {
                temperatura = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Tendenza Pelle")]
        public TipoCaratteristicaEnum TendPelle
        {
            get { return tendPelle; }
            set
            {
                tendPelle = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Labbra")]
        public TipoCaratteristicaEnum Labbra
        {
            get { return labbra; }
            set
            {
                labbra = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Capelli")]
        public TipoCaratteristicaEnum Capelli
        {
            get { return capelli; }
            set
            {
                capelli = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Luoghi")]
        public TipoCaratteristicaEnum Luoghi
        {
            get { return luoghi; }
            set
            {
                luoghi = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Lingua")]
        public TipoCaratteristicaEnum Lingua
        {
            get { return lingua; }
            set
            {
                lingua = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Bianco degli Occhi")]
        public TipoCaratteristicaEnum BiancoOcchi
        {
            get { return biancoOcchi; }
            set
            {
                biancoOcchi = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Evacuazione")]
        public TipoCaratteristicaEnum Evacuazione
        {
            get { return evacuazione; }
            set
            {
                evacuazione = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Malattie")]
        public TipoCaratteristicaEnum Malattie
        {
            get { return malattie; }
            set
            {
                malattie = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Interesse Sessuale")]
        public TipoCaratteristicaEnum InteresseSessuale
        {
            get { return interesseSessuale; }
            set
            {
                interesseSessuale = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Mestruazioni")]
        public TipoCaratteristicaEnum Mestruazioni
        {
            get { return mestruazioni; }
            set
            {
                mestruazioni = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Cibo")]
        public TipoCaratteristicaEnum Cibo
        {
            get { return cibo; }
            set
            {
                cibo = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Gengive")]
        public TipoCaratteristicaEnum Gengive
        {
            get { return gengive; }
            set
            {
                gengive = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Articolazioni")]
        public TipoCaratteristicaEnum Articolazioni
        {
            get { return articolazioni; }
            set
            {
                articolazioni = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
    }
}
