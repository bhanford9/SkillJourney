using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace SkillJourney.Client.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var serviceCollection = ClientDesktopContainer.InitializeGui();
        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }
}