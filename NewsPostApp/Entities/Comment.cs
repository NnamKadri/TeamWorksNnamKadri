namespace NewsPostApp.Entities
{
    
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string? Content { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public Guid CommenterId { get; set; }
        public User Commenter { get; set; }
    }


}
