using CommunityToolkit.Mvvm.Messaging;
using Lab5.ViewModels;

namespace Lab5;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel { get; }
    
    public MainPage()
    {
        this.InitializeComponent();
        
        var messenger = WeakReferenceMessenger.Default;
        
        ViewModel = new MainViewModel(messenger);
        this.DataContext = ViewModel;
        
        messenger.Register<string>(this, (_contentLoaded, message ) => ShowNotification(message));
    }

    private void ShowNotification(String message)
    {
        Notification.Show(message);
    }
}
