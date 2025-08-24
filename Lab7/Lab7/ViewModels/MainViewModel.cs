using System.Collections.ObjectModel;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab7.Models;

namespace Lab7.ViewModels;

public partial class MainViewModel : ObservableObject
{  
    
    private List<User> _allUsers { get; set; }
    public ObservableCollection<User> Users { get; set; }
    
    public MainViewModel()
    {
        _allUsers = new List<User>
        {
            new User { FirstName = "Neymar", LastName = "Júnior", Email = "neymar@email.com" },
            new User { FirstName = "Lionel", LastName = "Messi", Email = "messi@email.com" },
            new User { FirstName = "Cristiano", LastName = "Ronaldo", Email = "cristiano@email.com" },
        };
        
        Users = new ObservableCollection<User>(_allUsers);
    }

    [RelayCommand]
    private async void ExportData()
    {
        var savePicker = new FileSavePicker
        {
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            SuggestedFileName = "exported_users.txt"
        };
        savePicker.FileTypeChoices.Add("Arquivo de Texto", new[] { ".txt" });
        savePicker.SuggestedStartLocation = PickerLocationId.Downloads;
        
        StorageFile file = await savePicker.PickSaveFileAsync();

        if (file != null)
        { 
            CachedFileManager.DeferUpdates(file);
            try
            {
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        foreach (var user in Users)
                        {
                            await writer.WriteLineAsync($"{user.FirstName}, {user.LastName}, {user.Email}");
                        }
                        await writer.FlushAsync(); 
                    } 
                }     
                
                var status = await CachedFileManager.CompleteUpdatesAsync(file);

                if (status == FileUpdateStatus.Complete)
                { 
                    Console.WriteLine("Arquivo salvo com sucesso");
                }
                else
                {
                    Console.WriteLine($"Erro ao salvar o arquivo. Status: {status}");   
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao exportar dados: {e.Message}");
                SaveException(e);
            }
        }
    }
    
    [RelayCommand]
    private async void ImportData()
    {
        FileOpenPicker openPicker = new FileOpenPicker();
        openPicker.FileTypeFilter.Add(".txt");
        openPicker.SuggestedStartLocation = PickerLocationId.Downloads;
        
        StorageFile file = await openPicker.PickSingleFileAsync();

        if (file != null)
        { 
            try
            {
                using (var stream = await file.OpenStreamForReadAsync())
                {
                    using (var reader = new StreamReader(stream))
                    {
                        Users.Clear();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var user = line.Split(',');
                            Users.Add(new User { FirstName = user[0], LastName = user[1], Email = user[2] });
                        }
                    } 
                } 
                Console.WriteLine("Dados importados com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao importar dados: {e.Message}");
                SaveException(e);
            }
        }
    }

    private async void SaveException(Exception e)
    {
        try
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var fileName = "exceptions.txt";
            var exceptionsFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            var exceptionText = e.Message;
                    
            await FileIO.AppendTextAsync(exceptionsFile, exceptionText);
        } catch(Exception ex) {}  
    }
}
