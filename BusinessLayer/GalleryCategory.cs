using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "GalleryCategory", Namespace = "http://www.yourcompany.com/types/")]
    public class GalleryCategory : BusinessObject
    {
        public GalleryCategory()
        {
            AddRule(new ValidateId("CategoryID"));
            AddRule(new ValidateRequired("CategoryName"));
            AddRule(new ValidateLength("CategoryName", 0, 100));
            Version = _versionDefault;
        }

        public GalleryCategory(int _CategoryID, string _CategoryName, string _Description, string _SeoName,
            int _ParentCategoryID, string _ImageID, bool _Published, bool _Deleted, int _DisplayOrder,
            DateTime _CreatedOn, DateTime _UpdatedOn, string _UserID, string _ImageName, bool _AllowDelete)
        {
            CategoryID = _CategoryID;
            CategoryName = _CategoryName;
            Description = _Description;
            SeoName = _SeoName;
            ParentCategoryID = _ParentCategoryID;
            ImageID = _ImageID;
            Published = _Published;
            Deleted = _Deleted;
            DisplayOrder = _DisplayOrder;
            CreatedOn = _CreatedOn;
            UpdatedOn = _UpdatedOn;
            UserID = _UserID;
            ImageName = _ImageName;
            AllowDelete = _AllowDelete;
        }

        [DataMember]
        public int CategoryID { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string SeoName { get; set; }

        [DataMember]
        public int ParentCategoryID { get; set; }

        [DataMember]
        public string ImageID { get; set; }

        [DataMember]
        public bool Published { get; set; }

        [DataMember]
        public bool Deleted { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public DateTime CreatedOn { get; set; }

        [DataMember]
        public DateTime UpdatedOn { get; set; }

        [DataMember]
        public string UserID { get; set; }

        [DataMember]
        public string ImageName { get; set; }

        [DataMember]
        public bool AllowDelete { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}