
public class Particle
{
    public string name;
    public int posXi;
    public int posYi;  
    public int velXi;
    public int velYi;
    public int acelXi;
    public int acelYi;
    public int mass;
    public List<Force> forces;
    public Particle(string name, int posXi, int posYi, int velXi, int velYi, int acelXi, int acelYi, int mass)
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