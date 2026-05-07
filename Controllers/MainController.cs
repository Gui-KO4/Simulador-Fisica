public class MainController
{
    private SimulationController simulationController;
    private ProjectController projectController;
    private ParticleController particleController;

    public MainController()
    {
        simulationController = new SimulationController();
        projectController = new ProjectController();
        particleController = new ParticleController();
    }

    public void SwitchController(string[] parts)
    {
        switch (parts[0])
            {
                case "RPJ":
                        if (parts.Length != 2)
                        {
                            OutputView.InvalidSintax(parts);
                            return;
                        }
                        projectController.RegisterProject(parts[1]);
                    break;
                case "LPJ":
                    if (parts.Length != 1)
                    {
                        OutputView.InvalidSintax(parts);
                        return;
                    }
                    projectController.ListProjects();
                    break;
                case "SPJ":
                    if (parts.Length != 2)
                    {
                        OutputView.InvalidSintax(parts);
                        return;
                    }
                    projectController.SelectProject(parts[1]);
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
                    
                    return;
                default:     
                    OutputView.InvalidSintax(parts); 
                    break;
            }
    }
}