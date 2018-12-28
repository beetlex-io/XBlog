using System;
using System.Collections.Generic;
using System.Text;
using Peanut;
using Peanut.Mappings;
namespace BeetleX.Blog.DBModules
{
    [Table]
    public interface ISequence
    {
        [ID]
        string Key { get; set; }
        [Column]
        long Value { get; set; }
    }

    public class SequenceID : Peanut.Mappings.ValueAttribute
    {
        public SequenceID() : base(false)
        {

        }
        public override void Executing(IConnectinContext cc, object data, PropertyMapper pm, string table)
        {
            long id = DBHelper.Default.GetSequence(table);
            pm.Handler.Set(data, id);
            base.Executing(cc, data, pm, table);
        }
    }
}
