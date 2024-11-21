using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace HMIApp_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void ChangeLanguage(string cultureCode)
        {
            // Ustawienie nowej kultury wątku
            var culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Załaduj nowy ResourceDictionary
            ResourceDictionary langDict = new ResourceDictionary
            {
                Source = new Uri($"Resources/StringResources.{cultureCode}.xaml", UriKind.Relative)
            };

            // Usuń poprzedni i dodaj nowy słownik
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(langDict);
        }
    }

}
