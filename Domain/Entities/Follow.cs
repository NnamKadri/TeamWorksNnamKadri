namespace NewsPostApp.Entities
{
    // Domain/Entities/Follow.cs
    public class Follow : BaseEntity
    {
        public Guid FollowerUserId { get; set; }
        public User FollowerUser { get; set; }
        public Guid FollowedUserId { get; set; }
        public User FollowedUser { get; set; }
    }


}
