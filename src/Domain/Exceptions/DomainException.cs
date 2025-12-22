using System.Diagnostics.CodeAnalysis;

namespace Domain.Exceptions;

[ExcludeFromCodeCoverage]
internal abstract class DomainException(string message) : Exception(message)
{

}