using CommonClasses.BaseClasses;
using CommonClasses.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Data.Models
{
    
    public class Prakriti : BaseNotifyPropertyChanged
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

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TipoCaratteristicaEnum Occhi
        {
            get { return occhi; }
            set
            {
                occhi = value;
                OnPropertyChanged();
            }
        }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TipoCaratteristicaEnum Collo
        {
            get { return collo; }
            set
            {
                collo = value;
                OnPropertyChanged();
            }
        }
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
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
        [JsonIgnore]
        public String TotDosha => CalculateTotDosha(this);


        private static String CalculateTotDosha(Prakriti prakriti)
        {
            int Kcounter = 0;
            int Pcounter = 0;
            int Vcounter = 0;
            List<PropertyInfo> props = typeof(Prakriti).GetProperties().Where(w=>w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach(PropertyInfo T in props)
            {
                switch (T.GetValue(prakriti))
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
