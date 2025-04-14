using DinkToPdf;
using DinkToPdf.Contracts;

namespace EMuhasebeWeb.Helpers
{
    public static class PdfGenerator
    {
        public static byte[] GeneratePdfFromHtml(string html)
        {
            var converter = new SynchronizedConverter(new PdfTools());

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings { Top = 20, Bottom = 20 }
                },
                Objects = {
                    new ObjectSettings {
                        HtmlContent = html,
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return converter.Convert(doc);
        }
    }
}
