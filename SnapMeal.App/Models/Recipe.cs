namespace SnapMeal.API.Models
{
	public class Recipe
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Ingredients { get; set; }
		public string Instructions { get; set; }
		public string ImageUrl { get; set; }  // URL obrázku uloženého v Azure Blob Storage
	}
}
