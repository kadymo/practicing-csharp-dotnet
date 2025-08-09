using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Lab5.Enums;
using Lab5.Models;
using Uno.Extensions;

namespace Lab5.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IMessenger _messenger;
    
    [ObservableProperty]
    private string _firstName;

    [ObservableProperty]
    private string _lastName;
    
    [ObservableProperty]
    private string _email;
    
    [ObservableProperty]
    private string _searchTerm;

    private Stack<string> _errorsStack { get; set; } = new();
    public ObservableCollection<string> Errors { get; set; } = new();
    
    private List<User> _allUsers { get; set; }
    public ObservableCollection<User> Users { get; set; }

    public MainViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        _allUsers = new List<User>
        {
            new User { FirstName = "Kádymo", LastName = "Santana", Email = "kadymo@email.com" },
            new User { FirstName = "João", LastName = "Silva", Email = "joao@email.com" },
            new User { FirstName = "Pedro", LastName = "Santos", Email = "pedro@email.com" },
        };
        
        Users = new ObservableCollection<User>(_allUsers);
    }

    [RelayCommand]
    private void SaveData()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(Email))
            {
                throw new ArgumentException($"{DateTime.Now} - Todos os campos são obrigatórios.");
            }

            if (_allUsers.Any(x => x.Email.Equals(Email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"{DateTime.Now} - O e-mail inserido já existe.");
            } 
            
            var newUser = new User { FirstName = FirstName, LastName = LastName, Email = Email };
            
            _allUsers.Add(newUser);
            Users.Add(newUser);
        
            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
            
            _messenger.Send("Usuário adicionado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            var errorMessage = new NotificationMessage($"Erro: {ex.Message}", NotificationType.Error);
            _messenger.Send(errorMessage);
            
            _errorsStack.Push(ex.Message);
            Errors.Add(_errorsStack.Peek());
        }
    }

    [RelayCommand]
    private void SearchByEmail()
    {
        Users.Clear();
        var filter = _allUsers.Where(x => x.Email.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
        var filteredUsers = string.IsNullOrWhiteSpace(SearchTerm) ? _allUsers : filter;

        foreach (var user in filteredUsers)
        {
            Users.Add(user);
        }

        _messenger.Send("Pesquisa por e-mail realizada com sucesso!");
    }

    [RelayCommand]
    private void OrderByAsc()
    {
        var sortedUsers = _allUsers.OrderBy(x => x.FirstName).ToList();
        Users.Clear();
        foreach (var user in sortedUsers)
        {
            Users.Add(user);
        }
        
        _messenger.Send("Ordenação por nome em ordem crescente realizada com sucesso!");
    }
    
    [RelayCommand]
    private void OrderByDesc()
    {
        var sortedUsers = _allUsers.OrderByDescending(x => x.FirstName).ToList();
        Users.Clear();
        foreach (var user in sortedUsers)
        {
            Users.Add(user);       
        }

        _messenger.Send("Ordenação por nome em ordem decrescente realizada com sucesso!");
    }

    [RelayCommand]
    private void ShowErrors()
    {
        Errors.Remove("Nenhum erro para mostrar");
        if (_errorsStack.Count == 0)
        { 
            Errors.Add("Nenhum erro para mostrar");
        }
    }
    
    
}
