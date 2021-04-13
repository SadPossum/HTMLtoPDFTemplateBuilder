using HTMLtoPDFTemplateBuilder.CssApplierFactories;
using HTMLtoPDFTemplateBuilder.TagWorkerFactories;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.Kernel.Pdf;
using iText.Layout.Font;
using System.Collections.Generic;
using System.IO;

namespace HTMLtoPDFTemplateBuilder
{
    public static class PdfCreator
    {
        public static byte[] Create(byte[] htmlBytes, Dictionary<string, (string, PDFContentType)> content)
        {
            using (var streamPdf = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(streamPdf);
                var pdf = new PdfDocument(writer);

                Stream streamHtml = new MemoryStream(htmlBytes);

                FontProvider fontProvider = new DefaultFontProvider(true, true, true);
                ConverterProperties properties = new ConverterProperties();

                properties
                    .SetCssApplierFactory(new CustomCssApplierFactory(content))
                    .SetTagWorkerFactory(new CustomTagWorkerFactory(content))
                    .SetFontProvider(fontProvider);

                HtmlConverter.ConvertToPdf(streamHtml, pdf, properties);

                return streamPdf.ToArray();
            }
        }
    }
}
