namespace NewsPostApp.Entities
{
    public class Post
    {
        public Guid PostId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string? MediaUrl { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }

        //public void AddComment(string content, User commenter)
        //{
        //    Comments.Add(new Comment { Content = content, Commenter = commenter });
        //}

        //public void LikePost(User user)
        //{
        //    if (!Likes.Any(l => l.UserId == user.UserId))
        //    {
        //        Likes.Add(new Like { PostId = this.PostId, UserId = user.UserId });
        //    }
        //}

        //public void UnlikePost(User user)
        //{
        //    var like = Likes.FirstOrDefault(l => l.UserId == user.UserId);
        //    if (like != null)
        //    {
        //        Likes.Remove(like);
        //    }
        //}
    }

}
