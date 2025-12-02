using Domain.Interfaces;

namespace Domain.Entity
{
    public enum MainEntityStatus
    {
        Normal = 1,

        //User
        User_Verify = 100,
        User_Ban = -99,
        User_WaitForVerify = 99,
        User_LoggedOut = -100,
        User_TokenExpired = -101,

        //price
        Price_Old = -200,
        Price_Active = 200,
        Price_Expired = -201,

        //Time
        Time_Old = -220,
        Time_Active = 220,
        Time_Expired = -221,

    }
    public enum MainEntityType
    {
        Normal = 1,
        UNKNOWN = 85, // UNKNOWN TYPE IS 85

        //USERS:
        User_Normal = 100,
        User_Admin = 102,
        User_FullAdmin = 103,

        //Meta data
        MetaData_Numeric_int = 700,
        MetaData_Numeric_float = 701,
        MetaData_FilePath = 702,
        MetaData_String = 703,
        MetaData_List_String = 704,
        MetaData_Phone = 705,

    }
    public interface MainEntity: IHasTimestamps
    {
        public int ID { get; set; }
        public MainEntityStatus Status { get; set; }
        public MainEntityType Type { get; set; }
        public string Explain { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
