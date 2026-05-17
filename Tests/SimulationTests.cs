using System;
using System.Diagnostics; // Possivel Library para implementar a medição de tempo de execução dos testes.

public class SimulationTests
{


    //TODO: Se tivermos tempo criar forma de obter tempo de execução de cada teste, para termos uma noção de performance dos métodos testados.
    public int passedTests = 0;
    public int failedTests = 0;


    // Assert Method 
    // Fizemos desta forma porque a Library xUnit estava  a dar erros de Setup durante a execução
    public bool Assert(bool condition)
    {
        if (!condition)
        {
            Console.WriteLine("Teste falhou.");
            failedTests++;
            return false;
        }
        else
        {
            passedTests++;
            return true;
        }
    }

    public void RunAllTests()
    {
        // Reseta os contadores de testes
        passedTests = 0;
        failedTests = 0;

        // Chama os metodos de teste
        Console.WriteLine("------------------- Testes de Projeto-------------------");
        TestRegisterProjectSuccess();
        Console.WriteLine(" ");
        TestRegisterProjectAlreadyExists();
        Console.WriteLine(" ");
        TestListProjects();
        Console.WriteLine(" ");
        TestListProjectsEmpty();
        Console.WriteLine(" ");
        TestSelectProjectSelectnNewProject();
        Console.WriteLine(" ");
        TestSelectProjectAlreadySelected();
        Console.WriteLine(" ");
        TestSelectProjectNotFound();
        

        Console.WriteLine("-------------------  Testes de Particula-------------------");
        TestRegisterParticleSuccess();
        Console.WriteLine(" ");
        TestRegisterParticleMassInvalid();
        Console.WriteLine(" ");
        TestRegisterParticleInvalidValues();
        Console.WriteLine(" ");
        TestRegisterParticleAlreadyExists();
        Console.WriteLine(" ");
        TestListParticlesSuceful();
        Console.WriteLine(" ");
        TestListParticlesEmpty();
        Console.WriteLine(" ");
        TestRegisterForceSucess();
        Console.WriteLine(" ");
        TestRegisterForceInvalidValues();
        Console.WriteLine("-------------------  Testes de Simulação-------------------");



        // Força um Teste a falhar (Para demonstrar que o Metodo de Assert funciona corretamente)
        Console.WriteLine(" ");
        TestForceFailedAssert();
        Console.WriteLine(" ");

        Console.WriteLine("Resultados dos Testes:");
        Console.WriteLine($"Testes Passados: {passedTests}");
        Console.WriteLine($"Testes Falhados: {failedTests}");
        Console.WriteLine($"Total de Testes Feitos: {passedTests + failedTests}");


    }

    // Tests of Project Controller

    public bool TestRegisterProjectSuccess()
    {
        ProjectController projectController = new ProjectController();
        projectController.RegisterProject("Project1");
        return Assert(projectController.GetProject("Project1") != null);
    }

    public bool TestRegisterProjectAlreadyExists()
    {
        ProjectController projectController = new ProjectController();
        projectController.RegisterProject("Project1");
        projectController.RegisterProject("Project1");
        return Assert(projectController.GetProject("Project1") != null);
    }

    public bool TestListProjects()
    {
        ProjectController projectController = new ProjectController();
        projectController.RegisterProject("Project1");
        projectController.RegisterProject("Project2");
        projectController.SelectProject("Project2");
        projectController.ListProjects();
        return Assert(projectController.GetTotalProjects() > 0);
    }

    public bool TestListProjectsEmpty()
    {
        ProjectController emptyProjectController = new ProjectController();
        emptyProjectController.ListProjects();
        return Assert(emptyProjectController.GetTotalProjects() == 0);
    }

    public bool TestForceFailedAssert()
    {
        return Assert(false);
    }

        public bool TestSelectProjectSelectnNewProject()
    {
        ProjectController projectController = new ProjectController();
        projectController.RegisterProject("Project1");
        projectController.SelectProject("Project1");
        return Assert(projectController.GetActiveProject() != null);
    }

    public bool TestSelectProjectAlreadySelected()
    {
        ProjectController projectController = new ProjectController();
        projectController.RegisterProject("Project1");
        projectController.SelectProject("Project1");

        projectController.SelectProject("Project1");
        return Assert(projectController.GetActiveProject() != null);
    }

