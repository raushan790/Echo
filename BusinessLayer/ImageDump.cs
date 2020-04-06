using System;
using System.Runtime.Serialization;
using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    [Serializable]
    [DataContract(Name = "ImageDump", Namespace = "http://www.yourcompany.com/types/")]

    public class ImageDump : BusinessObject
    {
        public ImageDump()
        {
            AddRule(new ValidateRequired("ImageID"));
            AddRule(new ValidateRequired("Image_File_Name"));
            AddRule(new ValidateRequired("Image_Actual_File_Name"));
            AddRule(new ValidateRequired("Folder_Name"));
            Version = _versionDefault;
        }

        public ImageDump(string _ImageID, string _ImageFileName, string _ImageActualFile_Name, string _FolderName, string _MainImagePath)
        {
            ImageID = _ImageID;
            ImageFilename = _ImageFileName;
            ImageActualFilename = _ImageActualFile_Name;
            FolderName = _FolderName;
            MainImagePath = _MainImagePath;
        }

        [DataMember]
        public string ImageID { get; set; }

        [DataMember]
        public string ImageFilename { get; set; }

        [DataMember]
        public string ImageActualFilename { get; set; }

        [DataMember]
        public string FolderName { get; set; }

        [DataMember]
        public string MainImagePath { get; set; }

        [DataMember]
        public string Version { get; set; }
    }
}