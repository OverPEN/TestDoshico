using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Xml;

namespace Data.Services
{
    public  static class DataManager
    {
        private static XmlDocument SavedTests = new XmlDocument();
        private static XmlDocument SavedClienti = new XmlDocument();
        private static readonly string SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TestDoshicoData");
        private static readonly string TestPath = Path.Combine(SavePath, "TestsDoshici.tds");
        private static readonly string ClientiPath = Path.Combine(SavePath, "Clienti.tds");


        static DataManager()
        {
            if (!Directory.Exists(SavePath))
                Directory.CreateDirectory(SavePath);

            if (File.Exists(TestPath))
                SavedTests.Load(TestPath);
            else
            {
                XmlDeclaration xmlTestDeclaration = SavedTests.CreateXmlDeclaration("1.0", "UTF-8", null);
                SavedTests.InsertBefore(xmlTestDeclaration, SavedTests.DocumentElement);
                XmlNode testsParentNode = SavedTests.CreateElement("Tests");
                SavedTests.AppendChild(testsParentNode);
                SavedTests.Save(TestPath);
            }
                

            if (File.Exists(ClientiPath))
                SavedClienti.Load(ClientiPath);
            else
            {
                XmlDeclaration xmlClientiDeclaration = SavedClienti.CreateXmlDeclaration("1.0", "UTF-8", null);
                SavedClienti.InsertBefore(xmlClientiDeclaration, SavedClienti.DocumentElement);
                XmlNode clientiParentNode = SavedClienti.CreateElement("Clienti");
                SavedClienti.AppendChild(clientiParentNode);
                SavedClienti.Save(ClientiPath);
            }
        }

