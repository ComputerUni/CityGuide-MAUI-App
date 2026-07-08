using SQLite;

namespace CityGuide.Maui.Models
{
    [Table("Categories")]
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string CategoryName { get; set; } = string.Empty;
    }
}
