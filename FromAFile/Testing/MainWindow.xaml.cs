using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAPI api;

            string url = "http://pcbstuou.w27.wh-2.com/webservices/3033/api/accreditations?number=100";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                api = JsonConvert.DeserializeObject<DataAPI>(json);

                foreach (var item in api.Info)
                {
                    lstbox.Items.Add(item);
                }


            }
        }
    }
}
