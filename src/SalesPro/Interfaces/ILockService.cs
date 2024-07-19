namespace SalesPro.Interfaces;

public interface ILockService
{
    ILockHolder Lock(string key);

    ILockHolder? TryLock(string key);
}

public interface ILockHolder
{
}