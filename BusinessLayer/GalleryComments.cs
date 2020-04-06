using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "GalleryComments", Namespace = "http://www.yourcompany.com/types/")]
    public class GalleryComments : BusinessObject
    {
        public GalleryComments()
        {
            AddRule(new ValidateId("CommentID"));
            Version = _versionDefault;
        }

        public GalleryComments(int _CommentID, string _FName, string _LName, string _Email, string _City,
            int _StateID, string _Comments, DateTime _CreateDate, bool _Approve, DateTime _ApproveDate, string _ApprovedBy,
           int _GalleryID)
        {
            CommentID = _CommentID;
            FName = _FName;
            LName = _LName;
            Email = _Email;
            City = _City;
            StateID = _StateID;
            Comments = _Comments;
            CreateDate = _CreateDate;
            Approve = _Approve;
            ApproveDate = _ApproveDate;
            ApprovedBy = _ApprovedBy;
            GalleryID = _GalleryID;
        }

        [DataMember]
        public int CommentID { get; set; }

        [DataMember]
        public string FName { get; set; }

        [DataMember]
        public string LName { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public int StateID { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public bool Approve { get; set; }

        [DataMember]
        public DateTime ApproveDate { get; set; }

        [DataMember]
        public string ApprovedBy { get; set; }

        [DataMember]
        public int GalleryID { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}