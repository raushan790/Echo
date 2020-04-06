using BusinessObjects;
using Controllers;
using DataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CommonControls
{
    [DataObject(true)]
    public class NoticeController : ControllerBase
    {
        /// <summary>
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="GroupID"></param>
        /// <param name="UserID"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public IList<Notice> GetNoticePaging(int PageIndex, int PageSize, int GroupID, string UserID)
        {
            return DataAccess.NoticeDao.GetNoticePaging(PageIndex, PageSize, GroupID, UserID);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int CreateNotice(int GroupID, System.Collections.Generic.IList<string> UserIDs, string NoticeTitle, string NoticeDetail, string Createdby, DateTime NoticeDate,string FileName, int FileType=0,int ParentId=0,int IsSms=0,int IsReply=0)
        {
            return DataAccess.NoticeDao.CreateNotice(GroupID, UserIDs, NoticeTitle, NoticeDetail, Createdby, NoticeDate,FileName,FileType,ParentId,IsSms, IsReply);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public int DeleteNotice(int NoticeID)
        {
            var data= DataAccess.NoticeDao.DeleteNotice(NoticeID);
            if (data.Tables[0].Rows.Count > 0)
                return 1;
            return 0;
        }
    }
}