using System.Windows;
using System.Windows.Controls;

namespace Lab3;

public partial class Register : Page
{
    private UserViewModel _userViewModel;

    public event Action<Uri> NavigationRequested;
    
    public Register()
    {
        InitializeComponent();
        _userViewModel = new UserViewModel();
        this.DataContext = _userViewModel;
    }
    
    private void Register_Click(object sender, RoutedEventArgs e)
    {
        if (_userViewModel.AcceptTerms)
        {
            NavigationRequested?.Invoke(new Uri("/Authenticated.xaml", UriKind.Relative));
            MessageBox.Show($"Usuário {_userViewModel.Username} cadastrado!");
        }
        else
        {
            MessageBox.Show("É necessário acessar os termos e condições para se cadastrar.");
        }
    }


}