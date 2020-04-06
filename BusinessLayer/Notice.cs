using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "Notice", Namespace = "http://www.yourcompany.com/types/")]
    public class Notice
    {
        public Notice()
        { }

        public Notice(int _NoticeID, int _GroupID, string _UserID,
           string _NoticeTitle, string _NoticeData, string _NoticeDate
            , string _FileName, int _FileType, bool _IsRead, string _UserName,
           int _ParentId, int _ReadCount, int _DeliveryCount, int _ReplyCount, int _IsSms, int _IsReply,int _ReplyReadPendingCount)
        : this()
        {
            NoticeID = _NoticeID;
            GroupID = _GroupID;
            UserID = _UserID;
            NoticeData = _NoticeData;
            NoticeTitle = _NoticeTitle;
            NoticeDate = _NoticeDate;
            FileName = _FileName;
            FileType = _FileType;
            IsRead = _IsRead;
            UserName = _UserName;
            ParentId = _ParentId;
            ReadCount = _ReadCount;
            DeliveryCount = _DeliveryCount;
            ReplyCount = _ReplyCount;
            IsSms = _IsSms;
            IsReply = _IsReply;
            ReplyReadPendingCount = _ReplyReadPendingCount;
        }
        [DataMember]
        public int NoticeID { get; set; }
        [DataMember]
        public int GroupID { get; set; }
        [DataMember]
        public string UserID { get; set; }
        [DataMember]
        public string NoticeTitle { get; set; }
        [DataMember]
        public string NoticeData { get; set; }
        [DataMember]
        public string NoticeDate { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public int FileType { get; set; }
        [DataMember]
        public bool IsRead { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int ParentId { get; set; }
        [DataMember]
        public int ReadCount { get; set; }
        [DataMember]
        public int DeliveryCount { get; set; }
        [DataMember]
        public int ReplyCount { get; set; }
        [DataMember]
        public int IsSms { get; set; }
        [DataMember]
        public int IsReply { get; set; }
        [DataMember]
        public int ReplyReadPendingCount { get; set; }
    }
}
