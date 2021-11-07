using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

        public static async Task<bool> WriteClienteToXMLFile(Cliente cliente)
        {
            try
            {
                XmlNode existingClienteNode = SavedClienti.DocumentElement.SelectSingleNode($"{nameof(Cliente)}[@{nameof(Cliente.ID)}='{cliente.ID}']");
                if (existingClienteNode != null)
                {
                    Cliente existingCliente = await Cliente .FromXML(existingClienteNode as XmlElement);
                    if (!Cliente.CompareClienti(existingCliente, cliente))
                    {
                        if (await MessageServices.ShowYesNoMessage("Salvataggio Cliente", $"Cliente {cliente.NomeCognome} già presente nel sistema!" + Environment.NewLine + "Aggiornare le informazioni con i nuovi dati?", ModernWpf.Controls.ContentDialogButton.Close))
                        {
                            try
                            {
                                if(await AggiornaClienteInternal(cliente, existingClienteNode))
                                {
                                    await MessageServices.ShowInformationMessage("Salvataggio Cliente", $"Dati Cliente di {cliente.NomeCognome} aggiornati!");
                                    return true;
                                }
                                else
                                {
                                    await MessageServices.ShowWarningMessage("Salvataggio Cliente", $"Errore durante l'aggiornamento dei dati Cliente di {cliente.NomeCognome}!");
                                    return false;
                                }
                            }
                            catch (Exception ex)
                            {
                                await MessageServices.ShowErrorMessage("Salvataggio Cliente", $"Errore grave durante l'aggiornamento dei dati Cliente di {cliente.NomeCognome}!", ex);
                                return false;
                            }
                        }
                        else
                        {
                            await MessageServices.ShowInformationMessage("Salvataggio Cliente", $"Dati Cliente di {cliente.NomeCognome} non aggiornati!");
                            return true;
                        }
                    }
                    else
                        return true;
                }
                else
                {
                    XmlElement newClienteNode = await Cliente.ToXML(cliente, SavedClienti);
                    if(newClienteNode != null)
                    {
                        XmlNode importedClienteNode = SavedClienti.DocumentElement.OwnerDocument.ImportNode(newClienteNode, true);
                        SavedClienti.DocumentElement.AppendChild(importedClienteNode);
                        SavedClienti.Save(ClientiPath);
                        await MessageServices.ShowInformationMessage("Salvataggio Cliente", $"Cliente {cliente.NomeCognome} aggiunto al Sistema!");
                    }
                    else
                    {
                        await MessageServices.ShowWarningMessage("Salvataggio Cliente", $"Errore durante l'aggiornamento dei dati Cliente di {cliente.NomeCognome}!");
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Salvataggio Cliente", $"Errore grave durante l'aggiornamento dei dati Cliente di {cliente.NomeCognome}!", ex);
                return false;
            }
            return true;
        }

        public static async Task<bool> WriteTestToXMLFile(Test test)
        {
            try
            {
                XmlNode existingTestNode = SavedTests.DocumentElement.SelectSingleNode($"{nameof(Test)}[@{nameof(Test.ID)}='{test.ID}']");
                if (existingTestNode != null)
                {
                    Test existingTest = await Test.FromXML(existingTestNode as XmlElement);
                    if (!Test.CompareTests(existingTest, test))
                    {
                        if (await MessageServices.ShowYesNoMessage("Salvataggio Test Doshico", "Test già presente nel sistema!" + Environment.NewLine + "Aggiornare il Test con i nuovi dati?", ModernWpf.Controls.ContentDialogButton.Close))
                        {
                            try
                            {
                                if (await AggiornaTestInternal (test, existingTestNode))
                                {
                                    await MessageServices.ShowInformationMessage("Salvataggio Test Doshico", "Test Doshico Aggiornato!");
                                    return true;
                                }
                                else
                                {
                                    await MessageServices.ShowWarningMessage("Salvataggio Test Doshico", "Impossibile salvare il Test Doshico!");
                                    return false;
                                }
                            }
                            catch (Exception ex)
                            {
                                await MessageServices.ShowErrorMessage("Salvataggio Test Doshico", "Errore nell'aggiornamento del Test Doshico!", ex);
                                return false;
                            }
                        }
                        else
                        {
                            await MessageServices.ShowInformationMessage("Salvataggio Test Doshico", "Operazione annullata!");
                            return true;
                        }
                    }
                    else
                        return true;
                }
                else
                {
                    XmlElement testNode = await Test .ToXML(test, SavedTests);
                    if(testNode != null)
                    {
                        XmlNode importedTestNode = SavedTests.DocumentElement.OwnerDocument.ImportNode(testNode, true);
                        SavedTests.DocumentElement.AppendChild(importedTestNode);
                        SavedTests.Save(TestPath);
                    }
                    else
                    {
                        await MessageServices.ShowWarningMessage("Salvataggio Cliente", "Impossibile salvare i dati Cliente!");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Salvataggio Test Doshico", "Errore nel salvataggio del Test Doshico!", ex);
                return false;
            }
            await MessageServices.ShowInformationMessage("Salvataggio Test Doshico", "Test Doshico aggiunto al Sistema!");
            return true;
        }

        public static async Task<List<Test>> GetAllTests()
        {
            List<Test> tests = new List<Test>();
            Test test;
            foreach(XmlElement testElement in SavedTests.DocumentElement.SelectNodes(nameof(Test)))
            {
                test = await Test.FromXML(testElement);
                if (test != null)
                    tests.Add(test);
            }

            return tests;
        }

        public static async Task<List<Cliente>> GetAllClienti()
        {
            List<Cliente> clienti = new List<Cliente>();
            Cliente cliente;
            foreach(XmlElement clienteElement in SavedClienti.DocumentElement.SelectNodes(nameof(Cliente)))
            {
                cliente = await Cliente.FromXML(clienteElement);
                if (cliente != null)
                    clienti.Add(cliente);
            }

            return clienti;
        }

        public static async Task<Test> GetTestByID(Guid id)
        {
            return await Test.FromXML(SavedTests.DocumentElement.SelectSingleNode($"{nameof(Test)}[@{nameof(Test.ID)}='{id}']") as XmlElement);
        }

        public static async Task<Cliente> GetClienteByID(Guid id)
        {
            return await Cliente.FromXML(SavedClienti.DocumentElement.SelectSingleNode($"{nameof(Cliente)}[@{nameof(Cliente.ID)}='{id}']") as XmlElement);
        }

        public static async void EliminaClienteByID(Guid id)
        {
            Cliente cliente = new Cliente();
            try
            {
                cliente = await GetClienteByID(id);
                if(cliente != null)
                {
                    SavedClienti.DocumentElement.RemoveChild(SavedClienti.DocumentElement.SelectSingleNode($"{nameof(Cliente)}[@{nameof(Cliente.ID)}='{id}']"));
                    SavedClienti.Save(ClientiPath);

                    XmlNodeList lstNodiTest = SavedTests.DocumentElement.SelectNodes($"{nameof(Test)}[@{nameof(Test.IDCliente)}='{id}']");
                    if(lstNodiTest.Count > 0)
                    {
                        if (await MessageServices.ShowYesNoMessage("Test Doshico", $"Eliminare tutti i Test Doshici effettuati dal Cliente {cliente.NomeCognome}?", ModernWpf.Controls.ContentDialogButton.Close))
                        {
                            foreach (XmlNode nodo in lstNodiTest)
                            {
                                EliminaTestByID(Guid.Parse(nodo.Attributes[nameof(Test.ID)].Value));
                            }
                            SavedTests.Save(TestPath);
                            await MessageServices.ShowInformationMessage("Test Doshico", $"Test Doshici per il Cliente {cliente.NomeCognome} eliminati!");
                        }
                    }
                    await MessageServices.ShowInformationMessage("Test Doshico", $"Cliente {cliente.NomeCognome} eliminato!");
                }
            }
            catch(Exception ex)
            {
                await MessageServices.ShowErrorMessage("TestDoshico", $"Errore grave durante l'eliminazione del Cliente {cliente.NomeCognome}!", ex);
            }
        }

        public static void EliminaTestByID(Guid id)
        {
            SavedTests.DocumentElement.RemoveChild(SavedTests.DocumentElement.SelectSingleNode($"{nameof(Test)}[@{nameof(Test.ID)}='{id}']"));
            SavedTests.Save(TestPath);
        }

        public static async Task<bool> AggiornaCliente(Cliente cliente)
        {
            XmlNode existingClienteNode = SavedClienti.DocumentElement.SelectSingleNode($"{nameof(Cliente)}[@{nameof(Cliente.ID)}='{cliente.ID}']");
            return await AggiornaClienteInternal(cliente, existingClienteNode);
        }

        private static async Task<bool> AggiornaClienteInternal(Cliente cliente, XmlNode existingClienteNode)
        {
                XmlElement newClienteNode = await Cliente.ToXML(cliente, SavedClienti);
                if (newClienteNode != null)
                {
                    XmlNode importedClienteNode = SavedClienti.DocumentElement.OwnerDocument.ImportNode(newClienteNode, true);
                    SavedClienti.DocumentElement.ReplaceChild(importedClienteNode, existingClienteNode);
                    SavedClienti.Save(ClientiPath);
                    return true;
                }
                else
                    return false;
        }

        public static async Task<bool> AggiornaTest(Test test)
        {
            XmlNode existingTestNode = SavedTests.DocumentElement.SelectSingleNode($"{nameof(Test)}[@{nameof(Test.ID)}='{test.ID}']");
            return await AggiornaTestInternal(test, existingTestNode);
        }

        private static async Task<bool> AggiornaTestInternal(Test test, XmlNode existingTestNode)
        {
            XmlElement newTestNode = await Test.ToXML(test, SavedTests);
            if (newTestNode != null)
            {
                XmlNode importedTestNode = SavedTests.DocumentElement.OwnerDocument.ImportNode(newTestNode, true);
                SavedTests.DocumentElement.ReplaceChild(importedTestNode, existingTestNode);
                SavedTests.Save(TestPath);
                return true;
            }
            else
                return false;
        }
    }
}
