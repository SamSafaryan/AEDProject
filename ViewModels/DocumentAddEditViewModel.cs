using AEDProject.Entities.Enums;
using AEDProject.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEDProject.ViewModels
{
    public class DocumentAddEditViewModel
    {
        public int Id { get; set; }
        public string strId { get; set; }
        public int? CountryId { get; set; }
        public int? DocumentTypeId {  get; set; }
        public Sex Sex { get; set; }
        public DateOnly DOB { get; set; }
        public DateOnly ISS { get; set; }
        public DateOnly EXP { get; set; }
        public bool AllAngels { get; set; }
        public bool HaveSelfie { get; set; }
        public Sides Sides { get; set; }
        public bool SSN { get; set; }
        public bool Enable { get; set; }
        public string? CountryName {  get; set; }
		public string? DocTypeName {  get; set; }
		public List<ImageViewModel> Images { get; set; }
        public List<int> ImageIds { get; set; }

	}
}
