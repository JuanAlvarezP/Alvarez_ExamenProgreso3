using Alvarez_ExamenProgreso3.Services;
using Alvarez_ExamenProgreso3.ViewModels;

namespace Alvarez_ExamenProgreso3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var apiService = new ApiService();
            var mainViewModel = new MainViewModel(apiService);

            MainPage = new NavigationPage(new MainPage { BindingContext = mainViewModel });
        }
    }
}
