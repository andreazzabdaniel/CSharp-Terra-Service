namespace terraservice.Communication.Project.Response;

public class ProjectsDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime CreationTime { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int ClientId { get; set; }
}