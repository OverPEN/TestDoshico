using CommonClasses.BaseClasses;
using Data.Enums;
using Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace Data.Models
{
    public class Cliente : BaseNotifyPropertyChanged
    {
        #region private properties
        private string nomeCognome;
        private int? età;
        private SessoEnum sesso;
        private string costituzione;
        private string squilibrio;
        private string note;
        private string inestetismi;
        #endregion

        public Guid ID { get; set; } = Guid.NewGuid();
        [DisplayName("Nome e Cognome")]
        [Required]
        public string NomeCognome
        {
            get { return nomeCognome; }
            set
            {
                nomeCognome = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Età")]
        [Required]
        public int? Età
        {
            get { return età; }
            set
            {
                età = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Sesso")]
        [Required]
        public SessoEnum Sesso
        {
            get { return sesso; }
            set
            {
                sesso = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Costituzione")]
        [Required]
        public string Costituzione
        {
            get { return costituzione; }
            set
            {
                costituzione = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Squilibrio")]
        public string Squilibrio
        {
            get { return squilibrio; }
            set
            {
                squilibrio = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Note")]
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Inestetismi")]
        public string Inestetismi
        {
            get { return inestetismi; }
            set
            {
                inestetismi = value;
                OnPropertyChanged();
            }
        }

        public static async Task<XmlElement> ToXML(Cliente cliente, XmlDocument xmlDocument)
        {
            if (cliente != null && xmlDocument != null)
            {
                try
                {
                    XmlElement clienteXml = xmlDocument.CreateElement(nameof(Cliente));
                    clienteXml.SetAttribute(nameof(ID), cliente.ID.ToString());

                    XmlElement clienteNode;
                    List<PropertyInfo> props = typeof(Cliente).GetProperties().Where(w => w.PropertyType != typeof(Guid)).ToList();
                    foreach (PropertyInfo prop in props)
                    {
                        clienteNode = xmlDocument.CreateElement(prop.Name);
                        clienteNode.InnerText = prop.GetValue(cliente).ToString();
                        clienteXml.AppendChild(clienteNode);
                    }
                    return clienteXml;
                }
                catch (Exception ex)
                {
                    await MessageServices.ShowErrorMessage("Test Doshico", "Errore nella serializzazione dei dati Cliente!", ex);
                    return null;
                }
            }
            else
            {
                await MessageServices.ShowWarningMessage("Test Doshico", "Impossibile serializzare i Dati Cliente: Cliente o Percorso di Salvataggio non validi!");
                return null;
            }
        }

        public static async Task<Cliente> FromXML(XmlElement clienteElement)
        {
            if (clienteElement != null & clienteElement.HasChildNodes)
            {
                try
                {
                    Cliente cliente = new Cliente() { ID = Guid.Parse(clienteElement.GetAttribute(nameof(ID))) };
                    List<PropertyInfo> props = typeof(Cliente).GetProperties().Where(w => w.PropertyType != typeof(Guid)).ToList();

                    XmlNode clienteNode;
                    foreach (PropertyInfo prop in props)
                    {
                        clienteNode = clienteElement.SelectSingleNode(prop.Name);
                        if (clienteNode != null)
                        {
                            if (prop.PropertyType == typeof(int?))
                                prop.SetValue(cliente, Convert.ToInt32(clienteNode.InnerText));
                            else if (prop.PropertyType == typeof(string))
                                prop.SetValue(cliente, clienteNode.InnerText);
                            else if (prop.PropertyType == typeof(SessoEnum))
                            {
                                SessoEnum sesso = SessoEnum.Selezionare;
                                switch (clienteNode.InnerText)
                                {
                                    case "Maschio":
                                        sesso = SessoEnum.Maschio;
                                        break;
                                    case "Femmina":
                                        sesso = SessoEnum.Femmina;
                                        break;
                                }
                                prop.SetValue(cliente, sesso);
                            }
                        }
                        else
                            prop.SetValue(cliente, null);
                    }
                    return cliente;
                }
                catch (Exception ex)
                {
                    await MessageServices.ShowErrorMessage("Test Doshico", "Errore nella deserializzazione dei dati Cliente!", ex);
                    return null;
                }
            }
            else
            {
                await MessageServices.ShowWarningMessage("Test Doshico", "Nodo Cliente vuoto, impossibile deserializzare!");
                return null;
            }
        }

        public static bool CompareClienti(Cliente cliente1, Cliente cliente2)
        {
            List<PropertyInfo> props = typeof(Cliente).GetProperties().Where(w => w.PropertyType != typeof(Guid)).ToList();
            foreach (PropertyInfo prop in props)
            {
                if (prop.GetValue(cliente1).ToString() != prop.GetValue(cliente2).ToString())
                    return false;
            }
            return true;
        }
    }
}
