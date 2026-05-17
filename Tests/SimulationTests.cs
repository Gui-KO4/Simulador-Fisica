public class SimulationTests
{

    public int passedTests = 0;
    public int failedTests = 0;


    // Assert Method 
    public bool Assert(bool condition, string message = "")
    {
        if (!condition)
        {
            Console.WriteLine("Assertion Failed: " + message);
            failedTests++;
            return false;
        }
        else
        {
            Console.WriteLine("Assertion Passed: " + message);
            passedTests++;
            return true;
        }
    }

    public void RunAllTests()
    {
        passedTests = 0;
        failedTests = 0;

        TestRegisterProjectSuccess();

        Console.WriteLine("Tests Completed.");
        Console.WriteLine($"Tests Passed: {passedTests}");
        Console.WriteLine($"Tests Failed: {failedTests}");
        Console.WriteLine($"Total Tests: {passedTests + failedTests}");


    }

    // Tests of Project Controller
    ProjectController projectController = new ProjectController();

    public bool TestRegisterProjectSuccess()
    {
        projectController.RegisterProject("Project1");
        return Assert(projectController.GetProject("Project1") != null, "Project1 should be registered.");

        
    }
    


    // Tests of Simulation Controller


}