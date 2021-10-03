using CommonClasses.BaseClasses;
using Data.Enums;
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
            if(quesito != null && xmlDocument != null && quesitoInTest != null)
            {
                try
                {
                    XmlElement xmlElement;
                    List<PropertyInfo> props = typeof(T).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
                    foreach (PropertyInfo prop in props)
                    {
                        xmlElement = xmlDocument.CreateElement(prop.Name);
                        xmlElement.InnerText = prop.GetValue(quesito) != null ? prop.GetValue(quesito).ToString() : String.Empty;
                        quesitoInTest.AppendChild(xmlElement);
                    }
                }
                catch (Exception ex)
                {
                    MessageServices.ShowErrorMessage("Test Doshico", $"Errore nella serializzazione del Test Doshico nei quesiti {typeof(T).Name}!", ex);
                }
            }
            else
            {
                MessageServices.ShowWarningMessage("Test Doshico", "Impossibile serializzare il Test Doshico: Test o Percorso di Salvataggio non validi!");
                return null;
            }
            return quesitoInTest;
        }

        public static T FromXML<T>(XmlElement quesitoElement)
        {
            if(quesitoElement != null & quesitoElement.HasChildNodes)
            {
                try
                {
                    T quesito = (T)Activator.CreateInstance(typeof(T));
                    List<PropertyInfo> props = typeof(T).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();

                    XmlNode quesitoNode;
                    foreach (PropertyInfo prop in props)
                    {
                        quesitoNode = quesitoElement.SelectSingleNode(prop.Name);
                        TipoCaratteristicaEnum quesitoValore = TipoCaratteristicaEnum.Selezionare;

                        switch (quesitoNode.InnerText)
                        {
                            case "Vata":
                                quesitoValore = TipoCaratteristicaEnum.Vata;
                                break;
                            case "Pitta":
                                quesitoValore = TipoCaratteristicaEnum.Pitta;
                                break;
                            case "Kapha":
                                quesitoValore = TipoCaratteristicaEnum.Kapha;
                                break;
                        }
                        prop.SetValue(quesito, quesitoValore);
                    }
                    return quesito;
                }
                catch (Exception ex)
                {
                    MessageServices.ShowErrorMessage("Test Doshico", $"Errore nella deserializzazione dei quesiti {nameof(T)}!", ex);
                    return default;
                }
            }
            else
            {
                MessageServices.ShowWarningMessage("Test Doshico", $"Nodo Quesiti {quesitoElement.Name} vuoto, impossibile deserializzare!");
                return default;
            }
        }

        public override string ToString()
        {
            return TotDosha;
        }
    }
}
