using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EPersistencia
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ApplicationDataContainer data;

        public MainPage()
        {
            this.InitializeComponent();
            data = ApplicationData.Current.LocalSettings;
            if (data.Values.ContainsKey("info"))
            {
                saved.Text = data.Values["info"] as string;
            }
            else {
                saved.Text = "No hay información";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            data.Values["info"] = info.Text;
            info.Text = "";
        }
    }
}
