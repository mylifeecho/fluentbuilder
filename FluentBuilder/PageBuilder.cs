using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
public class PageBuilder : IFirstStep, ISecondStep
{
    private readonly Document _document;

    internal PageBuilder(Document document)
    {
        _document = document;
    }

    public ISecondStep BackgroundImage(string imagePath)
    {
        var image = Image.GetInstance(imagePath);
      
        Rectangle pageSize = _document.PageSize;
        image.ScaleToFit(pageSize.Width, pageSize.Height);

        image.SetAbsolutePosition(0, pageSize.Height - image.ScaledHeight);
        _document.Add(image);
        return this;
    }

    public ISecondStep LeaveEmptyBackground() 
    { 
        return this; 
    }

    public ISecondStep AddParagraph(string text)
    {
        _document.Add(new Paragraph(text));
        return this;
    }
}
}
