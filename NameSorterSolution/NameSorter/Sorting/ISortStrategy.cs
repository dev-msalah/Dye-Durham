namespace NameSorter.Sorting
{
    public interface ISortStrategy
    {
        List<string> SortNames(List<string> unsortedNames);
    }
}
