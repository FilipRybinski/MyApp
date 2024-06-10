using MyApp.Application.Abstractions;

namespace MyApp.Application.Queries.PrintMembersPdfDocument;

public record PrintMembersPdfDocument(IEnumerable<Guid> Members) : IQuery<byte[]>;