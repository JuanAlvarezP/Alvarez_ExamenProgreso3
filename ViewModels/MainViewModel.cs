using Alvarez_ExamenProgreso3.Models;
using Alvarez_ExamenProgreso3.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Alvarez_ExamenProgreso3.ViewModels
{

    public class MainViewModel : BaseViewModel
    {
        private ApiService _apiService;

        private ObservableCollection<FactModel> _facts = new ObservableCollection<FactModel>();
        public ObservableCollection<FactModel> Facts
        {
            get { return _facts; }
            set
            {
                if (_facts != value)
                {
                    _facts = value;
                    OnPropertyChanged(); // Asegúrate de invocar OnPropertyChanged sin argumentos para notificar cambios en la colección
                }
            }
        }

        public Command GetFactsCommand { get; }

        public MainViewModel(ApiService apiService)
        {
            _apiService = apiService;

            GetFactsCommand = new Command(async () => await GetFacts());
        }

        private async Task GetFacts()
        {
            try
            {
                Console.WriteLine("Iniciando GetFacts");

                // Obtener fun facts de la API
                List<FactModel> newFacts = await _apiService.GetFactsAsync(1); // Cambié el parámetro a 1

                Console.WriteLine($"Obtenidos {newFacts.Count} Fun Facts");

                // Actualizar la colección Facts
                Facts.Clear();
                foreach (var fact in newFacts)
                {
                    Facts.Add(fact);
                }

                Console.WriteLine("Datos actualizados en la colección Facts");

                // No necesitas guardar en SQLite según tus requisitos

            }
            catch (Exception ex)
            {
                // Manejar la excepción de manera adecuada, como registrarla o presentar un mensaje al usuario.
                Console.WriteLine($"Error al obtener Fun Facts: {ex.Message}");
            }
        }
    }

}
