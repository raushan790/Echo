namespace DataObjects
{
    public interface IGalleryDao
    {
        string Approve(bool _Approved, string _AppriovedBy, int _GalleryID);

        int CreateGallery(BusinessObjects.Gallery c);

        int DeleteGallery(int _GalleryID);

        BusinessObjects.Gallery GetGallery(int _GalleryID);

        System.Collections.Generic.IList<BusinessObjects.Gallery> GetGallerys(string _SearchText);

        System.Collections.Generic.IList<BusinessObjects.Gallery> GetGallerys(int _CategoryID);

        System.Collections.Generic.IList<BusinessObjects.Gallery> GetGallerys(bool _Approved);

        System.Collections.Generic.IList<BusinessObjects.Gallery> GetGallerys(bool _Approved, bool _IsVideo);

        System.Collections.Generic.IList<BusinessObjects.Gallery> GetGallerys(int _CategoryID, bool _Approved);

        System.Collections.Generic.IList<BusinessObjects.Gallery> GetGallerys(int _PageIndex, int _PageSize, int _CategoryID, bool _Approved);

        System.Collections.Generic.IList<BusinessObjects.Gallery> GetGallerys(int _PageIndex, int _PageSize, int _CategoryID);

        int UpdateGallery(BusinessObjects.Gallery c);
    }
}