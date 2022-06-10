using Data.Enums;
using Data.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Emozioni : IQuesiti
    {
        #region Private properties
        private TipoCaratteristicaEnum sentimento;
        private TipoCaratteristicaEnum indole;
        private TipoCaratteristicaEnum istinto;
        private TipoCaratteristicaEnum reazStress;
        private TipoCaratteristicaEnum vizio;
        private TipoCaratteristicaEnum tendEmozionale;
        private TipoCaratteristicaEnum virtù;
        private TipoCaratteristicaEnum gestioneEmozioni;
        private TipoCaratteristicaEnum puntoDiForza;
        private TipoCaratteristicaEnum reazione;
        private TipoCaratteristicaEnum sogni;
        #endregion
        [DisplayName("Sentimento")]
        [Required]
        public TipoCaratteristicaEnum Sentimento
        {
            get { return sentimento; }
            set
            {
                sentimento = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Indole")]
        [Required]
        public TipoCaratteristicaEnum Indole
        {
            get { return indole; }
            set
            {
                indole = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Istinto")]
        [Required]
        public TipoCaratteristicaEnum Istinto
        {
            get { return istinto; }
            set
            {
                istinto = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Reazione allo Stress")]
        [Required]
        public TipoCaratteristicaEnum ReazStress
        {
            get { return reazStress; }
            set
            {
                reazStress = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Vizio")]
        [Required]
        public TipoCaratteristicaEnum Vizio
        {
            get { return vizio; }
            set
            {
                vizio = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Tendenza Emozionale")]
        [Required]
        public TipoCaratteristicaEnum TendEmozionale
        {
            get { return tendEmozionale; }
            set
            {
                tendEmozionale = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Virtù")]
        [Required]
        public TipoCaratteristicaEnum Virtù
        {
            get { return virtù; }
            set
            {
                virtù = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Gestione Emozioni")]
        [Required]
        public TipoCaratteristicaEnum GestioneEmozioni
        {
            get { return gestioneEmozioni; }
            set
            {
                gestioneEmozioni = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Punti di Forza")]
        [Required]
        public TipoCaratteristicaEnum PuntoDiForza
        {
            get { return puntoDiForza; }
            set
            {
                puntoDiForza = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Reazione")]
        [Required]
        public TipoCaratteristicaEnum Reazione
        {
            get { return reazione; }
            set
            {
                reazione = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
        [DisplayName("Sogni")]
        [Required]
        public TipoCaratteristicaEnum Sogni
        {
            get { return sogni; }
            set
            {
                sogni = value;
                OnPropertyChanged();
                OnPropertyChanged("TotDosha");
            }
        }
    }
}
