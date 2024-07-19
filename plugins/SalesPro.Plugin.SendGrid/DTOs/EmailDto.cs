namespace SalesPro.Plugin.SendGrid.DTOs;

public class EmailDto
{
    private string email = string.Empty;

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value.ToLower();
        }
    }
}