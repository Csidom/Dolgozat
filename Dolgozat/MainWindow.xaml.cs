using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Foglalas(object sender, RoutedEventArgs e)
        {

            if (nameValid() && ageValid() && jogValid() && carValid() && berlesValid() && biztositasValid() && fizetesValid() && feltetelek())
            {

                int osszeg = 0;
                int egyszeriOsszeg = 0;

                string auto = "";
                if (autovalaszt.SelectedItem.ToString() == "Suzuki Swift – 12 000 Ft / nap")
                {
                    osszeg += 12000;
                    auto= "Suzuki Swift";
                }
                else if (autovalaszt.SelectedItem.ToString() == "Toyota Corolla – 18 000 Ft / nap")
                {
                    osszeg += 18000;
                    auto = "Toyota Corolla";
                }
                else if (autovalaszt.SelectedItem.ToString() == "BMW 3 – 30 000 Ft / nap")
                {
                    osszeg += 30000;
                    auto = "BMW 3";
                }
                else if (autovalaszt.SelectedItem.ToString() == "Tesla Model 3 – 35 000 Ft / nap")
                {
                    osszeg += 35000;
                    auto = "Tesla Model 3";
                }


                string bi = "";
                if (biztositB.IsChecked == true)
                {
                    osszeg += 3000;
                    bi = "Extra";
                }
                else if (biztositC.IsChecked == true)
                {
                    osszeg += 6000;
                    bi = "Teljes";
                }


                string ex = "";
                if (gps.IsChecked == true)
                {
                    osszeg += 1000;
                    ex += "GPS, ";
                }

                if (gyerekules.IsChecked == true)
                {
                    osszeg += 1500;
                    ex += "Gyerekülés, ";
                }

                if (sofor.IsChecked == true)
                {
                    osszeg += 2500;
                    ex += "Sofőr, ";
                }

                if (matrica.IsChecked == true)
                {
                    ex += "Matrica, ";
                    egyszeriOsszeg += 5000;
                }


                string fiz = "";
                if (fizetA.IsChecked == true)
                {
                    fiz = "Készpénz";

                }
                if (fizetB.IsChecked == true)
                {
                    fiz = "Bankkártya";
                }


                osszeg *= int.Parse(berlesido.Text.Trim());
                osszeg += egyszeriOsszeg;

                MessageBox.Show("Ügyfél neve: " + nev.Text.Trim() + "\n" +
                                "Autó: " + auto + "\n" +
                                "Időtartam: " + int.Parse(berlesido.Text.Trim()) + "\n" +
                                "Biztosítás: " + bi + "\n" +
                                "Extrák: " + ex + "\n" +
                                "Fizetés: " + fiz + "\n" +
                                "Összeg: " + osszeg + " Ft",
                                "Sikeres autóbérlés!", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Nemjo valami", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private bool nameValid()
        {
            if (nev.Text.Trim().Length == 0 || nev.Text.Trim().Length >= 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ageValid()
        {
            int age = int.Parse(kor.Text.Trim());
            if (kor.Text.Trim().Length == 0 || age < 18)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool jogValid()
        {
            if (jogsi.Text.Trim().Length == 0 || jogsi.Text.Trim().Length < 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool carValid()
        {
            if (autovalaszt.SelectedItem.ToString().Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool berlesValid()
        {
            int ido = int.Parse(berlesido.Text.Trim());
            if (berlesido.Text.Trim().Length == 0 || ido > 30)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool biztositasValid()
        {
            if (biztositA.IsChecked == false && biztositB.IsChecked == false && biztositC.IsChecked == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool fizetesValid()
        {
            if (fizetA.IsChecked == false && fizetB.IsChecked == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool feltetelek()
        {
            if (feltetel.IsChecked == false)
            {
                MessageBox.Show("Fogadd el a vásárlási feltételeket!", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}