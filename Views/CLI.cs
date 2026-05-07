public class CLI
{   
    private MainController mainController = new MainController();

    public void Run()
    {
        while (true)
        {
            string [] parts = Console.ReadLine().Split(' ');

            if (parts.Length == 0) {
                continue;
            }

            mainController.SwitchController(parts);
        }
    }
}