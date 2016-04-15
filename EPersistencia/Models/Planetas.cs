using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPersistencia.Models
{
    public class Planetas
    {
        private ObservableCollection<Planeta> data;

        public ObservableCollection<Planeta> Data
        {
            get {
                if (data == null)
                    data = new ObservableCollection<Planeta>();
                return data; }
            set { data = value; }
        }

        public void loadData(List<Planeta> newData) {
            Data.Clear();

            foreach (Planeta p in newData) {
                Data.Add(p);
            }


        }


    }
}
