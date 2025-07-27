namespace Lab32;

public sealed partial class MainPage : Page
{
    public UserViewModel UserViewModel => (UserViewModel)this.DataContext;
    public MainPage()
    {
        this.InitializeComponent();
        UserViewModel.OnFinishedOperation += HandleFinishedOperation;
    }

    private async Task HandleFinishedOperation(string title, string message)
    {
        var dialog = new ContentDialog
        {
            Title = title,
            Content = message,
            CloseButtonText = "OK"      
        };

        dialog.XamlRoot = this.XamlRoot;
        await dialog.ShowAsync();
    }
}
