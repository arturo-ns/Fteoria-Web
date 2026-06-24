namespace PC217953.U20231E795.Clerky.Platform.shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a monetary amount with a value and a currency.
/// Used as the result of monetary computations on <see cref="RegisteredCapital"/>.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class MonetaryAmount
{
    /// <summary>
    /// Gets the monetary value.
    /// </summary>
    public decimal Value { get; private set; }

    /// <summary>
    /// Gets the currency code (e.g., "USD", "EUR").
    /// </summary>
    public string Currency { get; private set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of <see cref="MonetaryAmount"/>.
    /// </summary>
    /// <param name="value">The monetary value.</param>
    /// <param name="currency">The currency code.</param>
    public MonetaryAmount(decimal value, string currency)
    {
        Value = value;
        Currency = currency;
    }
}
