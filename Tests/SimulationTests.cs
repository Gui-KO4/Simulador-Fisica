using System;
using System.Diagnostics; // Possivel Library para implementar a medição de tempo de execução dos testes.

public class SimulationTests
{


    //TODO: Se tivermos tempo criar forma de obter tempo de execução de cada teste, para termos uma noção de performance dos métodos testados.
    public int passedTests = 0;
    public int failedTests = 0;


    // Assert Method 
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
        TestRegisterProjectSuccess();
        TestRegisterProjectAlreadyExists();
        TestListProjects();
        TestListProjectsEmpty();

        // Força um Teste a falhar (Para demonstrar que o Metodo de Assert funciona corretamente)
        TestForceFailedAssert();

        Console.WriteLine("Resultados dos Testes:");
        Console.WriteLine($"Testes Passados: {passedTests}");
        Console.WriteLine($"Testes Falhados: {failedTests}");
        Console.WriteLine($"Total de Testes Feitos: {passedTests + failedTests}");


    }

    // Tests of Project Controller
    ProjectController projectController = new ProjectController();

    public bool TestRegisterProjectSuccess()
    {
        projectController.RegisterProject("Project1");
        return Assert(projectController.GetProject("Project1") != null);
    }

    public bool TestRegisterProjectAlreadyExists()
    {
        projectController.RegisterProject("Project1");
        return Assert(projectController.GetProject("Project1") != null);
    }

    public bool TestListProjects()
    {
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

    // Tests of Simulation Controller


}