using System;
namespace transport_problem.output.docOutput
{
    public interface DocOutput
    {
        DocumentWriter createNewDocument();
    }

    public interface DocumentWriter {
        DocumentWriter writeLine(String line);
        DocumentWriter save(String path);
        void close();
    }
}
