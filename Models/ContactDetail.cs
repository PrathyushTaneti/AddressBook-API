namespace AddressBookAPI.Models
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public String? Name { get; set; }        
        public String? Email { get; set; }         
        public String? Mobile { get; set; }       
        public String? LandLine { get; set; }    
        public String? Website { get; set; }    
        public String? Address { get; set; }     //primitive
    }
}
