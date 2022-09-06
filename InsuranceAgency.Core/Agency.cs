namespace InsuranceAgency.Core
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public AgencyType AgencyType { get; set; }
    }
}