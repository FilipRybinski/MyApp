using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Application.Queries.PrintMembersPdfDocument;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PrintController : ControllerBase
{
    private readonly IQueryHandler<PrintMembersPdfDocument, byte[]> _printMembersPdfDocumentHandler;

    public PrintController(IQueryHandler<PrintMembersPdfDocument, byte[]> printMembersPdfDocumentHandler)
    {
        _printMembersPdfDocumentHandler = printMembersPdfDocumentHandler;
    }

    [HttpPost("[action]")]
    public async Task<FileResult> PrintMembersPdfDocument(PrintMembersPdfDocument query)
    {
        var blob = await _printMembersPdfDocumentHandler.HandleAsync(query);
        return File(blob, "application/pdf", "test.pdf");
    }
}