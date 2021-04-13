using HTMLtoPDFTemplateBuilder.TagWorkers;
using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Impl;
using iText.StyledXmlParser.Node;
using System.Collections.Generic;

namespace HTMLtoPDFTemplateBuilder.TagWorkerFactories
{
    class CustomTagWorkerFactory : DefaultTagWorkerFactory
    {
        private Dictionary<string, (string, PDFContentType)> _content;

        public CustomTagWorkerFactory(Dictionary<string, (string, PDFContentType)> content)
        {
            _content = content;
        }
        public override ITagWorker GetCustomTagWorker(IElementNode tag, ProcessorContext context)
        {
            var g = tag.Name();
            if (_content.ContainsKey(tag.Name()))
            {
                switch (_content[tag.Name()].Item2)
                {
                    case PDFContentType.Text:
                        return new TextTagWorker(tag, context, _content[tag.Name()].Item1);
                    case PDFContentType.QRCode:
                        return new QRCodeTagWorker(tag, context, _content[tag.Name()].Item1);
                    case PDFContentType.Barcode:
                        return new BarcodeTagWorker(tag, context, _content[tag.Name()].Item1);
                }
            }

            return null;
        }

    }
}
