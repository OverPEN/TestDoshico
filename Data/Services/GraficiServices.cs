using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Data.Services
{
    public static class GraficiServices
    {
        public static List<KeyValuePair<String, int>> GetDatiForGrafico<T>(T datiQuesiti)
        {
            int Kcounter = 0;
            int Pcounter = 0;
            int Vcounter = 0;

            List<PropertyInfo> props = typeof(T).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo p in props)
            {
                switch (p.GetValue(datiQuesiti))
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
            return new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>(TipoCaratteristicaEnum.Kapha.ToString(), Kcounter), new KeyValuePair<string, int>(TipoCaratteristicaEnum.Pitta.ToString(), Pcounter), new KeyValuePair<string, int>(TipoCaratteristicaEnum.Vata.ToString(), Vcounter) };
        }

        public static List<KeyValuePair<String, int>> GetDatiComplessiviForGrafico(Models.Test test)
        {
            List<KeyValuePair<String, int>> lstTemp = new List<KeyValuePair<String, int>>();
            int Kcounter = 0;
            int Pcounter = 0;
            int Vcounter = 0;

            lstTemp = GetDatiForGrafico(test?.QuesitiPrakriti);
            Vcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Vata.ToString()).Value;
            Pcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Pitta.ToString()).Value;
            Kcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Kapha.ToString()).Value;
            lstTemp = GetDatiForGrafico(test?.QuesitiVikriti);
            Vcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Vata.ToString()).Value;
            Pcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Pitta.ToString()).Value;
            Kcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Kapha.ToString()).Value;
            lstTemp = GetDatiForGrafico(test?.QuesitiMente);
            Vcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Vata.ToString()).Value;
            Pcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Pitta.ToString()).Value;
            Kcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Kapha.ToString()).Value;
            lstTemp = GetDatiForGrafico(test?.QuesitiEmozioni);
            Vcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Vata.ToString()).Value;
            Pcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Pitta.ToString()).Value;
            Kcounter += lstTemp.FirstOrDefault(f => f.Key == TipoCaratteristicaEnum.Kapha.ToString()).Value;

            return new List<KeyValuePair<string, int>> { new KeyValuePair<string, int>(TipoCaratteristicaEnum.Kapha.ToString(), Kcounter), new KeyValuePair<string, int>(TipoCaratteristicaEnum.Pitta.ToString(), Pcounter), new KeyValuePair<string, int>(TipoCaratteristicaEnum.Vata.ToString(), Vcounter) };
        }
    }
}
