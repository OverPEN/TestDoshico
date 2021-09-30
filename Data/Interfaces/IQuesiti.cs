using CommonClasses.BaseClasses;
using CommonClasses.Enums;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace Data.Interfaces
{
    public abstract class IQuesiti : BaseNotifyPropertyChanged
    {
        String TotDosha => CalculateTotDosha(this);

        public static String CalculateTotDosha<T>(T quesito)
        {
            int Kcounter = 0;
            int Pcounter = 0;
            int Vcounter = 0;
            List<PropertyInfo> props = typeof(T).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo prop in props)
            {
                switch (prop.GetValue(quesito))
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

        public static XmlElement ToXML<T>(T quesito, ref XmlDocument xmlDocument, XmlElement quesitoInTest)
        {
            try
            {
                XmlElement xmlElement;
                List<PropertyInfo> props = typeof(T).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
                foreach (PropertyInfo prop in props)
                {
                    xmlElement = xmlDocument.CreateElement(prop.Name);
                    xmlElement.InnerText = prop.GetValue(quesito).ToString();
                    quesitoInTest.AppendChild(xmlElement);
                }
            }
            catch(Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore nella serializzazione del Test Doshico!", ex);
            }
                return quesitoInTest;
        }
    }
}
