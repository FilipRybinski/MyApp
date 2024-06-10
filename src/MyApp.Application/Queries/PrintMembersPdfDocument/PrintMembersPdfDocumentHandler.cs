using MyApp.Application.Abstractions;
using MyApp.Core.Repositories;
using MyApp.Core.Services;

namespace MyApp.Application.Queries.PrintMembersPdfDocument;

public class PrintMembersPdfDocumentHandler : IQueryHandler<PrintMembersPdfDocument, byte[]>
{
    private readonly IPdfService _pdfService;
    private readonly IUserRepository _userRepository;

    public PrintMembersPdfDocumentHandler(IPdfService pdfService, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _pdfService = pdfService;
    }

    public async Task<byte[]> HandleAsync(PrintMembersPdfDocument command)
    {
        var members = await _userRepository.GetUsersWithIdentifier(command.Members);
        return await _pdfService.PrintPdfDocument(members);
    }
}