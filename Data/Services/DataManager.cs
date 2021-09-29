using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;


namespace Data.Services
{
    public  static class DataManager
    {
        private static readonly List<Test> SavedTests = new List<Test>();
        private static readonly List<Cliente> SavedClienti = new List<Cliente>();
        private static JsonSerializerSettings settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Objects };
        private static readonly string SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TestDoshicoData");
        private static readonly string TestPath = Path.Combine(SavePath, "Tests.json");
        private static readonly string Clientipath = Path.Combine(SavePath, "Clienti.json");


        static DataManager()
        {
            if (!Directory.Exists(SavePath))
                Directory.CreateDirectory(SavePath);

            if (File.Exists(TestPath))
                SavedTests = JsonConvert.DeserializeObject<List<Test>>(File.ReadAllText(TestPath));

            if (File.Exists(Clientipath))
                SavedClienti = JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText(Clientipath));
        }


        public static bool WriteTestToJsonFile(Test test)
        {
            try
            {
                if(SavedTests.Exists(e=>e.ID == test.ID))
                {
                    if(MessageServices.ShowYesNoMessage("Salvataggio Test Doshico", "Test già presente nel sistema!" + Environment.NewLine + "Aggiornare il Test con i nuovi dati?", MessageBoxResult.Yes))
                    {
                        Test t = SavedTests.FirstOrDefault(f => f.ID == test.ID);
                        try
                        {
                            SavedTests.Remove(t);
                            SavedTests.Add(test);
                            File.WriteAllText(TestPath, JsonConvert.SerializeObject(SavedTests, settings));
                            MessageServices.ShowInformationMessage("Salvataggio Test Doshico", "Test Doshico Aggiornato!");
                            return true;
                        }
                        catch(Exception ex)
                        {
                            MessageServices.ShowErrorMessage("Salvataggio Test Doshico", "Errore nell'aggiornamento del Test Doshico!", ex);
                            SavedTests.Remove(test);
                            SavedTests.Add(t);
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
                    SavedTests.Add(test);
                    File.WriteAllText(TestPath, JsonConvert.SerializeObject(SavedTests, settings));
                }
                

            }
            catch (Exception ex)
            {
                MessageServices.ShowErrorMessage("Salvataggio Test Doshico", "Errore nel salvataggio del Test Doshico!", ex);
                SavedTests.Remove(test);
                return false;
            }
            MessageServices.ShowInformationMessage("Salvataggio Test Doshico", "Test Doshico aggiunto al Sistema!");
            return true;
        }

        public static bool WriteClienteToJsonFile(Cliente cliente)
        {
            try
            {
                if (SavedClienti.Exists(e => e.ID == cliente.ID))
                {
                    if (MessageServices.ShowYesNoMessage("Salvataggio Cliente", "Cliente già presente nel sistema!" + Environment.NewLine + "Aggiornare il Cliente con i nuovi dati?", MessageBoxResult.Yes))
                    {
                        Cliente c = SavedClienti.FirstOrDefault(f => f.ID == cliente.ID);
                        try
                        {
                            SavedClienti.Remove(c);
                            SavedClienti.Add(cliente);
                            File.WriteAllText(Clientipath, JsonConvert.SerializeObject(SavedClienti, settings));
                            MessageServices.ShowInformationMessage("Salvataggio Cliente", "Dati Cliente aggiornati!");
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageServices.ShowErrorMessage("Salvataggio Cliente", "Errore nell'aggiornamento dei dati Cliente!", ex);
                            SavedClienti.Remove(cliente);
                            SavedClienti.Add(c);
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
                    SavedClienti.Add(cliente);
                    File.WriteAllText(Clientipath, JsonConvert.SerializeObject(SavedClienti, settings));
                }
                
            }
            catch (Exception ex)
            {
                MessageServices.ShowErrorMessage("Salvataggio Cliente", "Errore nel salvataggio del Cliente!", ex);
                SavedClienti.Remove(cliente);
                return false;
            }
            MessageServices.ShowInformationMessage("Salvataggio Cliente", "Cliente aggiunto al Sistema!");
            return true;
        }

        public static List<Test> GetAllTests()
        {
            return SavedTests;
        }

        public static List<Cliente> GetAllClienti()
        {
            return SavedClienti;
        }

        public static Test GetTestByID(Guid id)
        {
            return SavedTests.FirstOrDefault(f => f.ID == id);
        }

        public static Cliente GetClienteByID(Guid id)
        {
            return SavedClienti.FirstOrDefault(f => f.ID == id);
        }
    }
}
