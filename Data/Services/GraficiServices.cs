using CommonClasses.Enums;
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
    }
}
