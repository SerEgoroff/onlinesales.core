namespace SalesPro.Interfaces;

public interface IMxVerifyService
{
    Task<bool> Verify(string mxValue);
}