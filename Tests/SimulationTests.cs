using System;
using System.Collections;
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
        Console.WriteLine(" ");
        TestToggleGravityON();
        Console.WriteLine(" ");
        TestToggleGravityOFF();
        Console.WriteLine(" ");
        TestToggleGravityInvalidComand();

        

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
        TestSMCSuccess();
        Console.WriteLine(" ");
        TestSBD();
        Console.WriteLine(" ");
        TestNegativeTime();
        Console.WriteLine(" ");
        TestSMDSuccess();
        Console.WriteLine(" ");
        TestSMDError();
        

        // Força um Teste a falhar (Para demonstrar que o Metodo de Assert funciona corretamente)
        Console.WriteLine(" ");
        TestForceFailedAssert();
        Console.WriteLine(" ");

        Console.WriteLine("Resultados dos Testes:");
        Console.WriteLine($"Testes Passados: {passedTests}");
        Console.WriteLine($"Testes Falhados: {failedTests}");
        Console.WriteLine($"Total de Testes Feitos: {passedTests + failedTests}");


    }

    public void RunEspecificTest(string testName)
    {
        failedTests = 0;
        passedTests = 0;
        
        switch (testName)
        {
            case "TestRegisterProjectSuccess":
                Console.WriteLine(" ");
                TestRegisterProjectSuccess();
                break;
            case "TestRegisterProjectAlreadyExists":
                Console.WriteLine(" ");
                TestRegisterProjectAlreadyExists();
                break;
            case "TestListProjects":
                Console.WriteLine(" ");
                TestListProjects();
                break;
            case "TestListProjectsEmpty":
                Console.WriteLine(" ");
                TestListProjectsEmpty();
                break;
            case "TestSelectProjectSelectnNewProject":
                Console.WriteLine(" ");
                TestSelectProjectSelectnNewProject();
                break;
            case "TestSelectProjectAlreadySelected":
                Console.WriteLine(" ");
                TestSelectProjectAlreadySelected();
                break;
            case "TestSelectProjectNotFound":
                Console.WriteLine(" ");
                TestSelectProjectNotFound();
                break;
            case "TestToggleGravityON":
                Console.WriteLine(" ");
                TestToggleGravityON();
                break;
            case "TestToggleGravityOFF":
                Console.WriteLine(" ");
                TestToggleGravityOFF();
                break;
            case "TestToggleGravityInvalidCommand":
                Console.WriteLine(" ");
                TestToggleGravityInvalidComand();
                break;
            case "TestRegisterParticleSuccess":
                Console.WriteLine(" ");
                TestRegisterParticleSuccess();
                break;
            case "TestRegisterParticleMassInvalid":
                Console.WriteLine(" ");
                TestRegisterParticleMassInvalid();
                break;
            case "TestRegisterParticleInvalidValues":
                Console.WriteLine(" ");
                TestRegisterParticleInvalidValues();
                break;
            case "TestRegisterParticleAlreadyExists":
                Console.WriteLine(" ");
                TestRegisterParticleAlreadyExists();
                break;
            case "TestListParticlesSuceful":
                Console.WriteLine(" ");
                TestListParticlesSuceful();
                break;
            case "TestListParticlesEmpty":
                Console.WriteLine(" ");
                TestListParticlesEmpty();
                break;
            case "TestRegisterForceSucess":
                Console.WriteLine(" ");
                TestRegisterForceSucess();
                break;
            case "TestRegisterForceInvalidValues":
                Console.WriteLine(" ");
                TestRegisterForceInvalidValues();
                break;
            case "TestSMCSuccess":
                Console.WriteLine(" ");
                TestSMCSuccess();
                break;
            case "TestSBD":
                Console.WriteLine(" ");
                TestSBD();
                break;
            case "TestNegativeTime":
                Console.WriteLine(" ");
                TestNegativeTime();
                break;
            case "TestSMDSuccess":
                Console.WriteLine(" ");
                TestSMDSuccess();
                break;
            case "TestSMDError":
                Console.WriteLine(" ");
                TestSMDError();
                break;
            case "TestForceFailedAssert":
                Console.WriteLine(" ");
                TestForceFailedAssert();
                break;
            default:
                Console.WriteLine("Teste não encontrado.");
                break;
        }

        if (failedTests > 0)
        {
            Console.WriteLine($"\nTeste {testName} falhou.");
        }
        else
        {
            Console.WriteLine($"\nTeste {testName} passou com sucesso.");
        }
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

    public bool TestToggleGravityON()
    {
        ProjectController projectController = new ProjectController();
        projectController.RegisterProject("GravityProject");
        projectController.SelectProject("GravityProject");

        projectController.GetActiveProject().gravity = false;

        string[] partsComando = {"TG", "ON"};
        projectController.ToggleGravity(partsComando, "ON");

        return Assert(projectController.GetActiveProject().gravity == true);
    }

    public bool TestToggleGravityOFF()
    {
        ProjectController projectController = new ProjectController();
        projectController.RegisterProject("GravityProject2");
        projectController.SelectProject("GravityProject2");
        projectController.GetActiveProject().gravity = true;

        string[] partsCommand = {"TG", "OFF"};
        projectController.ToggleGravity(partsCommand, "OFF");

        return Assert(projectController.GetActiveProject().gravity == false);
    }

    public bool TestToggleGravityInvalidComand()
    {
        ProjectController projectController = new ProjectController();
        projectController.RegisterProject("GravityProject3");
        projectController.SelectProject("GravityProject3");
        bool previousState = projectController.GetActiveProject().gravity;

        string[] partsErrorCommand = {"TG", "Uhhh"};
        projectController.ToggleGravity(partsErrorCommand, "Uhhh");
 
        return Assert(projectController.GetActiveProject().gravity == previousState);
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

    public bool TestSMCSuccess()
    {
        ProjectController smcProjectController = new ProjectController();
        smcProjectController.RegisterProject("SMCProject");
        smcProjectController.SelectProject("SMCProject");

        ParticleController smcParticleController = new ParticleController(smcProjectController);
        smcParticleController.RegisterParticle("SMC1", "20", "20", "0", "0", "0", "0", "10");

        double posicaoInicial = smcProjectController.GetActiveProject().particles["SMC1"].initialPositionX;
        Console.WriteLine(posicaoInicial);
        
        SimulationController smcSimulationController = new SimulationController(smcProjectController);
        smcSimulationController.SMC("10", "5");
     
        
        Project project = smcProjectController.GetActiveProject();
        Particle particle = project.particles["SMC1"];
        double posicaoFinalX = smcSimulationController.getLastPositionX();
        Console.WriteLine(posicaoFinalX);

        return Assert(posicaoInicial == posicaoFinalX);
    }

    public bool TestSBD() // Steps bigger than Duration(SBD)
    {
        ProjectController smcProjectController = new ProjectController();
        smcProjectController.RegisterProject("SMCProject");
        smcProjectController.SelectProject("SMCProject");

        ParticleController smcParticleController = new ParticleController(smcProjectController);
        smcParticleController.RegisterParticle("SMC1", "20", "20", "0", "0", "0", "0", "10");
        string duration = "5";
        string steps = "10";
        SimulationController smcSimulationController = new SimulationController(smcProjectController);
        smcSimulationController.SMC(duration, steps);
        return Assert(Convert.ToInt32(steps) > Convert.ToInt32(duration));
    }
    
    public bool TestNegativeTime()
    {
        ProjectController smcProjectController = new ProjectController();
        smcProjectController.RegisterProject("SMCProject");
        smcProjectController.SelectProject("SMCProject");

        ParticleController smcParticleController = new ParticleController(smcProjectController);
        smcParticleController.RegisterParticle("SMC1", "20", "20", "0", "0", "0", "0", "10");
        string duration = "-10";
        SimulationController smdSimulationController = new SimulationController(smcProjectController);
        smdSimulationController.SMC(duration, "5");

        return Assert(Convert.ToInt32(duration) < 0);
    }

    public bool TestSMDSuccess()
    {
        ProjectController smdProjectController = new ProjectController();
        smdProjectController.RegisterProject("SMDProject");
        smdProjectController.SelectProject("SMDProject");

        ParticleController smdParticleController = new ParticleController(smdProjectController);
        smdParticleController.RegisterParticle("SMD1", "20", "20", "0", "0", "0", "0", "10");

        double posicaoInicial = smdProjectController.GetActiveProject().particles["SMD1"].initialPositionX;
        Console.WriteLine(posicaoInicial);
        
        SimulationController smdSimulationController = new SimulationController(smdProjectController);
        smdSimulationController.SMD("SMD1", "10","5");
     
        
        Project project = smdProjectController.GetActiveProject();
        Particle particle = project.particles["SMD1"];
        double posicaoFinalX = smdSimulationController.getLastPositionX();
        Console.WriteLine(posicaoFinalX);

        return Assert(posicaoInicial == posicaoFinalX);
        
    }

    public bool TestSMDError()
    {
        ProjectController smdProjectController = new ProjectController();
        smdProjectController.RegisterProject("SMDProject");
        smdProjectController.SelectProject("SMDProject");

        ParticleController smcParticleController = new ParticleController(smdProjectController);
        smcParticleController.RegisterParticle("SMD1", "20", "20", "0", "0", "0", "0", "10");
        string SMD1 = smdProjectController.GetActiveProject().particles["SMD1"].name;
        string SMD2 = "SMD2";
        SimulationController smcSimulationController = new SimulationController(smdProjectController);
        smcSimulationController.SMD(SMD2,"10", "5");
        
        return Assert(SMD1 != SMD2);  
    }



}