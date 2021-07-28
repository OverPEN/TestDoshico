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
        private static readonly string TestPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Tests.json";
        private static readonly string Clientipath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Clienti.json";


        static DataManager()
        {
            if (File.Exists(TestPath))
            {
                SavedTests = JsonConvert.DeserializeObject<List<Test>>(File.ReadAllText(TestPath));
            }

            if (File.Exists(Clientipath))
            {
                SavedClienti = JsonConvert.DeserializeObject<List<Cliente>>(File.ReadAllText(Clientipath));
            }
        }


        public static bool WriteTestToJsonFile(Test test)
        {
            try
            {
                if(SavedTests.Exists(e=>e.ID == test.ID))
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Test già presente nel sistema!" + Environment.NewLine + "Aggiornare il Test con i nuovi dati?", "Salvataggio Test Doshico", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if(result == MessageBoxResult.Yes)
                    {
                        Test t = SavedTests.FirstOrDefault(f => f.ID == test.ID);
                        try
                        {
                            SavedTests.Remove(t);
                            SavedTests.Add(test);
                            File.WriteAllText(TestPath, JsonConvert.SerializeObject(SavedTests, settings));
                            Xceed.Wpf.Toolkit.MessageBox.Show("Test Doshico Aggiornato!", "Salvataggio Test Doshico", MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                        }
                        catch(Exception ex)
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Errore nell'aggiornamento del Test Doshico!" + Environment.NewLine + ex.Message, "Salvataggio Test Doshico", MessageBoxButton.OK, MessageBoxImage.Error);
                            SavedTests.Remove(test);
                            SavedTests.Add(t);
                            return false;
                        }
                        
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Operazione annullata!", "Salvataggio Test Doshico", MessageBoxButton.OK, MessageBoxImage.Information);
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
                Xceed.Wpf.Toolkit.MessageBox.Show("Errore nel salvataggio del Test Doshico!" + Environment.NewLine + ex.Message, "Salvataggio Test Doshico", MessageBoxButton.OK, MessageBoxImage.Error);
                SavedTests.Remove(test);
                return false;
            }
            Xceed.Wpf.Toolkit.MessageBox.Show("Test Doshico aggiunto al Sistema!", "Salvataggio Test Doshico", MessageBoxButton.OK, MessageBoxImage.Information);
            return true;
        }

        public static bool WriteClienteToJsonFile(Cliente cliente)
        {
            try
            {
                if (SavedClienti.Exists(e => e.ID == cliente.ID))
                {
                    MessageBoxResult result = Xceed.Wpf.Toolkit.MessageBox.Show("Cliente già presente nel sistema!" + Environment.NewLine + "Aggiornare il Cliente con i nuovi dati?", "Salvataggio Cliente", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        Cliente c = SavedClienti.FirstOrDefault(f => f.ID == cliente.ID);
                        try
                        {
                            SavedClienti.Remove(c);
                            SavedClienti.Add(cliente);
                            File.WriteAllText(Clientipath, JsonConvert.SerializeObject(SavedClienti, settings));
                            Xceed.Wpf.Toolkit.MessageBox.Show("Dati Cliente aggiornati!", "Salvataggio Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                            return true;
                        }
                        catch (Exception ex)
                        {
                            Xceed.Wpf.Toolkit.MessageBox.Show("Errore nell'aggiornamento dei dati Cliente!" + Environment.NewLine + ex.Message, "Salvataggio Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                            SavedClienti.Remove(cliente);
                            SavedClienti.Add(c);
                            return false;
                        }

                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("Operazione annullata!", "Salvataggio Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
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
                Xceed.Wpf.Toolkit.MessageBox.Show("Errore nel salvataggio del Cliente!" + Environment.NewLine + ex.Message, "Salvataggio Cliente", MessageBoxButton.OK, MessageBoxImage.Error);
                SavedClienti.Remove(cliente);
                return false;
            }
            Xceed.Wpf.Toolkit.MessageBox.Show("Cliente aggiunto al Sistema!", "Salvataggio Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
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
