public class Project
{
    public string name;
    public bool state;
    public bool gravity;
    public double gravityForce;
    public SortedDictionary<string, Particle> particles;
    public Project(string name)
    {
        this.name = name;
        state = false;
        gravity = false;
        gravityForce = 9.80;
        particles = new SortedDictionary<string, Particle>();
    }

    public string currentState()
    {
        return state ? "Ativo" : "Inativo";
    }

}