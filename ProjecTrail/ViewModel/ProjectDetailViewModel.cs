using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjecTrail.Database;
using ProjecTrail.Models;

namespace ProjecTrail.ViewModel
{
    public class ProjectDetailViewModel : ObservableObject
    {
        public Project Project { get; set; }
        private ProjectDatabase _projectDatabase;
        public ICommand SaveCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProjectDetailViewModel(Project project, ProjectDatabase projectDatabase)
        {
            Project = project;
            _projectDatabase = projectDatabase;
            SaveCommand = new Command(SaveProject);
        }

        private async void SaveProject()
        {
            try
            {
                // Hier fügen wir Logik zum Aktualisieren des Projekts in der Datenbank hinzu
                var dbProject = await _projectDatabase.GetItemAsync(Project.Id);
                if (dbProject != null)
                {
                    dbProject.Name = Project.Name;
                    dbProject.Beschreibung = Project.Beschreibung;
                    dbProject.Kostenstelle = Project.Kostenstelle;
                    // Weitere Eigenschaften nach Bedarf aktualisieren
                    if (_projectDatabase.Entry(dbProject).State == EntityState.Modified)
                    {
                        await _projectDatabase.SaveChangesAsync();
                        await ServiceProvider.DialogService.ShowInfoDialog("", $"Änderungen erfolgreich gespeichert.");
                    }
                    else
                    {
                        await ServiceProvider.DialogService.ShowInfoDialog("", $"Es wurden keine Änderungen vorgenommen.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await ServiceProvider.DialogService.ShowInfoDialog("Fehler",
                    $"Änderungen konnten nicht gespeichert werden. \n {e.Message}");
            }
        }
    }
}
