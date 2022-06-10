using Data.Enums;
using Data.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Mente : IQuesiti
    {
        #region Private properties
        private TipoCaratteristicaEnum memoria;
        private TipoCaratteristicaEnum routine;
        private TipoCaratteristicaEnum decisioni;
        private TipoCaratteristicaEnum carattere;
        private TipoCaratteristicaEnum pensiero;
        private TipoCaratteristicaEnum organizzazione;
        private TipoCaratteristicaEnum amicizia;
        private TipoCaratteristicaEnum denaro;
        #endregion
        [DisplayName("Memoria")]
        [Required]
        public TipoCaratteristicaEnum Memoria
        {
            get { return memoria; }
            set
            {
                memoria = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Rotuine")]
        [Required]
        public TipoCaratteristicaEnum Routine
        {
            get { return routine; }
            set
            {
                routine = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Decisioni")]
        [Required]
        public TipoCaratteristicaEnum Decisioni
        {
            get { return decisioni; }
            set
            {
                decisioni = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Carattere")]
        [Required]
        public TipoCaratteristicaEnum Carattere
        {
            get { return carattere; }
            set
            {
                carattere = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Pensiero")]
        [Required]
        public TipoCaratteristicaEnum Pensiero
        {
            get { return pensiero; }
            set
            {
                pensiero = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Organizzazione")]
        [Required]
        public TipoCaratteristicaEnum Organizzazione
        {
            get { return organizzazione; }
            set
            {
                organizzazione = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Amicizia")]
        [Required]
        public TipoCaratteristicaEnum Amicizia
        {
            get { return amicizia; }
            set
            {
                amicizia = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Denaro")]
        [Required]
        public TipoCaratteristicaEnum Denaro
        {
            get { return denaro; }
            set
            {
                denaro = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
    }
}
