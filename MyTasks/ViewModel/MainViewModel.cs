using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MyTasks.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }

    [RelayCommand]
    async void Add()
    {
        if (string.IsNullOrEmpty(Text))
            return;
        
        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert( "Uh Oh!", "No internet", "Ok" );
            return;
        }

        //Microsoft.Maui.ApplicationModel.Communication.Contact

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

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync( $"{nameof( DetailPage )}?id={s}" );
        // if you need to pass complex objec
            //new Dictionary<string, object>
            //{
            //    {nameof(DetailPage), new object()},
            //} ); 
    }
}
