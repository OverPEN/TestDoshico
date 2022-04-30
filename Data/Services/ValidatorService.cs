using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Data.Services
{
    public static class ValidatorService
    {
        public static async Task<bool> ValidateAsync(object classToValidate)
        {
            bool result = true;
            string errorMessage = String.Empty;
            try
            {
                if (classToValidate is Cliente)
                    result = ValidaCliente(classToValidate as Cliente, ref errorMessage);
                else if (classToValidate is Prakriti)
                    result = ValidaPrakriti(classToValidate as Prakriti, ref errorMessage);
                else if (classToValidate is Vikriti)
                    result = ValidaVikriti(classToValidate as Vikriti, ref errorMessage);
                else if (classToValidate is Mente)
                    result = ValidaMente(classToValidate as Mente, ref errorMessage);
                else if (classToValidate is Emozioni)
                    result = ValidaEmozioni(classToValidate as Emozioni, ref errorMessage);

                if (errorMessage != String.Empty)
                    await MessageServices.ShowWarningMessage("Test Doshico", errorMessage);
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore grave nella validazione campi!", ex);
                return false;
            }
            return result;
        }

        private static bool ValidaCliente(Cliente cliente, ref string errorMessage)
        {
            List<PropertyInfo> props = typeof(Cliente).GetProperties().Where(w => w.PropertyType == typeof(string) || w.PropertyType == typeof(int?)).ToList();
            foreach (PropertyInfo T in props)
            {
                if (T.GetValue(cliente) == null || (T.PropertyType == typeof(int?) && Convert.ToInt32(T.GetValue(cliente)) == 0))
                {
                    var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                }
            }
            return String.IsNullOrEmpty(errorMessage);
        }

        private static bool ValidaPrakriti(Prakriti prakriti, ref string errorMessage)
        {
            List<PropertyInfo> props = typeof(Prakriti).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo T in props)
            {
                if ((TipoCaratteristicaEnum)T.GetValue(prakriti) == TipoCaratteristicaEnum.Selezionare)
                {
                    var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                }
            }
            return String.IsNullOrEmpty(errorMessage);
        }

        private static bool ValidaVikriti(Vikriti vikriti, ref string errorMessage)
        {
            List<PropertyInfo> props = typeof(Vikriti).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo T in props)
            {
                if ((TipoCaratteristicaEnum)T.GetValue(vikriti) == TipoCaratteristicaEnum.Selezionare)
                {
                    var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                }
            }
            return String.IsNullOrEmpty(errorMessage);
        }

        private static bool ValidaMente(Mente mente, ref string errorMessage)
        {
            List<PropertyInfo> props = typeof(Mente).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo T in props)
            {
                if ((TipoCaratteristicaEnum)T.GetValue(mente) == TipoCaratteristicaEnum.Selezionare)
                {
                    var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                }
            }
            return String.IsNullOrEmpty(errorMessage);
        }

        private static bool ValidaEmozioni(Emozioni emozioni, ref string errorMessage)
        {
            List<PropertyInfo> props = typeof(Emozioni).GetProperties().Where(w => w.PropertyType == typeof(TipoCaratteristicaEnum)).ToList();
            foreach (PropertyInfo T in props)
            {
                if ((TipoCaratteristicaEnum)T.GetValue(emozioni) == TipoCaratteristicaEnum.Selezionare)
                {
                    var displayAttribute = T.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
                    errorMessage += $"Il campo {displayAttribute.DisplayName} non è stato compilato! {Environment.NewLine}";
                }
            }
            return String.IsNullOrEmpty(errorMessage);
        }
    }
}
