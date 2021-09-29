using System;
using Xceed.Wpf.Toolkit;

namespace Data.Services
{
    public static class MessageServices
    {
        private static System.Windows.Style style = new System.Windows.Style();

        static MessageServices()
        {
            style.Setters.Add(new System.Windows.Setter(MessageBox.YesButtonContentProperty, "Sì"));
            style.Setters.Add(new System.Windows.Setter(MessageBox.NoButtonContentProperty, "No"));
            style.Setters.Add(new System.Windows.Setter(MessageBox.CancelButtonContentProperty, "Annulla"));
        }

        public static void ShowInformationMessage(string Header, string Text)
        {
            MessageBox.Show(Text, Header, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        public static void ShowWarningMessage(string Header, string Text)
        {
            MessageBox.Show(Text, Header, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
        }

        public static void ShowErrorMessage(string Header, string Text, Exception ex)
        {
            MessageBox.Show(Text + Environment.NewLine + ex.Message, Header, System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        }

        public static bool ShowYesNoMessage(string Header, string Text, System.Windows.MessageBoxResult defaultResult)
        {
            if (MessageBox.Show(Text, Header, System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question, defaultResult, style) == System.Windows.MessageBoxResult.Yes)
                return true;
            else
                return false;
        }
    }
}
