using Windows.UI.Notifications;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.WinUI.UI.Controls;
using Lab5.Enums;
using Lab5.Models;
using Lab5.ViewModels;
using Microsoft.UI;

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
        
        messenger.Register<NotificationMessage>(this, (_contentLoaded, message ) =>
        {
            ShowNotification(message);
        });
    }

    private void ShowNotification(NotificationMessage message)
    {
        Notification.Show(message.Text, message.Duration);
    }
}
