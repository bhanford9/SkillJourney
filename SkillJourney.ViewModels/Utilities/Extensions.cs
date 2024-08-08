using System.Collections.ObjectModel;

namespace SkillJourney.ViewModels.Utilities;
internal static class Extensions
{
    public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> source, IEnumerable<T> addons)
    {
        foreach (var addon in addons)
        {
            source.Add(addon);
        }

        return source;
    }

    public static ObservableCollection<T> ClearAndAddRange<T>(this ObservableCollection<T> source, IEnumerable<T> addons)
    {
        source.Clear();
        return source.AddRange(addons);
    }
}
