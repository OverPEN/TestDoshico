using CommonClasses.BaseClasses;
using Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace Data.Models
{
    public class Cliente : BaseNotifyPropertyChanged
    {
        #region private properties
        private string nomeCognome;
        private int età;
        private string costituzione;
        private string squilibrio;
        private string note;
        private string inestetismi;
        #endregion

        public Guid ID { get; set; } = Guid.NewGuid();
        [DisplayName("Nome e Cognome")]
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
        public int Età
        {
            get { return età; }
            set
            {
                età = value;
                OnPropertyChanged();
            }
        }
        [DisplayName("Costituzione")]
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

        public static XmlElement ToXML(Cliente cliente, ref XmlDocument xmlDocument, XmlElement quesitoInTest)
        {
            try
            {
                XmlElement xmlElement;
                List<PropertyInfo> props = typeof(Cliente).GetProperties().Where(w=>w.PropertyType != typeof(Guid)).ToList();
                foreach (PropertyInfo prop in props)
                {
                    xmlElement = xmlDocument.CreateElement(prop.Name);
                    xmlElement.InnerText = prop.GetValue(cliente).ToString();
                    quesitoInTest.AppendChild(xmlElement);
                }
            }
            catch (Exception ex)
            {
                MessageServices.ShowErrorMessage("Test Doshico", "Errore nella serializzazione dei dati Cliente!", ex);
            }
            return quesitoInTest;
        }
    }
}
