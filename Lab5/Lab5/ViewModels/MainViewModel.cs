using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab5.Models;

namespace Lab5.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string _firstName;

    [ObservableProperty]
    private string _lastName;
    
    [ObservableProperty]
    private string _email;
    
    public ObservableCollection<User> Users { get; set; }

    public MainViewModel()
    {
        Users = new ObservableCollection<User>
        {
            new User { Firstname = "Kádymo", Lastname = "Santana", Email = "kadymo@email.com" },
            new User { Firstname = "João", Lastname = "Silva", Email = "joao@email.com" },
            new User { Firstname = "Pedro", Lastname = "Santos", Email = "pedro@email.com" },
        };
    }

    [RelayCommand]
    private void SaveData()
    {
        Users.Add(new User { Firstname = _firstName, Lastname = _lastName, Email = _email });
    }
}
