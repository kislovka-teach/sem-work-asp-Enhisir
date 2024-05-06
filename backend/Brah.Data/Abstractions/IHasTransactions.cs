namespace Brah.BL.Abstractions;

public interface IHasTransactions
{
    /// <summary>
    /// Initiates a transaction scope.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// Executes the transaction.
    /// </summary>
    void CommitTransaction();
}