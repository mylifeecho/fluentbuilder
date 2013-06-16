using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Drawing;

namespace FluentBuilder.Test
{
    [TestClass]
    public class FluentBuilderTest
    {
        [TestMethod]
        public void PDFGeneration()
        {
            using(var fileStream = new FileStream("Test.pdf", FileMode.Create))
            using(var builder = PDFBuilder.CreateDocument(fileStream)) 
            {
                builder
                    .AddPage(p => p
                        .BackgroundImage("background1.jpg")
                        .AddParagraph("first page content"))
                    .AddPage(p => p
                        .LeaveEmptyBackground()
                        .AddParagraph("second page content")
                        .AddParagraph("second page content2"))
                    .Save();
            }
        }
    }
}
