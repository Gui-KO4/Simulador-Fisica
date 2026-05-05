public class ConosoleController
{
    public ConsoleView console;
    public ErrorController errorCheck;
    public List<Project> projects;
    
    public ConosoleController(ConsoleView console, ErrorController errorCheck)
    {
        this.console = console;
        this.errorCheck = errorCheck;
        projects = new List<Project>();
    }
    public void run()
    {
        while(true){
            string[] commandParts = ReadCommand();
            errorCheck.Error(commandParts, projects, console);
            switch(commandParts[0])
            {
                case "RPJ":
                    
                break;
                
            }
        }
    }
    public string[] ReadCommand()
    {
        string command = console.ReadCommand();
        string[] commandParts = command.Split(' ');
        return commandParts;
    }
 
}