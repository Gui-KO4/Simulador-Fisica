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
                    if(parts.Length != 9)
                    {
                        OutputView.InvalidSintax(parts);
                        return;
                    }
                    particleController.RegisterParticle(parts[1],parts[2],parts[3],parts[4],parts[5],parts[6],parts[7],parts[8]);   
                    break;
                case "RF":
                    if(parts.Length != 4)
                    {
                        OutputView.InvalidSintax(parts);
                        return;   
                    }
                    particleController.RegisterForce(parts[1], parts[2], parts[3]);
                    break;
                case "LP":
                    if(parts.Length != 1)
                    {
                        OutputView.InvalidSintax(parts);
                        return;   
                    }
                    particleController.ListParticles();
                    break;
                case "TG":
                    if(parts.Length != 2)
                    {
                        OutputView.InvalidSintax(parts);
                        return;
                    } 
                    projectController.ToggleGravity(parts[1]);
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