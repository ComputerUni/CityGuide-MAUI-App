using CityGuide.Maui.Models;
using CityGuide.Maui.Services;

namespace CityGuide.Maui.Views;

public partial class CulturePage : ContentPage
{
	private readonly AppDatabase _db = new AppDatabase();
	private List<Event> _allEvents = new List<Event>();
	public CulturePage()
	{
		InitializeComponent();
	}

	//Sayfa ekrana geldiğinde çalışır.
	protected override async void OnAppearing()
	{
		base.OnAppearing();

        var categories = await _db.GetCategoriesAsync();

        // Listenin başına "Tümü" ekle (veritabanında yok, sadece arayüz için)
        categories.Insert(0, new Category { Id = 0, CategoryName = "Tümü" });
        CategoriesCollection.ItemsSource = categories;

		//Etkinlikler: bir kez çek, bellekte sakla
		_allEvents = await _db.GetEventsWithCategoryAsync();

		//Başlangıçta hepsini göster.
        EventsCollection.ItemsSource = _allEvents;

		//Başlangıçta "Tümü" seçili olsun (listenin ilk ögesi)
		CategoriesCollection.SelectedItem = categories[0];
    }

	//Bir kategori hapına tıklanınca çalışır.
	private void OnCategorySelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		//Tıklanan hapın bağlı olduğu kategori nesnesini al
		//if (sender is not Border border) return;
		//if (border.BindingContext is not Category category) return;

		if (e.CurrentSelection.FirstOrDefault() is not Category category)
			return;

		if(category.Id == 0)
		{
			//Tümü --> Hepsini Göster
			EventsCollection.ItemsSource = _allEvents;
		}
		else
		{
			//Seçilen kategoriye ait etkinlikleri filtrele
			var filtered = _allEvents
				.Where(ev => ev.CategoryId == category.Id)
				.ToList();

			EventsCollection.ItemsSource = filtered;
		}
	}
}