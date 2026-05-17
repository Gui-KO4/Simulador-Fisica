public class MainController
{
    private SimulationController simulationController;
    private ProjectController projectController;
    private ParticleController particleController;

    public MainController()
    {
        projectController = new ProjectController();
        simulationController = new SimulationController(projectController);
        particleController = new ParticleController(projectController);
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
                    if(parts.Length != 3)
                        {
                            OutputView.InvalidSintax(parts);
                            return;
                        }
                        simulationController.SMC(parts[1], parts[2]);
                    break;
                case "SMD":
                    if(parts.Length != 4)
                    {
                        OutputView.InvalidSintax(parts);
                        return;
                    }
                    simulationController.SMD(parts[1], parts[2], parts[3]);
                    break;
                case "Exit":
                    return;
                case "Tests":
                    SimulationTests tests = new SimulationTests();
                    tests.RunAllTests();
                    break;
                default:     
                    OutputView.InvalidSintax(parts); 
                    break;
            }
    }
}