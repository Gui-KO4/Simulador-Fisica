public class ConosoleController
{
    public ConsoleView console;
    public ErrorController errorCheck;
    
    public ConosoleController(ConsoleView console, ErrorController errorCheck)
    {
        this.console = console;
        this.errorCheck = errorCheck;
    }
    public void run()
    {
        string command = ReadCommand();
        errorCheck.Error(command);
        switch(command)
        {
            case "RPJ":
                
            break;
            
        }
    }
    public string ReadCommand()
    {
        string command = console.ReadCommand();
        return command;
    }
 
}