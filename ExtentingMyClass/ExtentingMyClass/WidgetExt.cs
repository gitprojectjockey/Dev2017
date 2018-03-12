using System;
using System.Collections.Generic;
using System.Text;

namespace ExtentingMyClass
{
    public static class WidgetExt
    {
        public static string GetLoadingDockLocationCode(this Widget Widget, Widget widget)
        {
            return $"{widget.LotCode}-{widget.Id}-{widget.Created}";
        }

    }
}
