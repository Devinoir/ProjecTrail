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
using ProjecTrail.View;
using ProjecTrail.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProjecTrail.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly ProjectDatabase _projectDatabase;
        public ObservableCollection<Project> Projects { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand DeleteProjectCommand { get; }
        public ICommand CellTappedCommand { get; private set; }
        public ICommand NewProjectCommand { get; private set; }
        
        public MainPageViewModel(ProjectDatabase projectDatabase)
        {
            _projectDatabase = projectDatabase;
            Projects = new ObservableCollection<Project>();
            DeleteProjectCommand = new Command<Project>(async (Project project) => await AskToDeleteProject(project));
            CellTappedCommand = new Command<Project>(OnCellTapped);
            NewProjectCommand = new Command(CreateNewProject); 
            LoadProjectsFromDatabase();
        }

        private async void OnCellTapped(Project project)
        {
            if (project == null)
                return;

            var viewModel = new ProjectDetailViewModel(project, _projectDatabase);
            var detailPage = new ProjectDetailPage { BindingContext = viewModel };
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        private async void CreateNewProject()
        {
            var modalPage = new NewProjectModalPage(_projectDatabase);
            modalPage.OnModalClosed = RefreshProjects;
            await Application.Current.MainPage.Navigation.PushModalAsync(modalPage);
        }

        public async void RefreshProjects()
        {
            await LoadProjectsFromDatabase();
        }

        private async Task DeleteProject(Project project)
        {
            // Entfernen Sie das Projekt aus der Datenbank
            await _projectDatabase.DeleteItemAsync(project);
            OnPropertyChanged(nameof(Projects));

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
            var projects = await _projectDatabase.GetItemsAsync();
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
