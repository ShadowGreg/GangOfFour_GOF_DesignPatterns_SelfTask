using Decorator.task1;

public class Program {
    public static async Task Main(string[] args) {
        var postService = new PostService();
        try {
            var post = await postService.GetPost(1);
            Console.WriteLine(post);
        }
        catch (Exception) {
            throw;
        }
    }
}