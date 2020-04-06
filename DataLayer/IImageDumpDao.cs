namespace DataObjects
{
    public interface IImageDumpDao
    {
        string CreateImageDump(BusinessObjects.ImageDump c);

        int DeleteImageDump(string _ImageID);

        BusinessObjects.ImageDump GetImageDump(string _ImageID);
    }
}