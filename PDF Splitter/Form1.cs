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

        public void UnihideLabel(string numberRow)
        {
            Label lbl_text_origin = this.Controls.Find("lblOrigin" + numberRow, true).FirstOrDefault() as Label;
            Label lbl_text_destiny = this.Controls.Find("lblDestiny" + numberRow, true).FirstOrDefault() as Label;
            Button btn_origin = this.Controls.Find("btnOrigin" + numberRow, true).FirstOrDefault() as Button;
            Button btn_destiny = this.Controls.Find("btnDestiny" + numberRow, true).FirstOrDefault() as Button;

            lbl_text_origin.Visible = true;
            lbl_text_destiny.Visible = true;

            btn_origin.Visible = true;
            btn_destiny.Visible = true;
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
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ofd.Filter = "Arquivos PDF(*.pdf)|*.pdf";
                ofd.FilterIndex = 1;

                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    EventHandler ev = new EventHandler();
                    lbl.Text = ofd.FileName;
                    Label lbl_size = this.Controls.Find("lblSize" + numRow, true).FirstOrDefault() as Label;
                    lbl_size.Visible = true;
                    ev.UnhideGUI(sender);

                }
                else
                {
                    //If not select folder 
                    MessageBox.Show("Nenhuma pasta foi selecionada. Cancelando...");
                }

            }
            else {
                numRow = nameButton.Substring(nameButton.Length - 1, 1);
                lbl = this.Controls.Find("lblDestiny" + numRow, true).FirstOrDefault() as Label;
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

        private void btnDestiny1_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }
    }
}
