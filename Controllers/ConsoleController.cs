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
        
        switch(command)
        {
            case "RPJ":
                errorCheck.RPJError();
            break;
            case default:
            break;
            
        }
    }
    public string ReadCommand()
    {
        string command = console.ReadCommand();
        ;
    }
    public bool CommandValidation(string command)
    {
        
    }
}