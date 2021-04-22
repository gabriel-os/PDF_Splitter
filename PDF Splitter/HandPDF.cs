
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDF_Splitter
{
    class HandPDF
    {
        public void SplitPDF(string source_file, string result)
        {
            string tempPath = result + @"\tmp\";
            //Create Folder temporary
            // If directory does not exist, create it. 
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }



            PdfCopy copy;
            
            PdfReader reader = new PdfReader(source_file);

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                
                Document document = new Document();
                copy = new PdfCopy(document, new FileStream(tempPath + i + ".pdf", FileMode.Create));
                copy.SetFullCompression();
                
                document.Open();
                
                copy.AddPage(copy.GetImportedPage(reader, i));
                
                document.Close();
            }



        }

        public void AppendPDF() { 
            
        
        }

        public string MapSplitRule(string path, long maxSize) {
            long tmp = 0;
            string tmpList = "";
            //var a = Directory.GetFiles(path, "*.pdf").OrderBy(f => f.CreationTime);

            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] a = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();

            long b = 0;
            foreach (FileInfo name in a)
            {

                if ((tmp + name.Length) > maxSize)
                {
                    //Sep each file
                    tmpList += "&&%%&&%%&&%%";
                    tmp = 0;
                }
                else {
                    tmpList = tmpList + ((name.Name).ToUpper()).Replace(".PDF","") + "$&*";
                    tmp += name.Length;
                } 
            }

            return tmpList;
        }

        public void DeleteTempFolder(string result) {
            string tempPath = result + @"\tmp\";

            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath, true);
            }
        }

    }

}


