using CommonClasses.BaseClasses;
using System;
using System.Collections.Generic;
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

        public string NomeCognome
        {
            get { return nomeCognome; }
            set
            {
                nomeCognome = value;
                OnPropertyChanged();
            }
        }
        public int Età
        {
            get { return età; }
            set
            {
                età = value;
                OnPropertyChanged();
            }
        }
        public string Costituzione
        {
            get { return costituzione; }
            set
            {
                costituzione = value;
                OnPropertyChanged();
            }
        }
        public string Squilibrio
        {
            get { return squilibrio; }
            set
            {
                squilibrio = value;
                OnPropertyChanged();
            }
        }
        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                OnPropertyChanged();
            }
        }
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
