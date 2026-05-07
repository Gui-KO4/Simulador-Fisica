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

    public void SwitchController(String[] parts)
    {
        switch (parts[0])
            {
                case "RPJ":
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
                    return;
                default:     
                    OutputView.InvalidInstruction(); 
                    break;
            }
    }
}