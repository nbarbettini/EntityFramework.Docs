using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFModeling.BulkConfiguration
{
    #region Money
    public readonly struct Money
    {
        public Money(decimal amount)
            => Amount = amount;

        public decimal Amount { get; }

        public override string ToString()
            => $"${Amount}";

        public class MoneyConverter : ValueConverter<Money, decimal>
        {
            public MoneyConverter()
                : base(
                    v => v.Amount,
                    v => new Money(v))
            {
            }
        }
    }
    #endregion
}
