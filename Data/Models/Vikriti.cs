using Data.Enums;
using Data.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
        [Required]
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
