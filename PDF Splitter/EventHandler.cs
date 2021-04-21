using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDF_Splitter
{
    class EventHandler
    {
        public void UnhideGUI(object sender)
        {
            Button btn = sender as Button;
            string nameElement = btn.Name;

            MainScreen f = new MainScreen();

            //Get last letter in name of object (right)
            string rightNameElement = nameElement.Substring(nameElement.Length - 1, 1);

            //Check if exists number in string
            if (int.TryParse(rightNameElement, out _))
            {
                //Check labels
                if (f.GetValueLabelOrigin(rightNameElement) != "Aguardando caminho")
                {
                    if (f.GetValueLabelDestiny(rightNameElement) != "Aguardando caminho")
                    {

                    }
                    else
                    {
                        //Case user don't select destiny path
                        MessageBox.Show("Inclua o caminho de destino do arquivo " + rightNameElement + " e tente novamente");
                    }
                }
                else
                {
                    //Case user don't select origin path
                    MessageBox.Show("Inclua o caminho de origem do arquivo " + rightNameElement + " e tente novamente");
                }
            }
        }

        private void UnhideButton()
        {

        }
    }
}
