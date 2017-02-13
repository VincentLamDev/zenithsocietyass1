using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZenithDataLib.Models;

namespace ZenithWebSite.Compare
{
    public class CustomCompare : IComparer<Event>
    {
        public int Compare(Event x, Event y)
        {
            int result = DateTime.Compare(x.Start, y.Start);
            return result;
        }
    }
}