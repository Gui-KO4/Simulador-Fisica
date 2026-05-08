public class Particle
{
    public string name;
    public double initialPositionX;
    public double initialPositionY;
    public double initialVelocityX;
    public double initialVelocityY;
    public double accelerationX;
    public double accelerationY;
    public double mass;
    public List<Force> forces;

    public Particle(string name, double initialPositionX, double initialPositionY, double initialVelocityX, double initialVelocityY, double accelerationX, double accelerationY, double mass)
    {
        this.name = name;
        this.initialPositionX = initialPositionX;
        this.initialPositionY = initialPositionY;
        this.initialVelocityX = initialVelocityX;
        this.initialVelocityY = initialVelocityY;
        this.accelerationX = accelerationX;
        this.accelerationY = accelerationY;
        this.mass = mass;
        forces = new List<Force>();
    }

    public override string ToString()
    {
        return $"Partícula: {name} \nPosição inicial: ({initialPositionX},{initialPositionY})m \nVelocidade inicial: ({initialVelocityX}{initialVelocityY}) m/s \nAcelaração: ({accelerationX}{accelerationY}) m/s^2 \nMassa: {mass} kg \nNúmero de forças aplicadas: {forces.Count()}";
    }
}