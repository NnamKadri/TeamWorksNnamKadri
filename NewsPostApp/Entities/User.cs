namespace NewsPostApp.Entities
{

    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Follow> Following { get; set; }
        public ICollection<Follow> Followers { get; set; }

        // Business logic methods (follow/unfollow, create profile, etc.)
        //public void Follow(User userToFollow)
        //{
        //    if (!Following.Any(f => f.FollowedUserId == userToFollow.UserId))
        //    {
        //        Following.Add(new Follow { FollowerUserId = this.UserId, FollowedUserId = userToFollow.UserId });
        //    }
        //}

        //public void Unfollow(User userToUnfollow)
        //{
        //    var follow = Following.FirstOrDefault(f => f.FollowedUserId == userToUnfollow.UserId);
        //    if (follow != null)
        //    {
        //        Following.Remove(follow);
        //    }
        //}
    }


}
