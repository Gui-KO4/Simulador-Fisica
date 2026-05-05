using System.Collections;

public class ErrorController
{
    public ErrorController()
    {
        
    }
    public bool Error(string[] commandParts, List<Project> projects, ErrorView console)
    {
        switch(commandParts[0]){
        case "RPJ":
            foreach(Project project in projects)
                if (commandParts[1] == project.name)
                {
                    console.RPJError(1, commandParts[1]);
                    return false;
                }
                else if (commandParts.Length > 2)
                {
                    console.RPJError(2, commandParts[1]);
                    return false;
                }
        break;
        case "LPJ":
        break;
        case "SPJ":
        break;
        case "RP":
        break;
        case "RF":
        break;
        case "LP":
        break;
        case "TG":
        break;
        case "SMC":
        break;
        case "SMD":
        break;
        case "Exit":
        break;
        }
        return true; //remove this later
    }
}