using System.ComponentModel;

public class ConsoleController
{
    public ConsoleView console;
    public ErrorView errorConsole;
    public ErrorController errorCheck;
    public ProjectManager project;
   
    
    public ConsoleController(ConsoleView console, ErrorController errorCheck,ErrorView errorConsole, ProjectManager project )
    {
        this.console = console;
        this.errorCheck = errorCheck;
        this.errorConsole = errorConsole;
        this.project = project;
       
    }
    public void run(List<Project> projects)
    {
        while(true){
            string[] commandParts = ReadCommand();
            errorCheck.Error(commandParts, projects, errorConsole);
            switch(commandParts[0])
            {
                case "RPJ":
                    project.AddProject(commandParts[1]);
                break;
                case "LPJ":
                    project.ListProjects();
                break;
                case "SPJ":
                    project.SelectProject(commandParts[1]);
                break;
                case "RP":
                    double[] particlesAtributes = new double[6];
                    for (int i = 1; i >= 7; i++)
                    {
                        particlesAtributes[i-1] = Double.Parse(commandParts[i]);
                    }
                    project.AddParticle(commandParts[1],particlesAtributes[0], particlesAtributes[1], particlesAtributes[2], particlesAtributes[3], particlesAtributes[4],particlesAtributes[5], particlesAtributes[6]);
                break;
                case "Exit":
                    return;
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