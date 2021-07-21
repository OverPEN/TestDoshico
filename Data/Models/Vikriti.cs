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
    public class Vikriti : BaseNotifyPropertyChanged
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
        public String TotDosha => CalculateTotDosha(this);


        private static String CalculateTotDosha(Vikriti vikriti)
        {
            int Kcounter = 0;
            int Pcounter = 0;
            int Vcounter = 0;
            List<PropertyInfo> props = typeof(Vikriti).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo T in props)
            {
                switch (T.GetValue(vikriti))
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
