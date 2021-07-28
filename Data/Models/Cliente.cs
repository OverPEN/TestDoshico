using CommonClasses.BaseClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [JsonRequired]
        public Guid ID { get; set; } = Guid.NewGuid();
        [JsonProperty]
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
        [JsonProperty]
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
        [JsonProperty]
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
        [JsonProperty]
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
        [JsonProperty]
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
        [JsonProperty]
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
    }
}
