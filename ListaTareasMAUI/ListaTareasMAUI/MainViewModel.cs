using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ListaTareasMAUI
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TaskItem> tasks;

        [ObservableProperty]
        private string newTaskName;

        public MainViewModel()
        {
            Tasks = new ObservableCollection<TaskItem>();
            CargarTareasEjemplo();
        }

        [RelayCommand]
        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(NewTaskName))
            {
                Tasks.Add(new TaskItem
                {
                    Id = Tasks.Count + 1,
                    Name = NewTaskName,
                    IsCompleted = false,
                    CreatedAt = DateTime.Now
                });
                NewTaskName = string.Empty; // Se limpia el renglón para el siguiente machetazo
            }
        }

        [RelayCommand]
        private void DeleteTask(TaskItem task)
        {
            if (task != null)
                Tasks.Remove(task);
        }

        private void CargarTareasEjemplo()
        {
            Tasks.Add(new TaskItem { Id = 1, Name = "Hacer mercado en el D1 de Belmonte", IsCompleted = false });
            Tasks.Add(new TaskItem { Id = 2, Name = "Estudiar MAUI para RaulSaurio", IsCompleted = true });
        }
    }
}