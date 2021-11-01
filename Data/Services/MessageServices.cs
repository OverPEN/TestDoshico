using System;
using System.Threading.Tasks;
using ModernWpf.Controls;

namespace Data.Services
{
    public static class MessageServices
    {
        static ContentDialog contentDialog;
        public static async void ShowInformationMessage(string Header, string Text)
        {
            contentDialog = new ContentDialog() { Title = Header, Content = Text, CloseButtonText = "Ok", DefaultButton = ContentDialogButton.Close};
            await contentDialog.ShowAsync();
            contentDialog = null;
        }

        public static async void ShowWarningMessage(string Header, string Text)
        {
            contentDialog = new ContentDialog() { Title = Header, Content = Text, CloseButtonText = "Ok", DefaultButton = ContentDialogButton.Close };
            await contentDialog.ShowAsync();
            contentDialog = null;
        }

        public static async void ShowErrorMessage(string Header, string Text, Exception ex)
        {
            contentDialog = new ContentDialog() { Title = Header, Content = Text + Environment.NewLine + ex.Message, CloseButtonText = "Ok", DefaultButton = ContentDialogButton.Close };
            await contentDialog.ShowAsync();
            contentDialog = null;
        }

        public static async Task<bool> ShowYesNoMessage(string Header, string Text, ContentDialogButton defaultButton)
        {
            contentDialog = new ContentDialog() { Title = Header, Content = Text, PrimaryButtonText = "Si", CloseButtonText = "No", DefaultButton = ContentDialogButton.Close };
            ContentDialogResult dialogResult = await contentDialog.ShowAsync();
            contentDialog.Hide();
            if (dialogResult == ContentDialogResult.Primary)
                return true;
            else
                return false;
        }
    }
}
