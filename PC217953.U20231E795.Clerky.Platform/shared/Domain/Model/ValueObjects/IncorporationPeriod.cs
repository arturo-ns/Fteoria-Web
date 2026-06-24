namespace PC217953.U20231E795.Clerky.Platform.shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents the period of a startup incorporation, defined by a start date and a completion date.
/// </summary>
/// <remarks>Author: PC217953 U20231E795</remarks>
public class IncorporationPeriod
{
    /// <summary>
    /// Gets the start date of the incorporation period.
    /// </summary>
    public DateOnly StartDate { get; private set; }

    /// <summary>
    /// Gets the completion date of the incorporation period.
    /// </summary>
    public DateOnly CompletionDate { get; private set; }

    /// <summary>
    /// Required by EF Core for owned entity materialization.
    /// </summary>
    private IncorporationPeriod()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="IncorporationPeriod"/>.
    /// </summary>
    /// <param name="startDate">The start date of the period.</param>
    /// <param name="completionDate">The completion date of the period.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="completionDate"/> is less than or equal to <paramref name="startDate"/>.
    /// </exception>
    public IncorporationPeriod(DateOnly startDate, DateOnly completionDate)
    {
        if (completionDate <= startDate)
            throw new ArgumentException(
                "Completion date must be greater than start date.",
                nameof(completionDate));

        StartDate = startDate;
        CompletionDate = completionDate;
    }

    /// <summary>
    /// Determines whether the incorporation period is completed as of the given date.
    /// </summary>
    /// <param name="checkDate">The date to evaluate against the completion date.</param>
    /// <returns><c>true</c> if <paramref name="checkDate"/> is after the completion date; otherwise, <c>false</c>.</returns>
    public bool IsCompleted(DateOnly checkDate) => checkDate > CompletionDate;
}
