using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
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
        public Action OnModalClosed { get; set; }

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
                    // Updating the project properties
                    dbProject.Name = Project.Name;
                    dbProject.Beschreibung = Project.Beschreibung;
                    dbProject.Kostenstelle = Project.Kostenstelle;
                    // Update other properties as needed

                    // Using SQLite-net to update the project
                    var updateResult = await _projectDatabase.SaveItemAsync(dbProject);

                    // SQLite-net's UpdateAsync method returns the number of rows affected.
                    // If updateResult is greater than 0, it means the update was successful.
                    if (updateResult > 0)
                    {
                        await ServiceProvider.DialogService.ShowInfoDialog("", $"Änderungen erfolgreich gespeichert.");
                    }
                    else
                    {
                        // If no rows were affected, it means no changes were made to the database.
                        await ServiceProvider.DialogService.ShowInfoDialog("", $"Es wurden keine Änderungen vorgenommen.");
                    }
                    OnModalClosed?.Invoke();
                }

                await Application.Current.MainPage.Navigation.PopModalAsync();
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
