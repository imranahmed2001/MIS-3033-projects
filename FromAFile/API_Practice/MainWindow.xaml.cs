using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace API_Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CarDataAPI> cardata = new List<CarDataAPI> ();
        public MainWindow()
        {
            InitializeComponent();
            cboColor.Items.Add("ALL");

            string json = File.ReadAllText("Mock_Data_Car_Owners.json");

            cardata = JsonConvert.DeserializeObject<List<CarDataAPI>>(json);

            foreach (CarDataAPI item in cardata)
            {
                if (cboColor.Items.Contains(item.Color) == false)
                {
                    cboColor.Items.Add(item.Color);
                }
            }

        }

        private void cboColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstCarInfo.Items.Clear();
            string color = cboColor.SelectedItem.ToString();

            foreach (CarDataAPI item in cardata)
            {
                if (color == "ALL")
                {
                    lstCarInfo.Items.Add(item);
                }
                else if (color == item.Color)
                {
                    lstCarInfo.Items.Add(item);
                }
            }
            RecordCount.Content = $"Record Count: {lstCarInfo.Items.Count}";
        }
    }
}
