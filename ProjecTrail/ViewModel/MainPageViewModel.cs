using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ProjecTrail.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ProjecTrail.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _dbContext;
        public ObservableCollection<Project> Projects { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DeleteProjectCommand { get; }

        private readonly IDialogService _dialogService;

        public MainPageViewModel()
        {
            _dbContext = App.DbContext;
            Projects = new ObservableCollection<Project>();
            DeleteProjectCommand = new Command<Project>(async (Project project) => await AskToDeleteProject(project));
            LoadProjectsFromDatabase();
        }

        private async Task DeleteProject(Project project)
        {
            // Entfernen Sie das Projekt aus der Datenbank
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();

            // Entfernen Sie das Projekt aus der ObservableCollection
            Projects.Remove(project);
        }

        private async Task AskToDeleteProject(Project project)
        {
            var confirm = await ServiceProvider.DialogService.ShowConfirmDialog(
                "Projekt löschen",
                "Sind Sie sicher, dass Sie dieses Projekt löschen möchten?",
                "Ja",
                "Nein");

            if (confirm)
            {
                await DeleteProject(project);
            }
        }

        public async Task LoadProjectsFromDatabase()
        {
            var projects = await _dbContext.Projects.ToListAsync();
            Projects.Clear();
            foreach (var project in projects)
            {
                Projects.Add(project);
            }
        }

        // Implementierung der INotifyPropertyChanged-Schnittstelle
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
