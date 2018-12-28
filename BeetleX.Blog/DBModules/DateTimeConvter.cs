using System;
using System.Collections.Generic;
using System.Text;

namespace BeetleX.Blog.DBModules
{
    public class DateTimeConvter : Peanut.Mappings.PropertyCastAttribute
    {
        public override object ToColumn(object value, Type ptype, object source)
        {
            return ((DateTime)value).Ticks;
        }
        public override object ToProperty(object value, Type ptype, object source)
        {
            return new DateTime((long)value);
        }
    }
}
