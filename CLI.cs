public class CLI
{
    private SimulationController simulationController;
    private ProjectController projectController;
    private ParticleController particleController;

    public CLI()
    {
        simulationController = new SimulationController();
        projectController = new ProjectController();
        particleController = new ParticleController();
    }
    
  public void Run()
    {

        while (true)
        {
            string [] parts = Console.ReadLine().Split(' ');

            if (parts.Length == 0) {
                continue;
            }

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
}