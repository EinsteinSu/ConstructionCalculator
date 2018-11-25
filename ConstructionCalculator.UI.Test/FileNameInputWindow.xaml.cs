using System.Windows;

namespace ConstructionCalculator.UI.Test
{
    /// <summary>
    ///     Interaction logic for FileNameInputWindow.xaml
    /// </summary>
    public partial class FileNameInputWindow
    {
        public FileNameInputWindow()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get => txtFileName.Text;
            set => txtFileName.Text = value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}