using CommonClasses.BaseClasses;
using CommonClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        public TipoCaratteristicaEnum Mani
        {
            get { return mani; }
            set
            {
                mani = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum CorporaturaFanc
        {
            get { return corporaturaFanc; }
            set
            {
                corporaturaFanc = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum Accumulo
        {
            get { return accumulo; }
            set
            {
                accumulo = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum Pelle
        {
            get { return pelle; }
            set
            {
                pelle = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum CapelliFanc
        {
            get { return capelliFanc; }
            set
            {
                capelliFanc = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum Fronte
        {
            get { return fronte; }
            set
            {
                fronte = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum Occhi
        {
            get { return occhi; }
            set
            {
                occhi = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum Denti
        {
            get { return denti; }
            set
            {
                denti = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum Collo
        {
            get { return collo; }
            set
            {
                collo = value;
                OnPropertyChanged();
            }
        }
        public TipoCaratteristicaEnum Mento
        {
            get { return mento; }
            set
            {
                mento = value;
                OnPropertyChanged();
            }
        }
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
