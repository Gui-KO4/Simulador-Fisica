//Relacionado aos comandos:
//RPJ
//LPJ
//SPJ

public class ProjectController
{
    Dictionary<string, Project> projects = new Dictionary<string, Project>();
    Project ActiveProject;

    public void RegisterProject(string name)
    {
        if (projects.ContainsKey(name))
        {
            OutputView.ProjectRegistered(false, name);
            return;
        }
        Project newProject = new Project(name);
        projects.Add(name, newProject);
        OutputView.ProjectRegistered(true, name);
    }

    public void ListProjects()
    {
        if (projects.Count == 0)
        {
            OutputView.ListProject(null, null);
            return;
        }

        foreach (var project in projects)
        {
            OutputView.ListProject(project.Key, project.Value.currentState());
        }
    }

    public void SelectProject(string name)
    {
        if (!projects.ContainsKey(name))
        {
            OutputView.SelectProject(name, false, false);
            return;
        }
        else if (ActiveProject != null && ActiveProject.name == name)
        {
            OutputView.SelectProject(name, true, projects[name].state);
            return;
        }
        else if(ActiveProject != null && ActiveProject.name != name)
        {
            //Desativa o projeto ativo
            ActiveProject.state = false;

            //Ativa o novo projeto
            OutputView.SelectProject(name, true, projects[name].state);
            ActiveProject = projects[name];
            ActiveProject.state = true;

        }
        else if (ActiveProject == null)
        {
            OutputView.SelectProject(name, true, projects[name].state);
            ActiveProject = projects[name];
            ActiveProject.state = true;
        }
        
    }

    public void RegisterParticle(string particleName, string initialPositionX, string initialPositionY, string initialVelocityX, string initialVelocityY, string accelerationX, string accelerationY, string mass)
    {
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