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
    public partial class Blog : Peanut.Mappings.DataObject
    {
        private long mID;
        public static Peanut.FieldInfo<long> iD = new Peanut.FieldInfo<long>("Blog", "ID");
        private string mTitle;
        public static Peanut.FieldInfo<string> title = new Peanut.FieldInfo<string>("Blog", "Title");
        private bool mTop;
        public static Peanut.FieldInfo<bool> top = new Peanut.FieldInfo<bool>("Blog", "Top");
        private string mContent;
        public static Peanut.FieldInfo<string> content = new Peanut.FieldInfo<string>("Blog", "Content");
        private string mSummary;
        public static Peanut.FieldInfo<string> summary = new Peanut.FieldInfo<string>("Blog", "Summary");
        private string mCategory;
        public static Peanut.FieldInfo<string> category = new Peanut.FieldInfo<string>("Blog", "Category");
        private long mCategoryID;
        public static Peanut.FieldInfo<long> categoryID = new Peanut.FieldInfo<long>("Blog", "CategoryID");
        private string mTags;
        public static Peanut.FieldInfo<string> tags = new Peanut.FieldInfo<string>("Blog", "Tags");
        private string mSourceUrl;
        public static Peanut.FieldInfo<string> sourceUrl = new Peanut.FieldInfo<string>("Blog", "SourceUrl");
        private DateTime mCreateTime;
        public static Peanut.FieldInfo<DateTime> createTime = new Peanut.FieldInfo<DateTime>("Blog", "CreateTime");
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
        ///Type:bool
        ///</summary>
        [Column()]
        [BoolConvter]
        public virtual bool Top
        {
            get
            {
                return mTop;
                
            }
            set
            {
                mTop = value;
                EntityState.FieldChange("Top");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Content
        {
            get
            {
                return mContent;
                
            }
            set
            {
                mContent = value;
                EntityState.FieldChange("Content");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Summary
        {
            get
            {
                return mSummary;
                
            }
            set
            {
                mSummary = value;
                EntityState.FieldChange("Summary");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Category
        {
            get
            {
                return mCategory;
                
            }
            set
            {
                mCategory = value;
                EntityState.FieldChange("Category");
                
            }
            
        }
        ///<summary>
        ///Type:long
        ///</summary>
        [Column()]
        public virtual long CategoryID
        {
            get
            {
                return mCategoryID;
                
            }
            set
            {
                mCategoryID = value;
                EntityState.FieldChange("CategoryID");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Tags
        {
            get
            {
                return mTags;
                
            }
            set
            {
                mTags = value;
                EntityState.FieldChange("Tags");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string SourceUrl
        {
            get
            {
                return mSourceUrl;
                
            }
            set
            {
                mSourceUrl = value;
                EntityState.FieldChange("SourceUrl");
                
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
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ henryfan 2018 email:henryfan@msn.com
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class RefreshBlog : Peanut.Mappings.DataObject
    {
        private long mBlogID;
        public static Peanut.FieldInfo<long> blogID = new Peanut.FieldInfo<long>("RefreshBlog", "BlogID");
        private DateTime mCreateTime;
        public static Peanut.FieldInfo<DateTime> createTime = new Peanut.FieldInfo<DateTime>("RefreshBlog", "CreateTime");
        private int mStatus;
        public static Peanut.FieldInfo<int> status = new Peanut.FieldInfo<int>("RefreshBlog", "Status");
        ///<summary>
        ///Type:long
        ///</summary>
        [Column()]
        public virtual long BlogID
        {
            get
            {
                return mBlogID;
                
            }
            set
            {
                mBlogID = value;
                EntityState.FieldChange("BlogID");
                
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
        ///Type:int
        ///</summary>
        [Column()]
        public virtual int Status
        {
            get
            {
                return mStatus;
                
            }
            set
            {
                mStatus = value;
                EntityState.FieldChange("Status");
                
            }
            
        }
        
    }
    
}
