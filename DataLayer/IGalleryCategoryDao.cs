namespace DataObjects
{
    public interface IGalleryCategoryDao
    {
        int CreateCategory(BusinessObjects.GalleryCategory c);

        int DeleteCategory(int _CategoryID);

        BusinessObjects.GalleryCategory GetCategory(int _GalleryID);

        System.Collections.Generic.IList<BusinessObjects.GalleryCategory> GetCategories();

        int UpdateCategory(BusinessObjects.GalleryCategory c);

        System.Collections.Generic.IList<BusinessObjects.GalleryCategory> GetCategories(bool _IsPublish);
    }
}