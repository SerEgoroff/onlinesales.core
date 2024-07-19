namespace SalesPro.Tests.TestEntities;

public class TestContent : ContentCreateDto
{
    public TestContent(string uid = "")
    {
        Slug = $"test-slug{uid}";
        Type = "Test Template";
        Author = "John Doe";
        Title = $"Test Title (via test suit){uid}";
        Description = $"This is a sample test description{uid}";
        Body = $"This is a sample Content{uid}";
        CoverImageUrl = $"/api/images/{Slug}/cover.png";
        CoverImageAlt = $"This is a sample Cover alt{uid}";
        Language = "en-US";
        Category = "Product";
        Tags = new string[] { "Tag1" };
        AllowComments = true;
    }
}