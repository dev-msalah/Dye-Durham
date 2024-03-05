namespace NameSorter.Interfaces
{
    public interface IFileWriter
    {
        void WriteNamesToFile(List<string> names, string filePath);
        bool FileExists(string filePath);
    }
}
