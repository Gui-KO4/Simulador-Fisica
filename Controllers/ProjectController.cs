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
            OutputView.SelectProject(name, false, projects[name].state);
            return;
        }
        if (ActiveProject != null && ActiveProject.name == name)
        {
            OutputView.SelectProject(name, true, projects[name].state);
            return;
        }
        ActiveProject = projects[name];
        OutputView.SelectProject(name, true, false);
    }


}