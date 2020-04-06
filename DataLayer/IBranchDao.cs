namespace DataObjects
{
    public interface IBranchDao
    {
        BusinessObjects.Branch GetBranch(int _BranchID);

        BusinessObjects.Branch GetBranch(string _BranchSEOURL);

        System.Collections.Generic.IList<BusinessObjects.Branch> GetBranchs();
    }
}