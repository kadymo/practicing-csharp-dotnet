using System.Windows;

namespace Lab3;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void RevelationButton_Click(object sender, RoutedEventArgs e)
    {
        RevelationText.Text = "O Corinthians é o maior clube do Brasil.";
        RevelationButton.IsEnabled = false;
        RevelationButton.Content = "Revelado!";
    }
}