using FluentValidation.Results;

namespace Application.Exceptions;

public class SysValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; }

    public SysValidationException()
        : base("Validation errors have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public SysValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(
                failureGroup => failureGroup.Key,
                failureGroup => failureGroup.ToArray()
            );
    }
}
