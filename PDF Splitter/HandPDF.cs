
using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDF_Splitter
{
    class HandPDF
    {
        public void SplitPDF()
        {

            //variables
            String source_file = @"D:/Drive/Nerd/Estudos/Faculdade/EDS/Livros/Texto_10.pdf";
            String result = @"D:/Bibliotecas/Desktop/Teste";

            PdfCopy copy;
            //create PdfReader object
            PdfReader reader = new PdfReader(source_file);

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                //create Document object
                Document document = new Document();
                copy = new PdfCopy(document, new FileStream(result + i + ".pdf", FileMode.Create));
                copy.SetFullCompression();
                //open the document
                document.Open();
                //add page to PdfCopy
                copy.AddPage(copy.GetImportedPage(reader, i));
                //close the document object
                document.Close();
            }



        }



    }

}


