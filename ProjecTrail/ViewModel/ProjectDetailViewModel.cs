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
using ProjecTrail.Models;

namespace ProjecTrail.ViewModel
{
    public class ProjectDetailViewModel : ObservableObject
    {
        public Project Project { get; set; }
        public ICommand SaveCommand { get; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ProjectDetailViewModel(Project project)
        {
            Project = project;
            SaveCommand = new Command(SaveProject);
        }

        private async void SaveProject()
        {
            // Hier fügen wir Logik zum Aktualisieren des Projekts in der Datenbank hinzu
            var dbProject = await App.DbContext.Projects.FirstOrDefaultAsync(p => p.Id == Project.Id);
            if (dbProject != null)
            {
                dbProject.Name = Project.Name;
                dbProject.Beschreibung = Project.Beschreibung;
                dbProject.Kostenstelle = Project.Kostenstelle;
                // Weitere Eigenschaften nach Bedarf aktualisieren

                await App.DbContext.SaveChangesAsync();
            }
        }
    }
}
