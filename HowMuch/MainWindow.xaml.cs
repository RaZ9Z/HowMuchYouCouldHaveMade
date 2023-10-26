using System;
using System.Collections.Generic;
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

namespace HowMuch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<string> items = new List<string>
{
               "100",
"105",
"110",
"115",
"120",
"125",
"130",
"135",
"140",
"145",
"150",
"155",
"160",
"165",
"170",
"175",
"180",
"185",
"190",
"195",
"200",
"205",
"210",
"215",
"220",
"225",
"230",
"235",
"240",
"245",
"250",
"255",
"260",
"265",
"270",
"275",
"280",
"285",
"290",
"295",
"300",
"305",
"310",
"315",
"320",
"325",
"330",
"335",
"340",
"345",
"350",
"355",
"360",
"365",
"370",
"375",
"380",
"385",
"390",
"395",
"400",
"405",
"410",
"415",
"420",
"425",
"430",
"435",
"440",
"445",
"450",
"455",
"460",
"465",
"470",
"475",
"480",
"485",
"490",
"495",
"500",
"505",
"510",
"515",
"520",
"525",
"530",
"535",
"540",
"545",
"550",
"555",
"560",
"565",
"570",
"575",
"580",
"585",
"590",
"595",
"600",
"605",
"610",
"615",
"620",
"625",
"630",
"635",
"640",
"645",
"650",
"655",
"660",
"665",
"670",
"675",
"680",
"685",
"690",
"695",
"700",
"705",
"710",
"715",
"720",
"725",
"730",
"735",
"740",
"745",
"750",
"755",
"760",
"765",
"770",
"775",
"780",
"785",
"790",
"795",
"800",
"805",
"810",
"815",
"820",
"825",
"830",
"835",
"840",
"845",
"850",
"855",
"860",
"865",
"870",
"875",
"880",
"885",
"890",
"895",
"900",
"905",
"910",
"915",
"920",
"925",
"930",
"935",
"940",
"945",
"950",
"955",
"960",
"965",
"970",
"975",
"980",
"985",
"990",
"995",
"1000"
            };
            rCombo.ItemsSource = items;     
        }

        private double CalcPL()
        {
            if (!string.IsNullOrEmpty(entryTb.Text) && !string.IsNullOrEmpty(stopTb.Text) && !string.IsNullOrEmpty(tpTb.Text))
                if (double.Parse(tpTb.Text) < double.Parse(entryTb.Text) && double.Parse(stopTb.Text)>double.Parse(entryTb.Text))
                {
                    return -1*(double.Parse(tpTb.Text) - double.Parse(entryTb.Text)) * CalcShares();
                }
                else
                    return (double.Parse(tpTb.Text) - double.Parse(entryTb.Text)) * CalcShares();
            else
                return 0;
        }
        private void calcBtn_Click(object sender, RoutedEventArgs e)
        {
            double pl = CalcPL();
            SolidColorBrush red = new SolidColorBrush(Colors.Red);
            SolidColorBrush lime = new SolidColorBrush(Colors.Lime);
            TextBlock textBlock = new TextBlock();
            string plValue = string.Format("{0:#,0}", pl);
            // Create a Run with the text you want to display
            Run normalRun = new Run("You Would Have Made ");
            Run boldRun = new Run(plValue);
            Run remainingRun = new Run("$");
            boldRun.FontWeight = FontWeights.Bold;

            textBlock.Inlines.Add(normalRun);
            textBlock.Inlines.Add(boldRun);
            textBlock.Inlines.Add(remainingRun);

            if (pl < 0) youMadeValueLbl.Foreground = red;
            else youMadeValueLbl.Foreground = lime;
            
            youMadeValueLbl.Content = textBlock;
        }
        private int CalcShares()
        {
            double shares = 0;
            if (!string.IsNullOrEmpty(entryTb.Text.ToString()) && entryTb.Text != stopTb.Text && entryTb.Text != "0.00" && entryTb.Text != "0")
            {
                int r = int.Parse(rCombo.Text);
                double entryfinal;
                bool entry = double.TryParse(entryTb.Text, out entryfinal);
                double stopfinnal;
                bool stop = double.TryParse(stopTb.Text, out stopfinnal);

                shares = r / (entryfinal - stopfinnal);

                if (shares < 0) { shares *= -1; }
            }
            return ((int)shares);

        }
      
    }
}
