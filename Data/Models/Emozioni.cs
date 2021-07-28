using CommonClasses.BaseClasses;
using CommonClasses.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Data.Models
{
    public class Emozioni : BaseNotifyPropertyChanged
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonIgnore]
        public String TotDosha => CalculateTotDosha(this);


        private static String CalculateTotDosha(Emozioni emozioni)
        {
            int Kcounter = 0;
            int Pcounter = 0;
            int Vcounter = 0;
            List<PropertyInfo> props = typeof(Emozioni).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo T in props)
            {
                switch (T.GetValue(emozioni))
                {
                    case TipoCaratteristicaEnum.Kapha:
                        Kcounter++;
                        break;
                    case TipoCaratteristicaEnum.Pitta:
                        Pcounter++;
                        break;
                    case TipoCaratteristicaEnum.Vata:
                        Vcounter++;
                        break;
                }
            }
            return $"Kapha: {Kcounter}\t Pitta: {Pcounter}\t Vata: {Vcounter}";
        }
    }
}
