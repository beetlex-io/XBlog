using System;
using System.Collections.Generic;
using System.Text;

namespace BeetleX.Blog.DBModules
{
    public class BoolConvter : Peanut.Mappings.PropertyCastAttribute
    {
        public override object ToColumn(object value, Type ptype, object source)
        {
            if ((bool)value)
            {
                return 1;
            }
            else
                return 0;
        }
        public override object ToProperty(object value, Type ptype, object source)
        {
            return value != null && (long)value > 0;
        }
    }
}
