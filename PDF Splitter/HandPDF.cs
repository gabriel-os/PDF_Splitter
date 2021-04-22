using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PDF_Splitter
{
    class HandPDF
    {
        public void RunSplitter(string source_file, string result, long maxSize)
        {
            string map = "";
            string nameFile = Path.GetFileNameWithoutExtension(source_file);
            string extention = Path.GetExtension(source_file);
            long i = 1;

            SplitPDF(source_file, result);

            map = MapSplitRule(result, maxSize);

            string[] filesToMade = map.Split("&&%%&&%%&&%%");

            foreach (string filePath in filesToMade)
            {

                string[] listPaths = filePath.Split("$&*");

                AppendPDF(result + @"\" + nameFile + "_Parte " + i + extention, listPaths);

                i = i + 1;
            }

            DeleteTempFolder(result);
        }

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


                copy.Close();

            }
            //X

            reader.Close();


        }

        public void AppendPDF(string outPutFilePath, params string[] filesPath)
        {

            List<PdfReader> readerList = new List<PdfReader>();

            foreach (string filePath in filesPath)
            {
                if (filePath != "")
                {
                    PdfReader pdfReader = new PdfReader(filePath);
                    readerList.Add(pdfReader);
                }

            }

            if (readerList.Count > 0)
            {

                Document document = new Document(PageSize.A4, 0, 0, 0, 0);

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outPutFilePath, FileMode.Create));
                document.Open();

                foreach (PdfReader reader in readerList)
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        document.Add(iTextSharp.text.Image.GetInstance(page));
                    }

                }
                //X

                document.Close();

            }

        }

        public string MapSplitRule(string path, long maxSize)
        {
            long tmp = 0;
            string tmpList = "";
            string tempPath = path + @"\tmp\";
            //var a = Directory.GetFiles(path, "*.pdf").OrderBy(f => f.CreationTime);

            DirectoryInfo info = new DirectoryInfo(tempPath);
            FileInfo[] a = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();

            long b = 0;
            foreach (FileInfo name in a)
            {

                if ((tmp + name.Length) > maxSize * 0.979)
                {
                    tmpList = tmpList + (name.FullName) + "$&*";
                    //Sep each file
                    tmpList += "&&%%&&%%&&%%";
                    tmp = 0;
                }
                else
                {
                    tmpList = tmpList + (name.FullName) + "$&*";
                    tmp += name.Length;
                }
            }

            return tmpList;
        }

        public void DeleteTempFolder(string result)
        {
            string tempPath = result + @"\tmp\";

            if (Directory.Exists(tempPath))
            {
                //Directory.Delete(tempPath, true);
            }
        }

    }

}


