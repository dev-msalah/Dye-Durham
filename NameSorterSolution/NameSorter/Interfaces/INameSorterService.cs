namespace NameSorter.Interfaces
{
    public interface INameSorterService
    {
        List<string> SortNamesFromFile(string inputFile, string outputFile);
        bool ValidateInput(string inputFile, string outputFile);
    }
}
