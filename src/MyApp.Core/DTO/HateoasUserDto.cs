namespace MyApp.Core.DTO;

public sealed class HateoasUserDto : UserDto
{
    public LinkDto? Links { get; private set; }

    public void generateLinks()
    {
        this.Links = new LinkDto($"http://localhost:5095/Users/GetUserWithIdentifier/{this.Id}", "self", "GET");
    }
}