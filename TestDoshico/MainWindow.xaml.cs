using Data.Services;
using System;
using System.Windows;
using TestDoshico.ViewModels.Clienti;
using TestDoshico.ViewModels.Quesiti;
using TestDoshico.Views.Clienti;
using TestDoshico.Views.Quesiti;
using TestDoshico.Views.Tests;
using Squirrel;
using System.Windows.Input;

namespace TestDoshico
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UpdateManager updater;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void NavigationView_SelectionChanged(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            try
            {
                while (Main.NavigationService.CanGoBack)
                {
                    Main.NavigationService.RemoveBackEntry();
                }
                #region NuovoClienteClick
                if (args.SelectedItem == bt_NuovoCliente)
                {
                    NuovoClienteViewModel clienteViewModel = new NuovoClienteViewModel();
                    NuovoCliente nuovoCliente = new NuovoCliente(clienteViewModel);
                    Main.Content = nuovoCliente;
                    this.Title = $"Test Doshico - {nuovoCliente.Title}";
                }
                #endregion
                #region NuovoTestClick
                else if (args.SelectedItem == bt_NuovoTest)
                {
                    QuesitiViewModel quesitiViewModel = new QuesitiViewModel();
                    DatiPersonali datiPersonali = new DatiPersonali(quesitiViewModel);
                    Main.Content = datiPersonali;
                    this.Title = $"Test Doshico - {datiPersonali.Title}";
                }
                #endregion
                #region ListaClientiClick
                else if (args.SelectedItem == bt_ListaClienti)
                {
                    if (Main.Content == null || (Main.Content.GetType() != typeof(DatiPersonali) && Main.Content.GetType() != typeof(QuesitiPrakriti) && Main.Content.GetType() != typeof(QuesitiVikriti) && Main.Content.GetType() != typeof(QuesitiMente) && Main.Content.GetType() != typeof(QuesitiEmozioni)))
                    {
                        ListaClienti listaClienti = new ListaClienti();
                        Main.Content = listaClienti;
                        this.Title = $"Test Doshico - {listaClienti.Title}";
                    }
                    else
                    {
                        if (await MessageServices.ShowYesNoMessage("Test Doshico", "Abbandonare l'esecuzione del test per aprire la Lista Clienti? I dati non salvati verranno persi!", ModernWpf.Controls.ContentDialogButton.Primary))
                        {
                            ListaClienti listaClienti = new ListaClienti();
                            Main.Content = listaClienti;
                            this.Title = $"Test Doshico - {listaClienti.Title}";
                        }

                    }
                }
                #endregion
                #region ListaTestClick
                else if (args.SelectedItem == bt_ListaTest)
                {

                    if (Main.Content == null || (Main.Content.GetType() != typeof(DatiPersonali) && Main.Content.GetType() != typeof(QuesitiPrakriti) && Main.Content.GetType() != typeof(QuesitiVikriti) && Main.Content.GetType() != typeof(QuesitiMente) && Main.Content.GetType() != typeof(QuesitiEmozioni)))
                    {
                        ListaTests listaTest = new ListaTests();
                        Main.Content = listaTest;
                        this.Title = $"Test Doshico - {listaTest.Title}";
                    }
                    else
                    {
                        if (await MessageServices.ShowYesNoMessage("Test Doshico", "Abbandonare l'esecuzione del test per aprire la Lista Clienti? I dati non salvati verranno persi!", ModernWpf.Controls.ContentDialogButton.Primary))
                        {
                            ListaTests listaTest = new ListaTests();
                            Main.Content = listaTest;
                            this.Title = $"Test Doshico - {listaTest.Title}";
                        }

                    }
                }
                #endregion
                #region UpdateClick
                else if (args.SelectedItem == bt_Update)
                {
                    try
                    {
                        Mouse.OverrideCursor = Cursors.Wait;
                        updater = await UpdateManager.GitHubUpdateManager("https://github.com/OverPEN/TestDoshico", prerelease: true);
                        UpdateInfo updateInfo = await updater.CheckForUpdate();
                        if (updateInfo.ReleasesToApply.Count > 0)
                        {
                            Mouse.OverrideCursor = Cursors.Arrow;
                            if (await MessageServices.ShowYesNoMessage("Servizio di Aggiornamento Automatico", "E' disponibile una nuova versione dell'applicazione, eseguire l'aggiornamento?", ModernWpf.Controls.ContentDialogButton.Primary))
                            {
                                Mouse.OverrideCursor = Cursors.Wait;
                                await updater.UpdateApp();
                                Mouse.OverrideCursor = Cursors.Arrow;
                                await MessageServices.ShowInformationMessage("Servizio di Aggiornamento Automatico", "Aggiornamento scaricato con successo! Riavvia l'applicazione per applicarlo");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        await MessageServices.ShowErrorMessage("Servizio di Aggiornamento Automatico", "Errore Grave!", ex);
                    }
                    finally
                    {
                        Mouse.OverrideCursor = Cursors.Arrow;
                    }
                }
                #endregion
                #region AboutClick
                else if (args.SelectedItem == bt_About)
                {
                    About aboutWindow = new About();
                    aboutWindow.ShowDialog();

                }
                #endregion
            }
            catch (Exception ex)
            {
                await MessageServices.ShowErrorMessage("Test Doshico", "Errore Grave durante la navigazione!", ex); ;
            }

        }

        private async void NavigationView_ItemInvoked(ModernWpf.Controls.NavigationView sender, ModernWpf.Controls.NavigationViewItemInvokedEventArgs args)
        {
            while (Main.NavigationService.CanGoBack)
            {
                try
                {
                    Main.NavigationService.RemoveBackEntry();
                }
                catch
                {
                    break;
                }
            }

            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(DatiPersonali) || Main.Content.GetType() == typeof(QuesitiPrakriti) || Main.Content.GetType() == typeof(QuesitiVikriti) || Main.Content.GetType() == typeof(QuesitiMente) || Main.Content.GetType() == typeof(QuesitiEmozioni))
                {
                    if (args.InvokedItem.ToString() == "Nuovo Test Doshico")
                    {
                        if (await MessageServices.ShowYesNoMessage("Test Doshico", "Abbandonare l'esecuzione del Test in corso per eseguire un nuovo Test? I dati non salvati verranno persi!", ModernWpf.Controls.ContentDialogButton.Primary))
                        {
                            QuesitiViewModel quesitiViewModel = new QuesitiViewModel();
                            DatiPersonali datiPersonali = new DatiPersonali(quesitiViewModel);
                            Main.Content = datiPersonali;
                            this.Title = $"Test Doshico - {datiPersonali.Title}";
                        }
                    }
                }
            }
        }
    }
}
