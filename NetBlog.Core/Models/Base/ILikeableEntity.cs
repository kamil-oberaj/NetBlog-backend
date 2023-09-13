namespace NetBlog.Core.Models.Base;

public interface ILikeableEntity
{
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }
}
