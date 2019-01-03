using System;
using System.Collections.Generic;
using System.Text;
using Peanut.Mappings;

namespace BeetleX.Blog.DBModules
{
    ///<summary>
    ///Peanut Generator Copyright @ henryfan 2018 email:henryfan@msn.com
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Photo : Peanut.Mappings.DataObject
    {
        private long mID;
        public static Peanut.FieldInfo<long> iD = new Peanut.FieldInfo<long>("Photo", "ID");
        private string mTitle;
        public static Peanut.FieldInfo<string> title = new Peanut.FieldInfo<string>("Photo", "Title");
        private DateTime mCreateTime;
        public static Peanut.FieldInfo<DateTime> createTime = new Peanut.FieldInfo<DateTime>("Photo", "CreateTime");
        private string mSmallUrl;
        public static Peanut.FieldInfo<string> smallUrl = new Peanut.FieldInfo<string>("Photo", "SmallUrl");
        private string mLargeUrl;
        public static Peanut.FieldInfo<string> largeUrl = new Peanut.FieldInfo<string>("Photo", "LargeUrl");
        ///<summary>
        ///Type:long
        ///</summary>
        [ID()]
        [SequenceID]
        public virtual long ID
        {
            get
            {
                return mID;
                
            }
            set
            {
                mID = value;
                EntityState.FieldChange("ID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Title
        {
            get
            {
                return mTitle;
                
            }
            set
            {
                mTitle = value;
                EntityState.FieldChange("Title");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column()]
        [DateTimeConvter]
        [NowDate]
        public virtual DateTime CreateTime
        {
            get
            {
                return mCreateTime;
                
            }
            set
            {
                mCreateTime = value;
                EntityState.FieldChange("CreateTime");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string SmallUrl
        {
            get
            {
                return mSmallUrl;
                
            }
            set
            {
                mSmallUrl = value;
                EntityState.FieldChange("SmallUrl");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string LargeUrl
        {
            get
            {
                return mLargeUrl;
                
            }
            set
            {
                mLargeUrl = value;
                EntityState.FieldChange("LargeUrl");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ henryfan 2018 email:henryfan@msn.com
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class PhotoItem : Peanut.Mappings.DataObject
    {
        private string mID;
        public static Peanut.FieldInfo<string> iD = new Peanut.FieldInfo<string>("PhotoItem", "ID");
        private long mPhotoID;
        public static Peanut.FieldInfo<long> photoID = new Peanut.FieldInfo<long>("PhotoItem", "PhotoID");
        private string mLargeUrl;
        public static Peanut.FieldInfo<string> largeUrl = new Peanut.FieldInfo<string>("PhotoItem", "LargeUrl");
        private string mSmallUrl;
        public static Peanut.FieldInfo<string> smallUrl = new Peanut.FieldInfo<string>("PhotoItem", "SmallUrl");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
        public virtual string ID
        {
            get
            {
                return mID;
                
            }
            set
            {
                mID = value;
                EntityState.FieldChange("ID");
                
            }
            
        }
        ///<summary>
        ///Type:long
        ///</summary>
        [Column()]
        public virtual long PhotoID
        {
            get
            {
                return mPhotoID;
                
            }
            set
            {
                mPhotoID = value;
                EntityState.FieldChange("PhotoID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string LargeUrl
        {
            get
            {
                return mLargeUrl;
                
            }
            set
            {
                mLargeUrl = value;
                EntityState.FieldChange("LargeUrl");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string SmallUrl
        {
            get
            {
                return mSmallUrl;
                
            }
            set
            {
                mSmallUrl = value;
                EntityState.FieldChange("SmallUrl");
                
            }
            
        }
        
    }
    
}
