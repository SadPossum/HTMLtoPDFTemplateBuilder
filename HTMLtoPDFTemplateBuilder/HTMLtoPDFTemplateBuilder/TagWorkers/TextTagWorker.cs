using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Impl.Tags;
using iText.StyledXmlParser.Node;

namespace HTMLtoPDFTemplateBuilder.TagWorkers
{
    class TextTagWorker : SpanTagWorker
    {
        private string _content;

        public TextTagWorker(IElementNode element, ProcessorContext context, string content) : base(element,
            context)
        {
            _content = content;
        }

        public override bool ProcessContent(string content, ProcessorContext context)
        {
            return base.ProcessContent(_content, context);
        }
    }
}
