using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "KeyValue", Namespace = "http://www.yourcompany.com/types/")]
    public class KeyValue
    {
        public KeyValue()
        {

        }

        public KeyValue(string _Key, string _Value)
            : this()
        {

            Key = _Key;
            Value = _Value;

        }



        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string Value { get; set; }


    }
}