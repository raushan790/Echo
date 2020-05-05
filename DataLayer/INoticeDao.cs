using System;
using BusinessObjects;

namespace DataObjects
{
    public interface INoticeDao
    {
        System.Collections.Generic.IList<Notice> GetNoticePagingAdminByID(int NoticeID, int PageSize, int GroupID, string UserID);

        System.Collections.Generic.IList<Notice> GetNoticePagingByID(int NoticeID, int PageSize, int GroupID, string UserID);
        System.Collections.Generic.IList<BusinessObjects.Notice> GetNoticePagingAdmin(int PageIndex, int PageSize, int GroupID, string UserID);

        System.Collections.Generic.IList<BusinessObjects.Notice> GetNoticePaging(int PageIndex,int PageSize,int GroupID,string UserID);
        System.Collections.Generic.IList<BusinessObjects.Notice> GetNoticeByID(int NoticeId, int PageIndex, int GroupID, string UserID);
        int CreateNotice(int GroupID, System.Collections.Generic.IList<string>UserIDs,string NoticeTitle, string NoticeDetail,string Createdby, DateTime NoticeDate,string FileName,int FileType=0,int ParentId=0, int IsSms=0, int IsReply=0, string strdeepLink="");
        System.Data.DataSet DeleteNotice(int NoticeID);
        System.Data.DataSet GetUnreadNoticeCount(string UserID);

        System.Data.DataSet GetLastReadMessage(string GroupID);

        System.Collections.Generic.List<int> GetDeletedNotice(string UserID);

        int ConfirmDeleteNotice(System.Collections.Generic.List<int> NoticeIDs, string UserID);
        bool SeenNotice(int NoticeID, string UserID);
    }
}