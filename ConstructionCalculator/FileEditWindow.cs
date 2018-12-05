using System;
using System.Windows.Forms;
using ConstructionCalculator.DataAccess;
using DevExpress.XtraEditors;

namespace ConstructionCalculator
{
    public partial class FileEditWindow : XtraForm
    {
        public FileEditWindow()
        {
            InitializeComponent();

            comboBoxEditFileType.Properties.Items.Clear();
            foreach (var name in Enum.GetNames(typeof(FileType))) comboBoxEditFileType.Properties.Items.Add(name);
        }

        public FileType FileType
        {
            get
            {
                Enum.TryParse<FileType>(comboBoxEditFileType.SelectedItem.ToString(), true, out var result);
                return result;
            }
            set => comboBoxEditFileType.SelectedText = value.ToString();
        }

        public string FileName
        {
            get => textEditFileName.Text;
            set => textEditFileName.Text = value;
        }

        private string Check()
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(FileName)) error = "Please enter a file name." + Environment.NewLine;

            if (string.IsNullOrEmpty(comboBoxEditFileType.SelectedItem.ToString())) error += "Please select a file type.";

            return error;
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void simpleButtonOK_Click(object sender, EventArgs e)
        {
            var error = Check();
            if (!string.IsNullOrEmpty(error))
            {
                MessageBox.Show(error);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}