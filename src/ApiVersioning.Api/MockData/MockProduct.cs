namespace ApiVersioning.Api.MockData;

public class MockProduct
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string UserId { get; set; }
    
    public static IEnumerable<MockProduct> GetDatabaseExampleModels()
    {
        return new List<MockProduct>
        { 
            new(){Id = "1071", UserId = "d73ba23e-eb08-44be-b595-a6b79bd640af", Name = "Türkiye"},
            new(){Id = "1881", UserId = "34b6fa63-0825-4002-be42-4610ed5d1e7c", Name = "Cumhuriyeti"},
            new(){Id = "1923", UserId = "eee1cab0-35f1-4060-9a73-fd193ea6a6da", Name = "İlelebet"},
            new(){Id = "1938", UserId = "18c16717-90e9-4bc7-869c-1eb1ded77f3e", Name = "Payidar"},
            new(){Id = "2023", UserId = "28f382a9-78fa-4321-9cef-198cb7409717", Name = "Kalacaktır"}
        };
    }
}