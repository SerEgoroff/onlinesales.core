namespace SalesPro.Tests;

public class AccountsTests : SimpleTableTests<Account, TestAccount, AccountUpdateDto, IEntityService<Account>>
{
    public AccountsTests()
        : base("/api/accounts")
    {
    }

    protected override AccountUpdateDto UpdateItem(TestAccount to)
    {
        var from = new AccountUpdateDto();
        to.Name = from.Name = to.Name + "Updated";
        return from;
    }
}