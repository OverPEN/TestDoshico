using Data.Models;
using System;
using System.Collections.Generic;
using Data.Services;

namespace TestDoshico.ViewModels.Quesiti
{
    public class GraficoQuesitiViewModel
    {
        public List<KeyValuePair<String, int>> QuesitiValuePair { get; set; } = new List<KeyValuePair<string, int>>();
        public String TitoloGrafico { get; set; } = "Grafico";
        public String TitoloLegenda { get; set; } = "Legenda";

        public GraficoQuesitiViewModel() { }

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

        public GraficoQuesitiViewModel(Test test, string titoloGrafico = "", string titoloLegenda = "")
        {
            QuesitiValuePair = GraficiServices.GetDatiComplessiviForGrafico(test);

            if (!String.IsNullOrEmpty(titoloGrafico))
                TitoloGrafico = titoloGrafico;
            if (!String.IsNullOrEmpty(titoloLegenda))
                TitoloLegenda = titoloLegenda;
        }
    }
}
