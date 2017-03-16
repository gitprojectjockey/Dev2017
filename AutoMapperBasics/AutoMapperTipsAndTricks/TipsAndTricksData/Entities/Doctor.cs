namespace TipsAndTricksData.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public int HospitalId { get; set; }
        public virtual Hospital Hospital{ get; set; }
    }
}
