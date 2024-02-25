namespace ApiVersioning.Api.MockData;

public class MockArticle
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string UserId { get; set; }
    public required int OrderValue { get; set; }
    
    public static IEnumerable<MockArticle> GetDatabaseExampleModels()
    {
        return new List<MockArticle>
        { 
            new(){Id = "1071", UserId = "d73ba23e-eb08-44be-b595-a6b79bd640af", Name = "Türkiye",OrderValue = 1},
            new(){Id = "1881", UserId = "34b6fa63-0825-4002-be42-4610ed5d1e7c", Name = "Cumhuriyeti", OrderValue = 2},
            new(){Id = "1923", UserId = "eee1cab0-35f1-4060-9a73-fd193ea6a6da", Name = "İlelebet", OrderValue = 3},
            new(){Id = "1938", UserId = "18c16717-90e9-4bc7-869c-1eb1ded77f3e", Name = "Payidar", OrderValue = 4},
            new(){Id = "2023", UserId = "28f382a9-78fa-4321-9cef-198cb7409717", Name = "Kalacaktır", OrderValue = 5}
        };
    }
}