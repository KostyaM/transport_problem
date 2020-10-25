using System;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
namespace transport_problem.output.docOutput.docIO
{
    public class DocIOOutput : DocOutput
    {
        public DocumentWriter createNewDocument()
        {
            return new DocIOWriter(
                new WordDocument()
           );
        }
    }

    public class DocIOWriter : DocumentWriter
    {
        WordDocument document;
        IWParagraph paragraph;

        public DocIOWriter(WordDocument document) {
            this.document = document;
            this.paragraph = document.AddSection().AddParagraph();
        }

        public void close()
        {
            document.Close();
        }

        public DocumentWriter save(string path)
        {
            document.Save(path);
            return this;
        }

        public DocumentWriter writeLine(string line)
        {
            paragraph.AppendText($"\n{line}");
            return this;
        }
    }
}
