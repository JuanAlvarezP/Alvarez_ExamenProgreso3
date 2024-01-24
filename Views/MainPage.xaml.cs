using Alvarez_ExamenProgreso3.Services;
using Alvarez_ExamenProgreso3.ViewModels;

namespace Alvarez_ExamenProgreso3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(new ApiService());
        }
    }
}
