using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace ImpactTraining.Models.Exceldo_Model
{
    // This is Code- first- approach so we need to do migration to cretae table and column
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public long Customer_Id { get; set; }
        public  long Account_No  { get; set; }
        public string Ifsc_Code { get; set; }
        public string Account_Holder_Name { get; set; }
        public long Check_No { get; set; }
        public long MICR_Code { get; set; }
        public bool Is_Processed { get; set; }
        [NotMapped]
        //   jis v property p notmapped laga rhata hai usko jab migration karte hai to wo data base m save nhi hota hai
        //    is K liye hum viewmodel ka use karte hai but avi model k ander hi declare kiye hai
        public bool Active { get; set; }
    }
}