        public static bool WriteClienteToXMLFile(Cliente cliente)
        {
            try
            {
                XmlNode existingClienteNode = SavedClienti.DocumentElement.SelectSingleNode($"{nameof(Cliente)}[@{nameof(Cliente.ID)}='{cliente.ID}']");
                if (existingClienteNode != null)
                {
                    if (MessageServices.ShowYesNoMessage("Salvataggio Cliente", "Cliente già presente nel sistema!" + Environment.NewLine + "Aggiornare il Cliente con i nuovi dati?", MessageBoxResult.Yes))
                    {
                        try
                        {
                            XmlElement newClienteNode = CreateClienteNode(cliente);
                            if(newClienteNode != null)
                            {
                                XmlNode importedClienteNode = SavedClienti.DocumentElement.OwnerDocument.ImportNode(newClienteNode, true);
                                SavedClienti.DocumentElement.ReplaceChild(importedClienteNode, existingClienteNode);
                                SavedClienti.Save(ClientiPath);
                                MessageServices.ShowInformationMessage("Salvataggio Cliente", "Dati Cliente aggiornati!");
                                return true;
                            }
                            else
                            {
                                MessageServices.ShowWarningMessage("Salvataggio Cliente", "Impossibile salvare i dati Cliente!");
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageServices.ShowErrorMessage("Salvataggio Cliente", "Errore nell'aggiornamento dei dati Cliente!", ex);
                            return false;
                        }
                    }
                    else
                    {
                        MessageServices.ShowInformationMessage("Salvataggio Cliente", "Operazione annullata!");
                        return true;
                    }
                }
                else
                {
                    XmlElement newClienteNode = CreateClienteNode(cliente);
                    if(newClienteNode != null)
                    {
                        XmlNode importedClienteNode = SavedClienti.DocumentElement.OwnerDocument.ImportNode(newClienteNode, true);
                        SavedClienti.DocumentElement.AppendChild(importedClienteNode);
                        SavedClienti.Save(ClientiPath);
                    }
                    else
                    {
                        MessageServices.ShowWarningMessage("Salvataggio Cliente", "Impossibile salvare i dati Cliente!");
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageServices.ShowErrorMessage("Salvataggio Cliente", "Errore nel salvataggio del Cliente!", ex);
                return false;
            }
            MessageServices.ShowInformationMessage("Salvataggio Cliente", "Cliente aggiunto al Sistema!");
            return true;
        }

        public static bool WriteTestToXMLFile(Test test)
        {
            try
            {
                XmlNode existingTestNode = SavedTests.DocumentElement.SelectSingleNode($"{nameof(Test)}[@{nameof(Test.ID)}={test.ID}]");
                if (existingTestNode != null)
                {
                    if (MessageServices.ShowYesNoMessage("Salvataggio Test Doshico", "Test già presente nel sistema!" + Environment.NewLine + "Aggiornare il Test con i nuovi dati?", MessageBoxResult.Yes))
                    {
                        try
                        {
                            XmlElement newTest = CreateTestNode(test);
                            if(newTest != null)
                            {
                                XmlNode importedTestNode = SavedTests.DocumentElement.OwnerDocument.ImportNode(newTest, true);
                                SavedTests.DocumentElement.ReplaceChild(importedTestNode, existingTestNode);
                                SavedTests.Save(TestPath);
                                MessageServices.ShowInformationMessage("Salvataggio Test Doshico", "Test Doshico Aggiornato!");
                                return true;
                            }
                            else
                            {
                                MessageServices.ShowWarningMessage("Salvataggio Test Doshico", "Impossibile salvare il Test Doshico!");
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageServices.ShowErrorMessage("Salvataggio Test Doshico", "Errore nell'aggiornamento del Test Doshico!", ex);
                            return false;
                        }
                    }
                    else
                    {
                        MessageServices.ShowInformationMessage("Salvataggio Test Doshico", "Operazione annullata!");
                        return true;
                    }
                }
                else
                {
                    XmlElement testNode = CreateTestNode(test);
                    if(testNode != null)
                    {
                        XmlNode importedTestNode = SavedTests.DocumentElement.OwnerDocument.ImportNode(testNode, true);
                        SavedTests.DocumentElement.AppendChild(importedTestNode);
                        SavedTests.Save(TestPath);
                    }
                    else
                    {
                        MessageServices.ShowWarningMessage("Salvataggio Cliente", "Impossibile salvare i dati Cliente!");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageServices.ShowErrorMessage("Salvataggio Test Doshico", "Errore nel salvataggio del Test Doshico!", ex);
                return false;
            }
            MessageServices.ShowInformationMessage("Salvataggio Test Doshico", "Test Doshico aggiunto al Sistema!");
            return true;
        }

        public static List<Test> GetAllTests()
        {
            List<Test> tests = new List<Test>();

            return tests;
        }

        public static List<Cliente> GetAllClienti()
        {
            List<Cliente> clienti = new List<Cliente>();

            return clienti;
        }

        //public static Test GetTestByID(Guid id)
        //{
        //    return SavedTests.FirstOrDefault(f => f.ID == id);
        //}

        //public static Cliente GetClienteByID(Guid id)
        //{
        //    return SavedClienti.FirstOrDefault(f => f.ID == id);
        //}

        private static XmlElement CreateTestNode(Test test)
        {
            XmlElement testNode = SavedTests.CreateElement(nameof(Test));
            try
            {
                //Assegnazione attributi
                testNode.SetAttribute(nameof(Test.ID), test.ID.ToString());
                testNode.SetAttribute(nameof(Test.IDCliente), test.IDCliente.ToString());
                testNode.SetAttribute(nameof(Test.DataTest), test.DataTest.ToString());

                //Creazione nodo Prakriti
                XmlElement testInnerNode = SavedTests.CreateElement(nameof(Test.QuesitiPrakriti));
                testInnerNode = Prakriti.ToXML(test.QuesitiPrakriti, ref SavedTests, testInnerNode);
                //Creazione nodo Vikriti
                testInnerNode = SavedTests.CreateElement(nameof(Test.QuesitiVikriti));
                testInnerNode = Vikriti.ToXML(test.QuesitiVikriti, ref SavedTests, testInnerNode);
                //Creazione nodo Emozioni
                testInnerNode = SavedTests.CreateElement(nameof(Test.QuesitiEmozioni));
                testInnerNode = Vikriti.ToXML(test.QuesitiEmozioni, ref SavedTests, testInnerNode);
                //Creazione nodo Mente
                testInnerNode = SavedTests.CreateElement(nameof(Test.QuesitiMente));
                testInnerNode = Vikriti.ToXML(test.QuesitiMente, ref SavedTests, testInnerNode);

                //XmlElement quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Accumulo));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Accumulo.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.CapelliFanc));
                //quesitiNode.InnerText = test.QuesitiPrakriti.CapelliFanc.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Collo));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Collo.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Corporatura));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Corporatura.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.CorporaturaFanc));
                //quesitiNode.InnerText = test.QuesitiPrakriti.CorporaturaFanc.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Denti));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Denti.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Fronte));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Fronte.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Mani));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Mani.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Mento));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Mento.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Occhi));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Occhi.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.Pelle));
                //quesitiNode.InnerText = test.QuesitiPrakriti.Pelle.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                //quesitiNode = SavedTests.CreateElement(nameof(Prakriti.StruttOssea));
                //quesitiNode.InnerText = test.QuesitiPrakriti.StruttOssea.ToString();
                //testInnerNode.AppendChild(quesitiNode);

                testNode.AppendChild(testInnerNode);

                return testNode;
            }
            catch(Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore nella serializzazione del Test Doshico!", ex);
                return null;
            }
        }

        private static XmlElement CreateClienteNode(Cliente cliente)
        {
            XmlElement clienteNode = SavedTests.CreateElement(nameof(Cliente));
            try
            {
                //Assegnazione attributi
                clienteNode.SetAttribute(nameof(Cliente.ID), cliente.ID.ToString());
                //Creazione nodo 
                clienteNode = Cliente.ToXML(cliente, ref SavedTests, clienteNode);

                return clienteNode;
            }
            catch (Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore nella serializzazione dei dati Cliente!", ex);
                return null;
            }
        }
    }
}
