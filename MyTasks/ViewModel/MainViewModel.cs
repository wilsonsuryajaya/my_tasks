using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyTasks.ViewModel;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    public MainViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrEmpty(Text))
            return;
        Items.Add( Text );

        // add our item
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove( s );
        }
    }
}
