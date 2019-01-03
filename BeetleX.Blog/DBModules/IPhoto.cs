using System;
using System.Collections.Generic;
using System.Text;
using Peanut.Mappings;
namespace BeetleX.Blog.DBModules
{
    [Table]
    public interface IPhoto
    {
        [ID]
        [SequenceID]
        long ID { get; set; }
        [Column]
        string Title { get; set; }
        [Column]
        [DateTimeConvter]
        [NowDate]
        DateTime CreateTime { get; set; }
        [Column]
        string SmallUrl { get; set; }
        [Column]
        string LargeUrl { get; set; }
    }
    [Table]
    public interface IPhotoItem
    {
        [ID]
        string ID { get; set; }
        [Column]
        long PhotoID { get; set; }
        [Column]
        string LargeUrl { get; set; }
        [Column]
        string SmallUrl { get; set; }
    }
}
