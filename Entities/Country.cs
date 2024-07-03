using System.ComponentModel.DataAnnotations.Schema;

namespace AEDProject.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<DocumentType>? DocumentTypes { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
