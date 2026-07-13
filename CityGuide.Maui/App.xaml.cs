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
            var window = new Window(new Views.RegisterPage());

            window.Width = 393;
            window.Height = 652;

            return window;
        }
    }
}