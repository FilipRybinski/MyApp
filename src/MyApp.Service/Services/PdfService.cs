using MyApp.Core.Entities;
using MyApp.Core.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MyApp.Service.Services;

internal class PdfService : IPdfService
{
    public async Task<byte[]> PrintPdfDocument(IEnumerable<User> members)
    {
        return await Task.Run(() =>
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("List of members in team")
                        .SemiBold().FontSize(24).AlignCenter();

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Text("Name");
                                    header.Cell().Element(CellStyle).Text("Surname");
                                    header.Cell().Element(CellStyle).Text("Email");

                                    static IContainer CellStyle(IContainer container)
                                    {
                                        return container.DefaultTextStyle(x => x.SemiBold()).Padding(5)
                                            .Background(Colors.Grey.Lighten3);
                                    }
                                });
                                foreach (var member in members)
                                {
                                    table.Cell().Element(CellStyle).Text(member.Name);
                                    table.Cell().Element(CellStyle).Text(member.Surname);
                                    table.Cell().Element(CellStyle).Text(member.Email);
                                }

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container.Border(1).BorderColor(Colors.Grey.Lighten2).Padding(5);
                                }
                            });
                        });
                });
            });

            return document.GeneratePdf();
        });
    }
}