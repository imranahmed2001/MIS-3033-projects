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

namespace ChuckNorrisJokes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cboJokeCategory.Items.Add("ALL");

            string url = "https://api.chucknorris.io/jokes/categories";

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                List<string> categories = JsonConvert.DeserializeObject<List<string>>(json);

                foreach (string category in categories)
                {
                    cboJokeCategory.Items.Add(category);
                }
            }
        }

        private void cboJokeCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = cboJokeCategory.SelectedItem.ToString();
            string url = "https://api.chucknorris.io/jokes/random";

            if (selectedCategory != "ALL")
            {
                url += $"?category={selectedCategory}";
            }

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(url).Result;

                ChuckNorrisJokeAPI joke = JsonConvert.DeserializeObject<ChuckNorrisJokeAPI>(json);

                lblJoke.Content = joke.value;
            }
        }
    }
}
