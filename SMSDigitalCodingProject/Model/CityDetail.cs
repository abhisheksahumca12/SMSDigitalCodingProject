namespace SMSDigitalCodingProject.Model
{
    public class CityDetail
    {
        public int Id { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Implemented below properties nullable true
        public decimal? Price { get; set; }
        public String? Status { get; set; }
        public String? Color { get; set; }
    }
}
