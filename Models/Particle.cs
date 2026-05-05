
public class Particle
{
    public string name;
    public double posXi;
    public double posYi;  
    public double velXi;
    public double velYi;
    public double acelXi;
    public double acelYi;
    public double mass;
    public List<Force> forces;
    public Particle(string name, double posXi, double posYi, double velXi, double velYi, double acelXi, double acelYi, double mass)
    {
        this.name = name;
        this.posXi = posXi;
        this.posYi = posYi;
        this.velXi = velXi;
        this.velYi = velYi;
        this.acelXi = acelXi;
        this.acelYi = acelYi;
        this.mass = mass;
        forces = new List<Force>();
    }

}