using CsvHelper.Configuration;

namespace SR_lab.lab2;

public sealed class CustomerRowMap: ClassMap<CustomerRow>
{
    public CustomerRowMap()
    {
        Map(m => m.CustomerId).Name("Customer Id");
        Map(m => m.FirstName).Name("First Name");
        Map(m => m.LastName).Name("Last Name");
        Map(m => m.Country).Name("Country");
        Map(m => m.Phone).Name("Phone 1");
        Map(m => m.Email).Name("Email");
    }
}