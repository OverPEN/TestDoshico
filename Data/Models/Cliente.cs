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
        public string NomeCognome { get; set; }
        public int Età { get; set; }
        public string Costituzione { get; set; }
        public string Squilibrio { get; set; }
        public string Note { get; set; }
        public string Inestetismi { get; set; }
    }
}
