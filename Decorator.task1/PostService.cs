using System.Text.Json;

namespace Decorator.task1;

public class PostService : IPostService {
    private readonly HttpClient client;

    public PostService() {
        client = new HttpClient();
    }

    public async Task<Post?> GetPost(int postId) {
        var url = $"https://jsonplaceholder.typicode.com/posts/{postId}";
        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode) {
            var responseBody = await response.Content.ReadAsStringAsync();

            var post = JsonSerializer.Deserialize<Post?>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            return post;
        }
        else {
            throw new Exception($"Error: {response.StatusCode}");
        }
    }
}