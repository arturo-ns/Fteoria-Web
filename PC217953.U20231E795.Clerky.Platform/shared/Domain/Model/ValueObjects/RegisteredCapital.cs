namespace PC217953.U20231E795.Clerky.Platform.shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents the registered capital of a startup incorporation, consisting of a monetary value and a currency.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class RegisteredCapital
{
    /// <summary>
    /// Gets the capital value. Must be greater than or equal to zero.
    /// </summary>
    public decimal Value { get; private set; }

    /// <summary>
    /// Gets the currency code (e.g., "USD", "EUR").
    /// </summary>
    public string Currency { get; private set; } = string.Empty;

    /// <summary>
    /// Required by EF Core for owned entity materialization.
    /// </summary>
    private RegisteredCapital()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="RegisteredCapital"/>.
    /// </summary>
    /// <param name="value">The capital value. Must be greater than or equal to zero.</param>
    /// <param name="currency">The currency code. Must not be null or blank.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is less than <see cref="decimal.Zero"/>.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="currency"/> is null or blank.
    /// </exception>
    public RegisteredCapital(decimal value, string currency)
    {
        if (value < decimal.Zero)
            throw new ArgumentOutOfRangeException(
                nameof(value),
                "Registered capital value must be greater than or equal to zero.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentNullException(
                nameof(currency),
                "Registered capital currency must not be null or blank.");

        Value = value;
        Currency = currency;
    }

    /// <summary>
    /// Multiplies the capital value by the given factor and returns the resulting monetary amount
    /// with the same currency.
    /// </summary>
    /// <param name="factor">The factor to multiply by.</param>
    /// <returns>A <see cref="MonetaryAmount"/> representing the result of the multiplication.</returns>
    public MonetaryAmount Multiply(decimal factor) => new MonetaryAmount(Value * factor, Currency);
}
