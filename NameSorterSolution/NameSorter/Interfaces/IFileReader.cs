namespace NameSorter.Interfaces
{
    public interface IFileReader
    {
        List<string> ReadNamesFromFile(string filePath);
    }
}
