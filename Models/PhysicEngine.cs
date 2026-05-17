using System.Data.SqlTypes;

public static class PhysicEngine
{
    public static Force GetResultantForce(Particle p, bool gravityActive)
    {
        double fx = 0;
        double fy = 0;
        foreach (var f in p.forces) 
        { 
            fx += f.X; 
            fy += f.Y; 
        }

        if (gravityActive) 
        {
            fy -= (p.mass * 9.80); 
        }

        return new Force(fx, fy);
    }
    public static double GetAccelerationX(Force force, double mass) 
    {
        return force.X / mass;
    }

    public static double GetAccelerationY(Force force, double mass) 
    {
        return force.Y / mass;
    }

    public static double CalculatePos(double p0, double v0, double a, double t) 
    {
        return p0 + (v0 * t) + (0.5 * a * t * t);
    }

    public static double CalculateVel(double v0, double a, double t) 
    {
        return v0 + (a * t);
    }
    public static double GetMagnitude(double x, double y) 
    {
        return Math.Sqrt(x * x + y * y);
    }
    public static double AngleInDegrees(double X, double Y)
    {
        return Math.Atan2(Y, X) * (180.0 / Math.PI);
    }

    public static double Distance(double x1, double y1, double x2, double y2)
    {
        double dx = x2 - x1;
        double dy = y2 - y1;
        return Math.Sqrt(dx * dx + dy * dy);
    }


}