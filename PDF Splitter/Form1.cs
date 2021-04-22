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

            HandPDF hp = new HandPDF();

            for (int i = 1; i > 5; i++)
            {
                Label lbl_text_origin = this.Controls.Find("lblOrigin" + i, true).FirstOrDefault() as Label;
                Label lbl_text_destiny = this.Controls.Find("lblDestiny" + i, true).FirstOrDefault() as Label;
                ComboBox cb_size = this.Controls.Find("cbSize" + i, true).FirstOrDefault() as ComboBox;



                hp.RunSplitter(lbl_text_origin.Text, lbl_text_destiny.Text, GetBytesValue(cb_size.SelectedValue.ToString()));

            }






        }
        public string GetValueLabelDestiny(string numberRow)
        {
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

        public void GetFolderPath(object sender)
        {

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
                    lbl.Text = ofd.FileName;


                }
                else
                {
                    //If not select folder 
                    MessageBox.Show("Nenhuma pasta foi selecionada. Cancelando...");
                }

            }
            else
            {
                numRow = nameButton.Substring(nameButton.Length - 1, 1);
                lbl = this.Controls.Find("lblDestiny" + numRow, true).FirstOrDefault() as Label;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = Environment.SpecialFolder.MyDocuments;

                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    lbl.Text = fbd.SelectedPath;
                    EventHandler ev = new EventHandler();
                    Label lbl_size = this.Controls.Find("lblSize" + numRow, true).FirstOrDefault() as Label;
                    ComboBox cb_size = this.Controls.Find("cbSize" + numRow, true).FirstOrDefault() as ComboBox;
                    lbl_size.Visible = true;
                    cb_size.Visible = true;
                    ev.UnhideGUI(sender);
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

        private void btnOrigin2_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }

        private void btnDestiny2_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }

        private void btnOrigin3_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }

        private void btnDestiny3_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }

        private void btnOrigin4_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }

        private void btnDestiny4_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }

        private void btnOrigin5_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }

        private void btnDestiny5_Click(object sender, EventArgs e)
        {
            GetFolderPath(sender);
        }
        private long GetBytesValue(string cbTxt)
        {

            switch (cbTxt)
            {
                case "1MB":
                    return 1000000;

                case "2MB":
                    return 2000000;

                case "3MB":
                    return 3000000;

                case "4MB":
                    return 4000000;

                case "5MB":
                    return 5000000;

                case "6MB":
                    return 6000000;

                case "7MB":
                    return 7000000;

                case "8MB":
                    return 8000000;

                case "9MB":
                    return 9000000;

                case "10MB":
                    return 10000000;

                case "11MB":
                    return 11000000;

                case "12MB":
                    return 12000000;

                default:
                    return 4000000;

            }

        }
    }
}
