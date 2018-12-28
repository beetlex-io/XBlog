using System;
using System.Collections.Generic;
using System.Text;
using Peanut;
using Peanut.Mappings;

namespace BeetleX.Blog.DBModules
{
    ///<summary>
    ///Peanut Generator Copyright @ henryfan 2018 email:henryfan@msn.com
    ///website:http://www.ikende.com
    ///</summary>
    [Table()]
    public partial class Sequence : Peanut.Mappings.DataObject
    {
        private string mKey;
        public static Peanut.FieldInfo<string> key = new Peanut.FieldInfo<string>("Sequence", "Key");
        private long mValue;
        public static Peanut.FieldInfo<long> value = new Peanut.FieldInfo<long>("Sequence", "Value");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
        public virtual string Key
        {
            get
            {
                return mKey;
                
            }
            set
            {
                mKey = value;
                EntityState.FieldChange("Key");
                
            }
            
        }
        ///<summary>
        ///Type:long
        ///</summary>
        [Column()]
        public virtual long Value
        {
            get
            {
                return mValue;
                
            }
            set
            {
                mValue = value;
                EntityState.FieldChange("Value");
                
            }
            
        }
        
    }
    
}
