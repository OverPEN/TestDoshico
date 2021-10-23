using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace Data.Models
{
    public class Test
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid IDCliente { get; set; }
        public Prakriti QuesitiPrakriti { get; set; }
        public Vikriti QuesitiVikriti { get; set; }
        public Mente QuesitiMente { get; set; }
        public Emozioni QuesitiEmozioni { get; set; }
        public DateTime DataTest { get; set; } = DateTime.Now;

        public static XmlElement ToXML(Test test, ref XmlDocument xmlDocument)
        {
            if(test != null && xmlDocument != null)
            {
                XmlElement testNode = xmlDocument.CreateElement(nameof(Test));
                try
                {
                    //Assegnazione attributi
                    testNode.SetAttribute(nameof(ID), test.ID.ToString());
                    testNode.SetAttribute(nameof(IDCliente), test.IDCliente.ToString());
                    testNode.SetAttribute(nameof(DataTest), test.DataTest.ToString());

                    //Creazione nodo Prakriti
                    XmlElement testInnerNode = xmlDocument.CreateElement(nameof(QuesitiPrakriti));
                    testInnerNode = Prakriti.ToXML(test.QuesitiPrakriti, ref xmlDocument, testInnerNode);
                    testNode.AppendChild(testInnerNode);
                    //Creazione nodo Vikriti
                    testInnerNode = xmlDocument.CreateElement(nameof(QuesitiVikriti));
                    testInnerNode = Vikriti.ToXML(test.QuesitiVikriti, ref xmlDocument, testInnerNode);
                    testNode.AppendChild(testInnerNode);
                    //Creazione nodo Emozioni
                    testInnerNode = xmlDocument.CreateElement(nameof(QuesitiEmozioni));
                    testInnerNode = Emozioni.ToXML(test.QuesitiEmozioni, ref xmlDocument, testInnerNode);
                    testNode.AppendChild(testInnerNode);
                    //Creazione nodo Mente
                    testInnerNode = xmlDocument.CreateElement(nameof(QuesitiMente));
                    testInnerNode = Mente.ToXML(test.QuesitiMente, ref xmlDocument, testInnerNode);
                    testNode.AppendChild(testInnerNode);

                    return testNode;
                }
                catch (Exception ex)
                {
                    MessageServices.ShowErrorMessage("Test Doshico", "Errore nella serializzazione del Test Doshico!", ex);
                    return null;
                }
            }
            else
            {
                MessageServices.ShowWarningMessage("Test Doshico", "Impossibile serializzare il Test Doshico: Test o Percorso di Salvataggio non validi!");
                return null;
            }
        }

        public static Test FromXML(XmlElement testElement)
        {
            if(testElement != null & testElement.HasChildNodes)
            {
                try
                {
                    Test test = new Test() { ID = Guid.Parse(testElement.GetAttribute(nameof(ID))), IDCliente = Guid.Parse(testElement.GetAttribute(nameof(IDCliente))), DataTest = Convert.ToDateTime(testElement.GetAttribute(nameof(DataTest))) };
                    List<PropertyInfo> props = typeof(Test).GetProperties().Where(w => w.PropertyType != typeof(Guid) && w.PropertyType != typeof(DateTime)).ToList();

                    XmlNode testNode;
                    foreach(PropertyInfo prop in props)
                    {
                        testNode = testElement.SelectSingleNode(prop.Name);
                        if (testNode != null)
                        {
                            switch (prop.Name)
                            {
                                case nameof(QuesitiPrakriti):
                                    prop.SetValue(test, Prakriti.FromXML<Prakriti>(testNode as XmlElement));
                                    break;
                                case nameof(QuesitiVikriti):
                                    prop.SetValue(test, Vikriti.FromXML<Vikriti>(testNode as XmlElement));
                                    break;
                                case nameof(QuesitiMente):
                                    prop.SetValue(test, Mente.FromXML<Mente>(testNode as XmlElement));
                                    break;
                                case nameof(QuesitiEmozioni):
                                    prop.SetValue(test, Emozioni.FromXML<Emozioni>(testNode as XmlElement));
                                    break;
                            }
                        }
                        else
                            prop.SetValue(test, null);
                    }
                    return test;
                }
                catch(Exception ex)
                {
                    MessageServices.ShowErrorMessage("Test Doshico", "Errore nella deserializzazione del Test Doshico!", ex);
                    return null;
                }
            }
            else
            {
                MessageServices.ShowWarningMessage("Test Doshico", "Il Nodo Test è vuoto, impossibile deserializzare!");
                return null;
            }
        }
    }
}
