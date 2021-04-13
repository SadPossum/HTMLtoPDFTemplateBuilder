using iText.Barcodes;
using iText.Html2pdf.Attach;
using iText.Layout;
using iText.Layout.Element;
using iText.StyledXmlParser.Node;

namespace HTMLtoPDFTemplateBuilder.TagWorkers
{
    class BarcodeTagWorker : ITagWorker
    {
        private string _content;
        private Barcode128 barcode;
        private Image BarcodeAsImage;

        public BarcodeTagWorker(IElementNode tag, ProcessorContext context, string content)
        {
            _content = content;

            barcode = new Barcode128(context.GetPdfDocument());
        }


        public void ProcessEnd(IElementNode element, ProcessorContext context)
        {
            BarcodeAsImage = new Image(barcode.CreateFormXObject(context.GetPdfDocument()));
        }

        public bool ProcessContent(string content, ProcessorContext context)
        {
            barcode.SetCode(_content);
            return true;
        }

        public bool ProcessTagChild(ITagWorker childTagWorker, ProcessorContext context)
        {
            return false;
        }

        public IPropertyContainer GetElementResult()
        {
            return BarcodeAsImage;
        }
    }
}
