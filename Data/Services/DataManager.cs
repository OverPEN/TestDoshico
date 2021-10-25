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
                    Cliente existingCliente = Cliente.FromXML(existingClienteNode as XmlElement);
                    if (!Cliente.CompareClienti(existingCliente, cliente))
                    {
                        if (MessageServices.ShowYesNoMessage("Salvataggio Cliente", "Cliente già presente nel sistema!" + Environment.NewLine + "Aggiornare il Cliente con i nuovi dati?", MessageBoxResult.Yes))
                        {
                            try
                            {
                                XmlElement newClienteNode = Cliente.ToXML(cliente, ref SavedClienti);
                                if (newClienteNode != null)
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
                            MessageServices.ShowInformationMessage("Salvataggio Cliente", "Dati non aggiornati!");
                            return true;
                        }
                    }
                    else
                        return true;
                }
                else
                {
                    XmlElement newClienteNode = Cliente.ToXML(cliente, ref SavedClienti);
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
                XmlNode existingTestNode = SavedTests.DocumentElement.SelectSingleNode($"{nameof(Test)}[@{nameof(Test.ID)}='{test.ID}']");
                if (existingTestNode != null)
                {
                    if (MessageServices.ShowYesNoMessage("Salvataggio Test Doshico", "Test già presente nel sistema!" + Environment.NewLine + "Aggiornare il Test con i nuovi dati?", MessageBoxResult.Yes))
                    {
                        try
                        {
                            XmlElement newTest = Test.ToXML(test, ref SavedTests);
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
                    XmlElement testNode = Test.ToXML(test, ref SavedTests);
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
            Test test;
            foreach(XmlElement testElement in SavedTests.DocumentElement.SelectNodes(nameof(Test)))
            {
                test = Test.FromXML(testElement);
                if (test != null)
                    tests.Add(test);
            }

            return tests;
        }

        public static List<Cliente> GetAllClienti()
        {
            List<Cliente> clienti = new List<Cliente>();
            Cliente cliente;
            foreach(XmlElement clienteElement in SavedClienti.DocumentElement.SelectNodes(nameof(Cliente)))
            {
                cliente = Cliente.FromXML(clienteElement);
                if (cliente != null)
                    clienti.Add(cliente);
            }

            return clienti;
        }

        public static Test GetTestByID(Guid id)
        {
            return Test.FromXML(SavedTests.DocumentElement.SelectSingleNode($"{nameof(Test)}[@{nameof(Test.ID)}='{id}']") as XmlElement);
        }

        public static Cliente GetClienteByID(Guid id)
        {
            return Cliente.FromXML(SavedClienti.DocumentElement.SelectSingleNode($"{nameof(Cliente)}[@{nameof(Cliente.ID)}='{id}']") as XmlElement);
        }

        public static void EliminaClienteByID(Guid id)
        {
            SavedClienti.DocumentElement.RemoveChild(SavedClienti.DocumentElement.SelectSingleNode($"{nameof(Cliente)}[@{nameof(Cliente.ID)}='{id}']"));
            SavedClienti.Save(ClientiPath);
            if(MessageServices.ShowYesNoMessage("Test Doshico", "Eliminare tutti i Test Doshici effettuati dal Cliente?", MessageBoxResult.No))
            {
                XmlNodeList lstNodi = SavedTests.DocumentElement.SelectNodes($"{nameof(Test)}[@{nameof(Test.IDCliente)}='{id}']");
                foreach(XmlNode nodo in lstNodi)
                {
                    SavedTests.DocumentElement.RemoveChild(nodo);
                }
                SavedTests.Save(TestPath);
                MessageServices.ShowInformationMessage("Test Doshico", "Test Doshici per il Cliente selezionato eliminati!");
            }
        }

        public static void EliminaTestByID(Guid id)
        {
            SavedTests.DocumentElement.RemoveChild(SavedTests.DocumentElement.SelectSingleNode($"{nameof(Test)}[@{nameof(Test.ID)}='{id}']"));
            SavedTests.Save(TestPath);
        }
    }
}
