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
            GetFolderPath(sender);
        }

        public void GetFolderPath(object sender) {

            Button btn = sender as Button;
            string nameButton = btn.Name;
            string numRow = "";
            Label lbl;

            if (nameButton.Contains("Origin"))
            {

                numRow = nameButton.Substring(nameButton.Length - 1, 1);
                lbl = this.Controls.Find("lblOrigin" + numRow, true).FirstOrDefault() as Label;
            }
            else {
                numRow = nameButton.Substring(nameButton.Length - 1, 1);
                lbl = this.Controls.Find("lblDestiny" + numRow, true).FirstOrDefault() as Label;
            }


            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyDocuments;

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            { 
                lbl.Text = fbd.SelectedPath;

            }
            else
            {
                //If not select folder 
                MessageBox.Show("Nenhuma pasta foi selecionada. Cancelando...");
            }
        }
    }
}
