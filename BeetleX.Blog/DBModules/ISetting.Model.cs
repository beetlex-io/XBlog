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
    public partial class Option : Peanut.Mappings.DataObject
    {
        private string mName;
        public static Peanut.FieldInfo<string> name = new Peanut.FieldInfo<string>("Option", "Name");
        private string mValue;
        public static Peanut.FieldInfo<string> value = new Peanut.FieldInfo<string>("Option", "Value");
        ///<summary>
        ///Type:string
        ///</summary>
        [ID()]
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
        public virtual string Value
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
