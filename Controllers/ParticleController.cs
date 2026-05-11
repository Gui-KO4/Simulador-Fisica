// Lida com todas as operações relacionadas com partículas no ActiveProject
// Depende do ProjectController para obter o ActiveProject
// Commandos para particulas:
// Ativar e desativar Gravidade

public class ParticleController
{
    private ProjectController projectController;
    Project ActiveProject;

    public ParticleController(ProjectController sharedProjectController)
    {
        projectController = sharedProjectController;
    }
    
    
    public void RegisterParticle( string particleName, string initialPositionX, string initialPositionY, string initialVelocityX, string initialVelocityY, string accelerationX, string accelerationY, string mass)
    {
        ActiveProject = projectController.GetActiveProject();
        
        double initialPositionXValue;
        double initialPositionYValue;
        double initialVelocityXValue;
        double initialVelocityYValue;
        double accelerationXValue;
        double accelerationYValue;
        double massValue;
        if(ActiveProject == null)
        {
            OutputView.RegisterParticle(particleName, false, false, false, false);
            return;
        }
        else if(ActiveProject.particles.ContainsKey(particleName))
        {
            OutputView.RegisterParticle(particleName,true, false, false, false);
            return;    
        }
        else if(double.TryParse(mass, out massValue) && massValue >= 0)
        {
            OutputView.RegisterParticle(particleName,true, true, false, false);
            return;
        }
        else if(double.TryParse(initialPositionX, out initialPositionXValue) 
                && double.TryParse(initialPositionY, out initialPositionYValue)
                && double.TryParse(initialVelocityX, out initialVelocityXValue)
                && double.TryParse(initialVelocityY, out initialVelocityYValue)
                && double.TryParse(accelerationX, out accelerationXValue)
                && double.TryParse(accelerationY, out accelerationYValue))
        {
            OutputView.RegisterParticle(particleName,true, true, true, false);
            return;
        }
        double.TryParse(initialPositionX, out initialPositionXValue); 
        double.TryParse(initialPositionY, out initialPositionYValue);
        double.TryParse(initialVelocityX, out initialVelocityXValue);
        double.TryParse(initialVelocityY, out initialVelocityYValue);
        double.TryParse(accelerationX, out accelerationXValue);
        double.TryParse(accelerationY, out accelerationYValue);
        double.TryParse(mass, out massValue);

        Particle particle = new Particle(particleName, initialPositionXValue, initialPositionYValue, initialVelocityXValue, initialVelocityYValue, accelerationXValue, accelerationYValue, massValue);      
        ActiveProject.particles.Add(particleName, particle);
        OutputView.RegisterParticle(particleName,true, true, true, false);
    }

    public void RegisterForce(string particleName, string forceX, string forceY)
    {
        ActiveProject = projectController.GetActiveProject();

        double forceXValue;
        double forceYValue;

        if(ActiveProject == null)
        {
            OutputView.RegisterForce(particleName, false, false, false);
            return;   
        }   
        else if(!ActiveProject.particles.ContainsKey(particleName))
        {
            OutputView.RegisterForce(particleName, true, false, false);
            return;
        }
        else if(double.TryParse(forceX, out forceXValue) && double.TryParse(forceY, out forceYValue))
        {
            OutputView.RegisterForce(particleName, true, true, false);
            return;
        }
            double.TryParse(forceX, out forceXValue);
            double.TryParse(forceY, out forceYValue);
            Force force = new Force(forceXValue, forceYValue);
            ActiveProject.particles[particleName].forces.Add(force);
            OutputView.RegisterForce(particleName, true, true, true);
    }

    public void ListParticles()
    {
        ActiveProject = projectController.GetActiveProject();
        
        if(ActiveProject == null)
        {
            OutputView.ListParticles(ActiveProject.particles, false, false);
            return;            
        }
        else if(ActiveProject.particles.Count() == 0)
        {
            OutputView.ListParticles(ActiveProject.particles, true, false);
            return;
        }
        else
        {
            OutputView.ListParticles(ActiveProject.particles, true, true);
            return;
        }
    }

        public void ToggleGravity(string state)
    {
        if(ActiveProject == null)
        {
            OutputView.ToggleGravity(false, false);
            return;
        }
        else if(state == "OFF")
        {
            OutputView.ToggleGravity(true, false);
            ActiveProject.gravity = false;
            return;
        }
            OutputView.ToggleGravity(true, true);   
            ActiveProject.gravity = true;
    }



    
}