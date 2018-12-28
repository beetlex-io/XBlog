using System;
using System.Collections.Generic;
using System.Text;
using Peanut.Mappings;
namespace BeetleX.Blog.DBModules
{
    [Table]
    public interface IBlog
    {
        [ID]
        [SequenceID]
        long ID { get; set; }
        [Column]
        string Title { get; set; }
        [Column]
        [BoolConvter]
        bool Top { get; set; }
        [Column]
        string Content { get; set; }
        [Column]
        string Summary { get; set; }
        [Column]
        string Category { get; set; }
        [Column]
        long CategoryID { get; set; }
        [Column]
        string Tags { get; set; }
        [Column]
        string SourceUrl { get; set; }
        [Column]
        [DateTimeConvter]
        [NowDate]
        DateTime CreateTime { set; get; }
    }

    [Table]
    public interface IRefreshBlog
    {
        [Column]
        long BlogID { get; set; }
        [Column]
        [DateTimeConvter]
        [NowDate]
        DateTime CreateTime { get; set; }
        [Column]
        int Status { get; set; }

    }
}
