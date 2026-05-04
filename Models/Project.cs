using System.Runtime.InteropServices;

public class Project
{
    public string name;
    public bool state;
    public List<Particle> particles;
    public Project(string name)
    {
        this.name = name;
        state = false;
        particles = new List<Particle>();
    }
    public void toString()
    {
        Console.WriteLine(name + "Estado" + (state ? "Selecionado" : "Não selecionado"));

    }
}