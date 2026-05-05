using System.Runtime.InteropServices;

public class Project
{
    public string name;
    public bool state;
    public bool gravity;
    public double gravityForce;
    public List<Particle> particles;
    public Project(string name)
    {
        this.name = name;
        state = false;
        gravity = false;
        gravityForce = 9.80;
        particles = new List<Particle>();
    }
    public void toString()
    {
        Console.WriteLine(name + "Estado" + (state ? "Selecionado" : "Não selecionado"));

    }
}