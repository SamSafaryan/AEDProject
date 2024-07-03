namespace AEDProject.ViewModels
{
	public class DocTypeViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? CountryName { get; set; }
		public List<int> CountryIds { get; set; }
	}
}
