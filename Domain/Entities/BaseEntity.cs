namespace NewsPostApp.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } // Primary key
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false; // Soft deletion flag
    }

}
