using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Lab32;

public delegate Task FinishedOperationHandler(string title, string message);

public partial class UserViewModel : ObservableObject
{
    public event FinishedOperationHandler? OnFinishedOperation;
    
    [ObservableProperty]
    private string _name;
    
    [ObservableProperty]
    private string _email;
    
    [RelayCommand]
    private async Task SaveAsync()
    {
        if (OnFinishedOperation is not null)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email))
            { 
                await OnFinishedOperation.Invoke("Erro", "Nome e E-mail são obrigatórios");
                return;
            }

            await Task.Delay(500);
            await OnFinishedOperation.Invoke("Sucesso", $"{Name} salvo com sucesso!");  
        }

    }
}
