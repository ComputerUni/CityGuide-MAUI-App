namespace CityGuide.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //Başlangıç ekranı için App.xaml.cs dosyasında başlangıç ekranını burada belirliyoruz.
            return new Window(new Views.CulturePage());
        }
    }
}