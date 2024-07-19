namespace SalesPro.Tests.TestEntities;

public class TestComment : CommentCreateDto
{
    public TestComment(string uid = "", int commentableId = 0)
    {
        AuthorName = $"Test Author{uid}";
        AuthorEmail = $"contact{uid}@test{uid}.net";
        Body = $"Test Comment{uid}";
        CommentableId = commentableId;
        CommentableType = Content.GetCommentableType();
    }
}