namespace SalesPro.Tests.TestEntities;

public class TestEmailTemplate : EmailTemplateCreateDto
{
    public TestEmailTemplate(string uid = "", int groupId = 0)
    {
        this.Name = $"TestEmailTemplate{uid}";
        this.Subject = $"TestEmailTemaplteSubject{uid}";
        this.BodyTemplate = $"TestEmailTemaplteSubjectBodyTemplate{uid}";
        this.FromEmail = $"test{uid}@test.net";
        this.FromName = "TestEmailTemaplteFromName";
        this.Language = "en";
        this.EmailGroupId = groupId;
    }
}