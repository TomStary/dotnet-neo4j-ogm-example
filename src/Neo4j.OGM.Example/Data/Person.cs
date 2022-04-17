using System.ComponentModel.DataAnnotations;
using Neo4j.Driver;
using Neo4j.OGM.Annotations;

namespace Neo4j.OGM.Example.Data;

[Node("Person")]
public class Person
{
    [Key]
    public long? Id { get; set; }

    public string Name { get; set; } = string.Empty!;

    public ZonedDateTime CreatedAt { get; set; } = new(DateTimeOffset.UtcNow);
}