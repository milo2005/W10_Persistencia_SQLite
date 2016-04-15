using EPersistencia.DataBase;
using EPersistencia.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=234238

namespace EPersistencia
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PlanetaPage : Page
    {
        PlanetaDao dao;
        Planetas data;

        public PlanetaPage()
        {
            this.InitializeComponent();
            dao = new PlanetaDao();
            this.Loaded += PlanetaPage_Loaded;
            
        }

        private void PlanetaPage_Loaded(object sender, RoutedEventArgs e)
        {
            data = root.Resources["data"] as Planetas;
            data.loadData(dao.getAllPlaneta());
            
        }

        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            float t =(float) Convert.ToDouble(tamanio.Text);
            float g = (float)Convert.ToDouble(gravedad.Text);
            
            Planeta p = new Planeta() { Nombre=nombre.Text, Tamanio=t, Gravedad=g};
            dao.insertPlaneta(p);
            data.Data.Add(p);
        }
    }
}
