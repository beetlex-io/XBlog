using System;
using System.Collections.Generic;
using System.Text;
using Peanut.Mappings;
namespace BeetleX.Blog.DBModules
{
    [Table]
    public interface IComment
    {
        [ID]
        [SequenceID]
        long ID { get; set; }
        [Column]
        string NickName { get; set; }
        [Column]
        string HeadUrl { get; set; }
        [Column]
        long BlogID { get; set; }
        [Column]
        string Content { get; set; }
        [Column]
        [NowDate]
        [DateTimeConvter]
        DateTime CreateTime { get; set; }
        [Column]
        string UserID { get; set; }
    }
    [Table("Comment inner join Blog on Comment.BlogID=Blog.ID")]
    public interface ITopComment
    {
        [Column("Blog.ID")]
        long ID { get; set; }
        [Column("Comment.ID")]
        long CommentID { get; set; }
        [Column]
        string Title { get; set; }
        [Column("Comment.Content")]
        string Content { get; set; }
        [Column]
        string NickName { get; set; }
        [Column("Comment.CreateTime")]
        [DateTimeConvter]
        DateTime CreateTime { get; set; }

    }
}
