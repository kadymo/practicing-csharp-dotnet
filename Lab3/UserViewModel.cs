using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab3;

public class UserViewModel : INotifyPropertyChanged
{
    private string _username;

    public string Username
    {
        get { return _username; }
        set { _username = value; OnPropertyChanged(); }
    }

    private string _email;

    public string Email
    {
        get { return _email; }
        set { _email = value; OnPropertyChanged(); }
    }

    private string _password;
    public string Password
    {
        get { return _password; }
        set { _password = value; OnPropertyChanged(); }
    }

    private bool _acceptTerms;
    public bool AcceptTerms
    {
        get { return _acceptTerms; }
        set { _acceptTerms = value; OnPropertyChanged(); }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}