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
        OutputView.ListProjectHeader();
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
    
    public void ToggleGravity(string[] parts,string state)
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
        }else if(state == "ON"){
            OutputView.ToggleGravity(true, true);   
            ActiveProject.gravity = true;
        }else{
        OutputView.InvalidSintax(parts);
        }
    }

    public Project GetActiveProject()
    {
        return ActiveProject;
    }

    // Helper Methods para os testes
    public Project GetProject(string name)
    {
        if (projects.ContainsKey(name))
        {
            return projects[name];
        }
        return null;
    }

    public int GetTotalProjects()
    {
        return projects.Count;
    }

}