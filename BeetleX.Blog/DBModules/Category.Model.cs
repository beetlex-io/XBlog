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
    public partial class Category : Peanut.Mappings.DataObject
    {
        private long mID;
        public static Peanut.FieldInfo<long> iD = new Peanut.FieldInfo<long>("Category", "ID");
        private string mName;
        public static Peanut.FieldInfo<string> name = new Peanut.FieldInfo<string>("Category", "Name");
        private string mRemark;
        public static Peanut.FieldInfo<string> remark = new Peanut.FieldInfo<string>("Category", "Remark");
        private int mOrderBy;
        public static Peanut.FieldInfo<int> orderBy = new Peanut.FieldInfo<int>("Category", "OrderBy");
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
        public virtual string Name
        {
            get
            {
                return mName;
                
            }
            set
            {
                mName = value;
                EntityState.FieldChange("Name");
                
            }
            
        }
        ///<summary>
        ///Type:string
        ///</summary>
        [Column()]
        public virtual string Remark
        {
            get
            {
                return mRemark;
                
            }
            set
            {
                mRemark = value;
                EntityState.FieldChange("Remark");
                
            }
            
        }
        ///<summary>
        ///Type:int
        ///</summary>
        [Column()]
        public virtual int OrderBy
        {
            get
            {
                return mOrderBy;
                
            }
            set
            {
                mOrderBy = value;
                EntityState.FieldChange("OrderBy");
                
            }
            
        }
        
    }
    
}
