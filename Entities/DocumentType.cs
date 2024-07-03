namespace AEDProject.Entities
{
    public class DocumentType
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Country>? Countries { get; set; }
    }
}
