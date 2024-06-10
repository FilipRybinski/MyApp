using MyApp.Core.Entities;

namespace MyApp.Core.Services;

public interface IPdfService
{
    Task<byte[]> PrintPdfDocument(IEnumerable<User> members);
}