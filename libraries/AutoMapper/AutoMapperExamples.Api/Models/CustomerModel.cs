namespace AutoMapperExamples.Api.Model
{
    public class CustomerModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsAdult { get; set; }


        public AddressModel Address { get; set; }
    }
}
