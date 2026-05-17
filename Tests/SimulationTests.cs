public class SimulationTests
{
    private ProjectController projectController;
    private ParticleController particleController;

    public SimulationTests(ProjectController projectController, ParticleController particleController)
    {
        this.projectController = projectController;
        this.particleController = particleController;
    }

    public void ExecuteTests()
    {
        SuccessfullTest();
        FailedTest();
    }

    private void SuccessfullTest()
    {
        projectController.RegisterProject("SuccessfullTest");
        projectController.RegisterProject("Filler");
        projectController.RegisterProject("Filler2");

        projectController.SelectProject("SuccessfullTest");
        
        projectController.ListProjects();

        particleController.RegisterParticle("P1", "10", "5", "0", "20", "15", "25", "50");
        particleController.RegisterParticle("P2", "0", "0", "0", "20", "15", "25", "50");
        particleController.RegisterParticle("P3", "0", "25", "50", "75", "100", "125", "150");
        particleController.RegisterParticle("P4", "100", "75", "50", "25", "0", "25", "50");

        particleController.ListParticles();

        particleController.RegisterForce("P1", "10", "0");
        particleController.RegisterForce("P1", "0", "10");
        particleController.RegisterForce("P1", "-5", "0");
        particleController.RegisterForce("P1", "0", "-5");
        particleController.ToggleGravity("ON");
    }

    private void FailedTest()
    {
        projectController.RegisterProject("SuccessfullTest");

        particleController.RegisterParticle("PNeg", "0", "0", "0", "0", "0", "0", "-10");
        particleController.RegisterParticle("P1", "10", "10", "10", "10", "10", "10", "10");

        particleController.RegisterForce("PGhost", "5", "5");
        


    }
}