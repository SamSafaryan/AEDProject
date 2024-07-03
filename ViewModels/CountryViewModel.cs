using AEDProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEDProject.ViewModels
{
	public class CountryViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? DocTypeName { get; set; }
		public List<int> DocTypeIds { get; set; }
	}
}
