using System.ComponentModel.DataAnnotations.Schema;

namespace AEDProject.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        [ForeignKey("Document")]
        public int DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
