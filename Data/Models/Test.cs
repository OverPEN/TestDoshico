using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

        public static async Task<XmlElement> ToXML(Test test, XmlDocument xmlDocument)
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
                    testInnerNode = await Prakriti.ToXML(test.QuesitiPrakriti, xmlDocument, testInnerNode);
                    testNode.AppendChild(testInnerNode);
                    //Creazione nodo Vikriti
                    testInnerNode = xmlDocument.CreateElement(nameof(QuesitiVikriti));
                    testInnerNode = await Vikriti.ToXML(test.QuesitiVikriti, xmlDocument, testInnerNode);
                    testNode.AppendChild(testInnerNode);
                    //Creazione nodo Emozioni
                    testInnerNode = xmlDocument.CreateElement(nameof(QuesitiEmozioni));
                    testInnerNode = await Emozioni .ToXML(test.QuesitiEmozioni, xmlDocument, testInnerNode);
                    testNode.AppendChild(testInnerNode);
                    //Creazione nodo Mente
                    testInnerNode = xmlDocument.CreateElement(nameof(QuesitiMente));
                    testInnerNode = await Mente .ToXML(test.QuesitiMente, xmlDocument, testInnerNode);
                    testNode.AppendChild(testInnerNode);

                    return testNode;
                }
                catch (Exception ex)
                {
                    await MessageServices.ShowErrorMessage("Test Doshico", "Errore nella serializzazione del Test Doshico!", ex);
                    return null;
                }
            }
            else
            {
                await MessageServices.ShowWarningMessage("Test Doshico", "Impossibile serializzare il Test Doshico: Test o Percorso di Salvataggio non validi!");
                return null;
            }
        }

        public static async Task<Test> FromXML(XmlElement testElement)
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
                                    prop.SetValue(test, await Prakriti.FromXML<Prakriti>(testNode as XmlElement));
                                    break;
                                case nameof(QuesitiVikriti):
                                    prop.SetValue(test, await Vikriti.FromXML<Vikriti>(testNode as XmlElement));
                                    break;
                                case nameof(QuesitiMente):
                                    prop.SetValue(test, await Mente.FromXML<Mente>(testNode as XmlElement));
                                    break;
                                case nameof(QuesitiEmozioni):
                                    prop.SetValue(test, await Emozioni.FromXML<Emozioni>(testNode as XmlElement));
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
                    await MessageServices.ShowErrorMessage("Test Doshico", "Errore nella deserializzazione del Test Doshico!", ex);
                    return null;
                }
            }
            else
            {
                await MessageServices.ShowWarningMessage("Test Doshico", "Il Nodo Test è vuoto, impossibile deserializzare!");
                return null;
            }
        }

        public static bool CompareTests(Test test1, Test test2)
        {
            List<PropertyInfo> props = typeof(Test).GetProperties().Where(w => w.PropertyType != typeof(Guid)).ToList();
            foreach (PropertyInfo prop in props)
            {
                if(prop.PropertyType == typeof(DateTime))
                {
                    if (prop.GetValue(test1).ToString() != prop.GetValue(test2).ToString())
                        return false;
                }
                else
                {
                    switch (prop.Name)
                    {
                        case nameof(QuesitiPrakriti):
                            if (!Prakriti.CompareQuesiti(prop.GetValue(test1), prop.GetValue(test2)))
                                return false;
                            break;
                        case nameof(QuesitiVikriti):
                            if (!Prakriti.CompareQuesiti(prop.GetValue(test1), prop.GetValue(test2)))
                                return false;
                            break;
                        case nameof(QuesitiMente):
                            if (!Prakriti.CompareQuesiti(prop.GetValue(test1), prop.GetValue(test2)))
                                return false;
                            break;
                        case nameof(QuesitiEmozioni):
                            if (!Prakriti.CompareQuesiti(prop.GetValue(test1), prop.GetValue(test2)))
                                return false;
                            break;
                    }
                }
            }
            return true;
        }
    }
}
