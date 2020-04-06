using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "Gallery", Namespace = "http://www.yourcompany.com/types/")]
    public class Gallery : BusinessObject
    {
        public Gallery()
        {
            AddRule(new ValidateId("GalleryID"));
            AddRule(new ValidateId("RoleID"));
            AddRule(new ValidateRequired("FName"));
            AddRule(new ValidateLength("FName", 0, 100));
            AddRule(new ValidateLength("LName", 0, 100));
            Version = _versionDefault;
        }

        public Gallery(int _GalleryID, string _FName, string _LName, string _City, int _StateID, string _Desciptions, string _ImageID, int _CategoryID, string _UserID, DateTime _EntryDate, string _EmailID, string _Custom1, string _Custom2, bool _Approved, DateTime _ApprovedDate, string _ApprovedBy, IList<GalleryComments> _Comments, bool _IsVideo, string _YouTubeLinks, string _GalleryTitle, string _FileName, int _DisplayOrder)
        {
            GalleryID = _GalleryID;
            FName = _FName;
            LName = _LName;
            City = _City;
            StateID = _StateID;
            Desciptions = _Desciptions;
            ImageID = _ImageID;
            CategoryID = _CategoryID;
            UserID = _UserID;
            EntryDate = _EntryDate;
            EmailID = _EmailID;
            Custom1 = _Custom1;
            Custom2 = Custom2;
            Approved = _Approved;
            ApprovedDate = _ApprovedDate;
            ApprovedBy = _ApprovedBy;
            Comments = _Comments;
            IsVideo = _IsVideo;
            YouTubeLinks = _YouTubeLinks;
            GalleryTitle = _GalleryTitle;
            FileName = _FileName;
            DisplayOrder = _DisplayOrder;
        }

        [DataMember]
        public int GalleryID { get; set; }

        [DataMember]
        public string FName { get; set; }

        [DataMember]
        public string LName { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public int StateID { get; set; }

        [DataMember]
        public string Desciptions { get; set; }

        [DataMember]
        public string ImageID { get; set; }

        [DataMember]
        public int CategoryID { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public DateTime EntryDate { get; set; }

        [DataMember]
        public string EmailID { get; set; }

        [DataMember]
        public string Custom1 { get; set; }

        [DataMember]
        public string Custom2 { get; set; }

        [DataMember]
        public bool Approved { get; set; }

        [DataMember]
        public DateTime ApprovedDate { get; set; }

        [DataMember]
        public string ApprovedBy { get; set; }

        [DataMember]
        public IList<GalleryComments> Comments { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public bool IsVideo { get; set; }

        [DataMember]
        public string YouTubeLinks { get; set; }

        [DataMember]
        public string GalleryTitle { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}