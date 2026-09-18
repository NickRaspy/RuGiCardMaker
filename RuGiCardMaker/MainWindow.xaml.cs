using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RuGiCardMaker;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ChooseArtwork_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog
        {
            Title = "Выберите изображение для образца карты",
            Filter = "Изображения (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
        };

        if (dialog.ShowDialog(this) != true)
            return;

        try
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(dialog.FileName);
            image.EndInit();
            CardArtwork.Source = image;
            CardArtwork.Visibility = Visibility.Visible;
            ArtworkFileLabel.Text = Path.GetFileName(dialog.FileName);
        }
        catch (Exception)
        {
            MessageBox.Show(this, "Не удалось открыть изображение. Выберите файл PNG или JPG.",
                "Ошибка изображения", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void ResetFields_Click(object sender, RoutedEventArgs e)
    {
        CardNameInput.Text = "Голубоглазый белый дракон";
        CardTypeInput.SelectedIndex = 0;
        CardSubtypeInput.SelectedIndex = 0;
        AttributeInput.SelectedIndex = 0;
        LevelInput.SelectedIndex = 7;
        RarityInput.SelectedIndex = 0;
        AttackInput.Text = "3000";
        DefenseInput.Text = "2500";
        EffectInput.Text = "Легендарный дракон, чьи крылья сияют в ночном небе.";
        CardArtwork.Source = null;
        CardArtwork.Visibility = Visibility.Collapsed;
        ArtworkFileLabel.Text = "Образец карты";
    }
}
