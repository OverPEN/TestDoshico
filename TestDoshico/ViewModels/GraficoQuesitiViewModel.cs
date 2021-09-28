using Data.Models;
using System;
using System.Collections.Generic;
using Data.Services;

namespace TestDoshico.ViewModels
{
    public class GraficoQuesitiViewModel
    {
        public List<KeyValuePair<String,int>> QuesitiValuePair { get; set; }
        public String TitoloGrafico { get; set; } = "Grafico";
        public String TitoloLegenda { get; set; } = "Legenda";

        public GraficoQuesitiViewModel(Prakriti prakriti, string titoloGrafico = "", string titoloLegenda = "")
        {
            QuesitiValuePair = GraficiServices.GetDatiForGrafico(prakriti);

            if (!String.IsNullOrEmpty(titoloGrafico))
                TitoloGrafico = titoloGrafico;
            if (!String.IsNullOrEmpty(titoloLegenda))
                TitoloLegenda = titoloLegenda;
        }
        public GraficoQuesitiViewModel(Vikriti vikriti, string titoloGrafico = "", string titoloLegenda = "")
        {
            QuesitiValuePair = GraficiServices.GetDatiForGrafico(vikriti);

            if (!String.IsNullOrEmpty(titoloGrafico))
                TitoloGrafico = titoloGrafico;
            if (!String.IsNullOrEmpty(titoloLegenda))
                TitoloLegenda = titoloLegenda;
        }
        public GraficoQuesitiViewModel(Emozioni emozioni, string titoloGrafico = "", string titoloLegenda = "")
        {
            QuesitiValuePair = GraficiServices.GetDatiForGrafico(emozioni);

            if (!String.IsNullOrEmpty(titoloGrafico))
                TitoloGrafico = titoloGrafico;
            if (!String.IsNullOrEmpty(titoloLegenda))
                TitoloLegenda = titoloLegenda;
        }
        public GraficoQuesitiViewModel(Mente mente, string titoloGrafico = "", string titoloLegenda = "")
        {
            QuesitiValuePair = GraficiServices.GetDatiForGrafico(mente);

            if (!String.IsNullOrEmpty(titoloGrafico))
                TitoloGrafico = titoloGrafico;
            if (!String.IsNullOrEmpty(titoloLegenda))
                TitoloLegenda = titoloLegenda;
        }
    }
}
