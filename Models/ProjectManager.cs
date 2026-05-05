public class ProjectManager
{
    public List<Project> projects;

    public ProjectManager()
    {
         projects = new List<Project>();
    }

    public void AddProject(string projectName)
    {
        projects.Add(new Project(projectName));
    }

    public void ListProjects()
    {
        foreach(Project project in projects)
        {
            Console.WriteLine(project);
        }
    }

    public void SelectProject(string projectName)
    {
        foreach(Project project in projects)
        {
            if(project.name == projectName)
            {
                project.state = true;
            }
        }
    }
    public void AddParticle(string particleName, double posX, double posY, double velX, double velY, double acelX, double acelY, double mass)
    {
        
        foreach(Project project in projects)
        {
            if(project.state == true)
            {
                project.particles.Add(new Particle(particleName, posX, posY, velX, velY, acelX, acelY, mass));
                return;
            }
        }

    }
}