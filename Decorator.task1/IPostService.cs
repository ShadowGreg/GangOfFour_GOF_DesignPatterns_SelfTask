namespace Decorator.task1;

public interface IPostService {
    Task<Post?> GetPost(int postId);
}