using CommonClasses.Enums;
using CommonClasses.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;

namespace Data.Models
{
    public class Mente : BaseNotifyPropertyChanged
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonIgnore]
        public String TotDosha => CalculateTotDosha(this);


        private static String CalculateTotDosha(Mente mente)
        {
            int Kcounter = 0;
            int Pcounter = 0;
            int Vcounter = 0;
            List<PropertyInfo> props = typeof(Mente).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo T in props)
            {
                switch (T.GetValue(mente))
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
