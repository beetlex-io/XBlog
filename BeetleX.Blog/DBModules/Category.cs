using System;
using System.Collections.Generic;
using System.Text;
using Peanut.Mappings;
namespace BeetleX.Blog.DBModules
{
    [Table]
    public interface ICategory
    {
        [ID]
        [SequenceID]
        long ID { get; set; }
        [Column]
        string Name { get; set; }
        [Column]
        string Remark { get; set; }
        [Column]
        int OrderBy { get; set; }
    }
}
