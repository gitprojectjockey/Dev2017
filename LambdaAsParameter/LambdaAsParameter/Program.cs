using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaAsParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            var widgets = new List<Widget>()
            {
                new Widget(){ Id=1, Name="Blue Widget", Created = DateTime.Now.AddDays(-33), LotCode="QQRT44" },
                new Widget(){ Id=2, Name="Red Widget", Created = DateTime.Now.AddDays(-44), LotCode="QQRT55" },
                new Widget(){ Id=3, Name="Green Widget", Created = DateTime.Now.AddDays(-55), LotCode="QQRT66" },
                new Widget(){ Id=4, Name="Puple Widget", Created = DateTime.Now.AddDays(-66), LotCode="QQRT77" },
                new Widget(){ Id=5, Name="Orange Widget", Created = DateTime.Now.AddDays(-77), LotCode="QQRT88" }
            };


            Func<Widget, string> widgetNameFormatter = w => $" Widget Name: {w.Name}, ";
            Func<Widget, string> widgetCreatedDateFormatter = w => $"Widget Name: {w.Name} Was Created On: {w.Created.ToShortDateString()}, ";
            Func<Widget, string> widgetLotCodeFormatter = w => $"Widget: {w.Name}  Lot Code: {w.LotCode}, ";


            var formattedWidgetNames = string.Empty;
            var formattedWidgetCreationDate = string.Empty;
            var formattedLotCodes = string.Empty;
            foreach (var w in widgets)
            {
                formattedWidgetNames += FormatWidgetData(widgetNameFormatter, w);
                formattedWidgetCreationDate += FormatWidgetData(widgetCreatedDateFormatter, w);
                formattedLotCodes += FormatWidgetData(widgetLotCodeFormatter,w);
            }
        }

        public static string FormatWidgetData(Func<Widget, string> formatter, Widget widget)
        {
            if (formatter != null)
            {
                return formatter(widget).ToUpper();
            }
            return null;
        }
    }
}