    public bool TestSelectProjectNotFound()
    {
        ProjectController sPNotFound = new ProjectController();
        sPNotFound.SelectProject("Project2");
        return Assert(sPNotFound.GetActiveProject() == null);
    }

    // Tests Particle Controller

    public bool TestRegisterParticleSuccess()
    {
        ProjectController particleProjectController = new ProjectController();
        particleProjectController.RegisterProject("Project1");
        particleProjectController.SelectProject("Project1");

        ParticleController particleController = new ParticleController(particleProjectController);
        particleController.RegisterParticle("Particle1", "0", "0", "0", "0", "0", "0", "1");

        return Assert(particleProjectController.GetActiveProject().particles.ContainsKey("Particle1"));
    }
    
    public bool TestRegisterParticleMassInvalid()
    {
        ProjectController particleProjectController = new ProjectController();
        particleProjectController.RegisterProject("Project1");
        particleProjectController.SelectProject("Project1");

        ParticleController particleController = new ParticleController(particleProjectController);
        particleController.RegisterParticle("Particle1", "0", "0", "0", "0", "0", "0", "-1");

        return Assert(!particleProjectController.GetActiveProject().particles.ContainsKey("Particle1"));
    }

    public bool TestRegisterParticleInvalidValues()
    {
        ProjectController particleProjectController = new ProjectController();
        particleProjectController.RegisterProject("Project1");
        particleProjectController.SelectProject("Project1");

        ParticleController particleController = new ParticleController(particleProjectController);
        particleController.RegisterParticle("Particle1", "invalid", "0", "0", "0", "0", "0", "1");

        return Assert(!particleProjectController.GetActiveProject().particles.ContainsKey("Particle1"));
    }

    public bool TestRegisterParticleAlreadyExists()
    {
        ProjectController particleProjectController = new ProjectController();
        particleProjectController.RegisterProject("Project1");
        particleProjectController.SelectProject("Project1");

        ParticleController particleController = new ParticleController(particleProjectController);
        particleController.RegisterParticle("Particle1", "0", "0", "0", "0", "0", "0", "1");
        particleController.RegisterParticle("Particle1", "0", "0", "0", "0", "0", "0", "1");

        return Assert(particleProjectController.GetActiveProject().particles.ContainsKey("Particle1") && particleProjectController.GetActiveProject().particles.Count == 1);
    }

    public bool TestListParticlesSuceful()
    {
        ProjectController particleProjectController = new ProjectController();
        particleProjectController.RegisterProject("Project1");
        particleProjectController.SelectProject("Project1");

        ParticleController particleController = new ParticleController(particleProjectController);
        particleController.RegisterParticle("Pessoa", "0", "0", "0", "0", "0", "0", "1");
        particleController.RegisterParticle("Fernando", "0", "0", "0", "0", "0", "0", "1");
        particleController.RegisterParticle("Antonio", "0", "0", "0", "0", "0", "0", "1");

        particleController.ListParticles();

        return Assert(particleProjectController.GetActiveProject().particles.Count == 3);
    }

    public bool TestListParticlesEmpty()
    {
        ProjectController particleProjectController = new ProjectController();
        particleProjectController.RegisterProject("Project1");
        particleProjectController.SelectProject("Project1");

        ParticleController particleController = new ParticleController(particleProjectController);
        particleController.ListParticles();

        return Assert(particleProjectController.GetActiveProject().particles.Count == 0);
    }

    public bool TestRegisterForceSucess()
    {
        ProjectController particleProjectController = new ProjectController();
        particleProjectController.RegisterProject("Project1");
        particleProjectController.SelectProject("Project1");

        ParticleController particleController = new ParticleController(particleProjectController);
        particleController.RegisterParticle("Particle1", "0", "0", "0", "0", "0", "0", "1");
        particleController.RegisterForce("Particle1", "10", "0");

        return Assert(particleProjectController.GetActiveProject().particles["Particle1"].forces.Count == 1);
    }

    public bool TestRegisterForceInvalidValues()
    {
        ProjectController particleProjectController = new ProjectController();
        particleProjectController.RegisterProject("Project1");
        particleProjectController.SelectProject("Project1");

        ParticleController particleController = new ParticleController(particleProjectController);
        particleController.RegisterParticle("Particle1", "0", "0", "0", "0", "0", "0", "1");
        particleController.RegisterForce("Particle1", "invalid", "0");

        return Assert(particleProjectController.GetActiveProject().particles["Particle1"].forces.Count == 0);
    }

    // Tests of Simulation Controller


}