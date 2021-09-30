using CommonClasses.Enums;
using Data.Interfaces;
using System.ComponentModel;

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
