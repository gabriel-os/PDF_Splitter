using System;
using System.Linq;
using System.Windows.Forms;


namespace PDF_Splitter
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }


        private HandPDF HandPDF()
        {
            throw new NotImplementedException();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            EventHandler ev = new EventHandler();
            ev.UnhideGUI(sender);
            
        }
        public string GetValueLabelDestiny(string numberRow) {
            Label lbl_text = this.Controls.Find("lblDestiny" + numberRow, true).FirstOrDefault() as Label;
            
            return lbl_text.Text;
        }

        public string GetValueLabelOrigin(string numberRow)
        {

            Label lbl_text = this.Controls.Find("lblOrigin" + numberRow, true).FirstOrDefault() as Label;

            return lbl_text.Text;
        }

        private void btnOrigin1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                MessageBox.Show("FOI");

            }
            else {
                //If not select folder 
                MessageBox.Show("Nenhuma pasta foi selecionada. Tente novamente");
            }
        }
    }
}
