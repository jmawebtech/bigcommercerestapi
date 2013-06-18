using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BigCommerce.RestApi.Core
{
    [DataContract]
    public class orderstatus
    {
        private int idField;
        private string nameField;
        private int orderField;

        [DataMember]
        public int id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        [DataMember]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }


        [DataMember]
        public int order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }


    }
}
