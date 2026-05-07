public class Force
{
    public double X;
    public double Y;

    public Force(double X, double Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public double Magnitude()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    public double AngleInDegrees()
    {
        return Math.Atan2(Y, X) * (180.0 / Math.PI);
    }
}