using FluentValidation;
using FluentValidation.Results;
using MediatR;
using NetBlog.Application.Common.Exceptions;

namespace NetBlog.Application.Common.Behaviours;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        if (_validator is null)
            return await next();

        var validationResult = await _validator
            .ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
            return await next();

        IDictionary<string, string[]> errors =
            new Dictionary<string, string[]>();

        foreach (var result in validationResult.Errors)
        {
            if (result is null)
                continue;
            if (errors.Count != 0)
                AppendErrorsToDictionary(errors, result);
            else
                AddErrorToDictionary(errors, result);
        }

        throw new NetBlogValidationException(errors);
    }

    /// <summary>
    /// Adding new Key and errors as string array to dictionary
    /// </summary>
    /// <param name="errors"></param>
    /// <param name="result"></param>
    private static void AddErrorToDictionary(
        IDictionary<string, string[]> errors,
        ValidationFailure result)
    {
        errors.Add(
            result.PropertyName,
            new [] { result.ErrorMessage });
    }

    /// <summary>
    /// Checks if created error array contains the key, if it does
    /// we add new errors to the same Key
    /// else we create new entry in errors array
    /// </summary>
    /// <param name="errors"></param>
    /// <param name="result"></param>
    private static void AppendErrorsToDictionary(
        IDictionary<string, string[]> errors,
        ValidationFailure result)
    {
        if (errors.ContainsKey(result.PropertyName))
            AddErrorToExistingArray(errors, result);
        else
            AddErrorToDictionary(errors, result);
    }

    /// <summary>
    /// Adds new element to error array
    /// </summary>
    /// <param name="errors"></param>
    /// <param name="result"></param>
    private static void AddErrorToExistingArray(
        IDictionary<string, string[]> errors,
        ValidationFailure result)
    {
        ICollection<string> errorList =
            errors[result.PropertyName].ToList();
        errorList.Add(result.ErrorMessage);

        errors[result.PropertyName] = errorList.ToArray();
    }
}

