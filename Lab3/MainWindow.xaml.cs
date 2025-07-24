using System.Windows;

namespace Lab3;

public partial class MainWindow : Window
{
    private UserViewModel _userViewModel;

    public MainWindow()
    {
        InitializeComponent();
        NavigateToFirstPage();
    }
    
    private void NavigateToFirstPage()
    {
        var registerPage = new Register();
        registerPage.NavigationRequested += OnNavigationRequested;
        MainFrame.Navigate(registerPage);
    }

    private void OnNavigationRequested(Uri uri)
    {
        MainFrame.Navigate(uri);
    }
    
}