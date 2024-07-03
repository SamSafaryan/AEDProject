using AEDProject.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AEDProject.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public string? strId { get; set; }
        public Sex Sex { get; set; }
        public DateOnly DOB { get; set; }
        public DateOnly ISS { get; set; }
        public DateOnly EXP { get; set; }
        public bool AllAngels { get; set; }
        public bool HaveSelfie { get; set; }
        public Sides Sides { get; set; }
        public bool SSN { get; set; }
        public bool Enable { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public Country? Country { get; set; }

		[ForeignKey("DocumentType")]
		public int? DocumentTypeId { get; set; }
        public DocumentType? DocumentType { get;set; }

		public ICollection<Image> Images { get; set; }
    }
}
