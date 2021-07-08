namespace Bookish.DbModels
{
    public string[] CreateMember()
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool ActiveStatus { get; set; }
        public List<BorrowerHistoryDbModel> BorrowerHistories { get; set; }

    }


}