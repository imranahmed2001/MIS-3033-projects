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

/// <starter_code>
/// 
/// URL for Webservice:
///     http://pcbstuou.w27.wh-2.com/webservices/3033/api/Netflix?number=100
///     
/// 
/// using (var client = new HttpClient())
/// {
///     var response = client.GetAsync("").Result;
///     if (response.StatusCode == System.Net.HttpStatusCode.OK)
///     {
///          = response.Content.ReadAsStringAsync().Result;
///          = JsonConvert.DeserializeObject<>();
///     }
/// }
/// 
/// </starter_code>
/// <author>
///     Imran Ahmed
/// </author>
namespace Problem1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ShowData> showdata = new List<ShowData>();
        public MainWindow()
        {
            InitializeComponent();
            ccboGenre.Items.Add("ALL");
            cboRating.Items.Add("ALL");

            string url = "http://pcbstuou.w27.wh-2.com/webservices/3033/api/Netflix?number=100";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    showdata = JsonConvert.DeserializeObject<List<ShowData>>(json);

                    foreach (ShowData item in showdata)
                    {

                        if (cboRating.Items.Contains(item.rating) == false)
                        {
                            cboRating.Items.Add(item.rating);
                        }
                        if (ccboGenre.Items.Contains(item.listed_in) == false)
                        {
                            ccboGenre.Items.Add(item.listed_in);
                        }
                    }

                }

            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string genre = ccboGenre.SelectedItem.ToString();
            string rating = cboRating.SelectedItem.ToString();
            lstbox.Items.Clear();

            foreach (ShowData item in showdata)
            {

                if (genre == item.listed_in)
                {
                    if (rating == item.rating)
                    {
                        lstbox.Items.Add(item);
                    }
                    else if (rating == "ALL")
                    {
                        lstbox.Items.Add(item);
                    }
                }
                else if (genre == "ALL")
                {
                    if (rating == item.rating)
                    {
                        lstbox.Items.Add(item);
                    }
                    else if (rating == "ALL")
                    {
                        lstbox.Items.Add(item);
                    }
                }

            }
            Record.Content = $"Record count: {lstbox.Items.Count}";

        }

        private void lstbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstbox.SelectedItem is null)
            {
                return;
            }
            ShowData selecteditem = (ShowData)lstbox.SelectedItem;

            MessageBox.Show($"Movie description: {selecteditem.description}\nDirected by: {selecteditem.director}");
        }
    }

    public class ShowData
    {
        public int? show_id { get; set; }
        public string? type { get; set; }
        public string? title { get; set; }
        public string? director { get; set; }
        public string? country { get; set; }
        public string? date_added { get; set; }
        public double release_year { get; set; }
        public string? rating { get; set; }
        public string? duration { get; set; }
        public string? listed_in { get; set; }
        public string? description { get; set; }

        public override string ToString()
        {
            return $"{title} | released in {release_year} | rated {rating} | genre {listed_in}";
        }
    }
}
