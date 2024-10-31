namespace NewsPostApp.Entities
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }
        public string Title { get; set; }
        public string? MediaUrl { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }

    

    

    


}
