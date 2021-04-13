using iText.Html2pdf.Css.Apply;
using iText.Html2pdf.Css.Apply.Impl;
using iText.StyledXmlParser.Node;
using System.Collections.Generic;

namespace HTMLtoPDFTemplateBuilder.CssApplierFactories
{
    class CustomCssApplierFactory : DefaultCssApplierFactory
    {
        private Dictionary<string, (string, PDFContentType)> _content;

        public CustomCssApplierFactory(Dictionary<string, (string, PDFContentType)> content)
        {
            _content = content;
        }
        public override ICssApplier GetCustomCssApplier(IElementNode tag)
        {
            if (_content.ContainsKey(tag.Name()))
            {
                switch (_content[tag.Name()].Item2)
                {
                    case PDFContentType.Text:
                        return new SpanTagCssApplier();
                    case PDFContentType.QRCode:
                        return new BlockCssApplier();
                    case PDFContentType.Barcode:
                        return new BlockCssApplier();
                }
            }

            return null;
        }
    }
}
