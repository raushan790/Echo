namespace DataObjects
{
    public interface IGalleryCommentsDao
    {
        string Approve(bool _Approved, string _AppriovedBy, int _CommentID);

        int CreateComments(BusinessObjects.GalleryComments c);

        int DeleteGallery(int _CommentID);

        BusinessObjects.GalleryComments GetComment(int _CommentID);

        System.Collections.Generic.IList<BusinessObjects.GalleryComments> GetComments(int _GalleryID);

        System.Collections.Generic.IList<BusinessObjects.GalleryComments> GetComments(int _GalleryID, bool _IsApprove);

        System.Collections.Generic.IList<BusinessObjects.GalleryComments> GetComments(int _PageIndex, int _PageSize);

        System.Collections.Generic.IList<BusinessObjects.GalleryComments> GetComments(int _PageIndex, int _PageSize, bool _Approve);

        int UpdateComments(BusinessObjects.GalleryComments c);
    }
}