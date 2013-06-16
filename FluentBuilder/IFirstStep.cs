using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
    public interface IFirstStep
    {
        ISecondStep BackgroundImage(string imagePath);
        ISecondStep LeaveEmptyBackground();
    }
}
