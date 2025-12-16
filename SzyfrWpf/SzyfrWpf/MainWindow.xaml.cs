using System.IO;
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

namespace SzyfrWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _keyBoxText = String.Empty;
        private int _moverBoxValue = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void KeyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _keyBoxText = KeyTextBox.Text;
        }

        private void GenerateKeyButton_Click(object sender, RoutedEventArgs e)
        {
            MakeEncode(_keyBoxText, _moverBoxValue);
            Result.Content = MakeEncode(_keyBoxText, _moverBoxValue);
        }
        
        private void MoverTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(MoverBox.Text, out int result))
            {
                _moverBoxValue = result;
            }
            else
            {
                _moverBoxValue = 0; 
            }
        }

        private string MakeEncode(string text, int mover)
        {
            StringBuilder cypherText = new StringBuilder();
            char[] chars = text.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char currentChar = chars[i];
                int code = (int)currentChar;

                if (!((code >= 65 && code <= 90) || (code >= 97 && code <= 122)))
                {
                    return "Błąd: tekst zawiera niedozwolone znaki.";
                }

                int baseCode = (code >= 65 && code <= 90) ? 65 : 97;
                int shifted = (code - baseCode + mover) % 26;

                if (shifted < 0)
                {
                    shifted += 26;
                }

                cypherText.Append((char)(baseCode + shifted));
            }

            return cypherText.ToString();
        }

        private void ZapiszClick(object sender, RoutedEventArgs e)
        {
            string path = "save.txt";

            File.WriteAllText(path, Result.Content.ToString());
        }
    }
}