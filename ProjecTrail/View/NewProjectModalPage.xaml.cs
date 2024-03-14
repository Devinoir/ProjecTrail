using CommunityToolkit.Mvvm.Messaging;
using ProjecTrail.Database;
using ProjecTrail.MessageClasses;
using ProjecTrail.Models;

namespace ProjecTrail.View;

public partial class NewProjectModalPage : ContentPage
{
    private readonly ProjectDatabase _projectDatabase;
    public Action OnModalClosed { get; set; }

    public NewProjectModalPage(ProjectDatabase projectDatabase)
    {
        _projectDatabase = projectDatabase;
        InitializeComponent();
    }

    private async void OnCreateProjectClicked(object sender, EventArgs e)
    {
        if (!IsValidProjectData())
        {
            await Navigation.PopModalAsync();
            return;
        }

        var neuesProjekt = new Project
        {
            Name = ProjectNameEntry.Text,
            Beschreibung = ProjectDescriptionEntry.Text,
            Erstelldatum = DateTime.Now,
            Kostenstelle = ProjectKostenstelleEntry.Text,
            // Hier können Sie weitere Daten setzen
        };

        // Speichern des Projekts in der Datenbank
        await _projectDatabase.SaveItemAsync(neuesProjekt);
        OnModalClosed?.Invoke();
        await Navigation.PopModalAsync();
    }

    private bool IsValidProjectData()
    {
        // Der Projektname muss gesetzt sein; Beschreibung und Kostenstelle sind optional
        return !string.IsNullOrWhiteSpace(ProjectNameEntry.Text);
    }
}
