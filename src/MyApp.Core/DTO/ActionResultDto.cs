namespace MyApp.Core.DTO;

public class ActionResultDto
{
    public bool Result { get; private set; }

    public ActionResultDto(bool result) => Result = result;
}