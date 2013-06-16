using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
    public class PDFBuilder : IDisposable
    {
        private Document _document;

        private PDFBuilder(Stream stream)
        {
            _document = new Document();
            PdfWriter.GetInstance(_document, stream);
            _document.SetPageSize(PageSize.A5);
            _document.Open();
        }

        /// <summary>
        /// Create and open pdf document.
        /// </summary>
        public static PDFBuilder CreateDocument(Stream stream)
        {
            return new PDFBuilder(stream);
        }
        /// <summary>
        /// Add pageto the document with specified page size.
        /// </summary>
        public PDFBuilder AddPage(Action<IFirstStep> page)
        {
            if (!_document.NewPage())
            {
                throw new InvalidOperationException("Unable to create page.");
            }
            _document.SetMargins(0, 0, 0, 0);

            page(new PageBuilder(_document));

            return this;
        }

        public void Save()
        {
            _document.Close();
        }

        public void Dispose()
        {
            if (_document != null)
            {
                _document.Dispose();
                _document = null;
            }
        }
    }
}
