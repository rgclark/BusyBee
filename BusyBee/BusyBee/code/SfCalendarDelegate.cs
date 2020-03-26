using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfCalendar.XForms;

namespace BusyBee
{
  

        //public override SFMonthCell DidDrawMonthCell(SFCalendar calendar, SFMonthCell monthCell)
        //{
        //    NSCalendar cal = NSCalendar.CurrentCalendar;
        //    NSDateComponents startDateComponents = cal.Components(
        //        NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, monthCell.Date);
        //    if (startDateComponents.Day == 12 || startDateComponents.Day == 15 || startDateComponents.Day == 17)
        //    {
        //        UIView view = new UIView();
        //        view.Frame = new CoreGraphics.CGRect(0, 0, 30, 30);
        //        view.AddSubview(new UILabel() { Text = startDateComponents.Day.ToString(), Frame = new CoreGraphics.CGRect(15, 35, 30, 30) });
        //        view.AddSubview(new UILabel() { Text = "4", TextColor = UIColor.Red, Frame = new CoreGraphics.CGRect(15, 60, 50, 30) });
        //        monthCell.View = view;
        //    }
        //    return monthCell;
        //}

}
