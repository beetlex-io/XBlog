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
    public partial class Comment : Peanut.Mappings.DataObject
    {
        private long mID;
        public static Peanut.FieldInfo<long> iD = new Peanut.FieldInfo<long>("Comment", "ID");
        private string mNickName;
        public static Peanut.FieldInfo<string> nickName = new Peanut.FieldInfo<string>("Comment", "NickName");
        private string mHeadUrl;
        public static Peanut.FieldInfo<string> headUrl = new Peanut.FieldInfo<string>("Comment", "HeadUrl");
        private long mBlogID;
        public static Peanut.FieldInfo<long> blogID = new Peanut.FieldInfo<long>("Comment", "BlogID");
        private string mContent;
        public static Peanut.FieldInfo<string> content = new Peanut.FieldInfo<string>("Comment", "Content");
        private DateTime mCreateTime;
        public static Peanut.FieldInfo<DateTime> createTime = new Peanut.FieldInfo<DateTime>("Comment", "CreateTime");
        private string mUserID;
        public static Peanut.FieldInfo<string> userID = new Peanut.FieldInfo<string>("Comment", "UserID");
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
        public virtual string NickName
        {
            get
            {
                return mNickName;
                
            }
            set
            {
                mNickName = value;
                EntityState.FieldChange("NickName");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string HeadUrl
        {
            get
            {
                return mHeadUrl;
                
            }
            set
            {
                mHeadUrl = value;
                EntityState.FieldChange("HeadUrl");
                
            }
            
        }
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
        ///Type:DateTime
        ///</summary>
        [Column()]
        [NowDate]
        [DateTimeConvter]
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
        public virtual string UserID
        {
            get
            {
                return mUserID;
                
            }
            set
            {
                mUserID = value;
                EntityState.FieldChange("UserID");
                
            }
            
        }
        
    }
    ///<summary>
    ///Peanut Generator Copyright @ henryfan 2018 email:henryfan@msn.com
    ///website:http://www.ikende.com
    ///</summary>
    [Table("Comment inner join Blog on Comment.BlogID=Blog.ID")]
    public partial class TopComment : Peanut.Mappings.DataObject
    {
        private long mID;
        public static Peanut.FieldInfo<long> iD = new Peanut.FieldInfo<long>("Comment inner join Blog on Comment.BlogID=Blog.ID", "Blog.ID");
        private long mCommentID;
        public static Peanut.FieldInfo<long> commentID = new Peanut.FieldInfo<long>("Comment inner join Blog on Comment.BlogID=Blog.ID", "Comment.ID");
        private string mTitle;
        public static Peanut.FieldInfo<string> title = new Peanut.FieldInfo<string>("Comment inner join Blog on Comment.BlogID=Blog.ID", "Title");
        private string mContent;
        public static Peanut.FieldInfo<string> content = new Peanut.FieldInfo<string>("Comment inner join Blog on Comment.BlogID=Blog.ID", "Comment.Content");
        private string mNickName;
        public static Peanut.FieldInfo<string> nickName = new Peanut.FieldInfo<string>("Comment inner join Blog on Comment.BlogID=Blog.ID", "NickName");
        private DateTime mCreateTime;
        public static Peanut.FieldInfo<DateTime> createTime = new Peanut.FieldInfo<DateTime>("Comment inner join Blog on Comment.BlogID=Blog.ID", "Comment.CreateTime");
        ///<summary>
        ///Type:long
        ///</summary>
        [Column("Blog.ID")]
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
        ///Type:long
        ///</summary>
        [Column("Comment.ID")]
        public virtual long CommentID
        {
            get
            {
                return mCommentID;
                
            }
            set
            {
                mCommentID = value;
                EntityState.FieldChange("CommentID");
                
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
        ///Type:string
        ///</summary>
        [Column("Comment.Content")]
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
        public virtual string NickName
        {
            get
            {
                return mNickName;
                
            }
            set
            {
                mNickName = value;
                EntityState.FieldChange("NickName");
                
            }
            
        }
        ///<summary>
        ///Type:DateTime
        ///</summary>
        [Column("Comment.CreateTime")]
        [DateTimeConvter]
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
    
}
