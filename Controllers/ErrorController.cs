using System.Collections;
using System.Collections.Generic;

public class ErrorController
{
    public ErrorController()
    {
        
    }
    public bool Error(string[] commandParts, List<Project> projects, ErrorView console)
    {
        switch(commandParts[0]){
        case "RPJ":
            foreach(Project project in projects)
                if (commandParts[1] == project.name)
                {
                    console.RPJError(1, commandParts[1]);
                    return false;
                }
                else if (commandParts.Length > 2)
                {
                    console.RPJError(2, commandParts[1]);
                    return false;
                }
        break;
        case "LPJ":
        
            if (projects.Count == 0)
            {
                console.LPJError(1);
                return false;
            }
            if (commandParts.Length > 1)
            {
                console.LPJError(2); 
                return false;  
            }
            
        break;
        case "SPJ":
        {
            Project projetoAtivo = null;
            foreach(Project p in projects)
            {
                if(p.state == true) 
                {
                    projetoAtivo = p;
                    break; 
                }
            }
            if (projetoAtivo != null && projetoAtivo.name == commandParts[1])
            {
                console.SPJError(2, commandParts[1]);
                return false;
            }
            bool found = false;
            foreach(Project project in projects)
                if (commandParts[1] == project.name)
                {
                    found = true;
                    break;
                }
            if (!found)
            {
                console.SPJError(1, commandParts[1]);
                return false;
            }
            if (commandParts.Length > 2)
            {
                console.SPJError(3, commandParts[1]);
                return false;
            }
            break;
        }
        case "RP":
        {
            Project projetoAtivo = null;
            foreach(Project p in projects)
            {
                if(p.state == true) 
                {
                    projetoAtivo = p;
                    break; 
                }
            }
            if (projetoAtivo == null)
            {
                console.RPError(1, commandParts[1]);
                return false;
            }
            foreach(Particle particle in projetoAtivo.particles)
                if (commandParts[1] == particle.name)
                {
                    console.RPError(2, commandParts[1]);
                    return false;
                }
            if (commandParts.Length != 9)
            {
                console.RPError(3, commandParts[1]);
                return false;
            }
            if (!double.TryParse(commandParts[2], out double posXi) || !double.TryParse(commandParts[3], out double posYi) 
            || !double.TryParse(commandParts[4], out double velXi) || !double.TryParse(commandParts[5], out double velYi)
            || !double.TryParse(commandParts[6], out double acelXi) || !double.TryParse(commandParts[7], out double acelYi))
            {
                console.RPError(5, commandParts[1]);
                return false;
            }
            if (double.TryParse(commandParts[8], out double massa))
            {
                if (massa < 0)
                {
                    console.RPError(4, commandParts[1]);
                    return false;
                }
            }
            else
            {
                console.RPError(4, commandParts[1]);
                return false;
            }
        }
        break;
        case "RF":
        {
            Project projetoAtivo = null;
            foreach(Project p in projects)
            {
                if(p.state == true) 
                {
                    projetoAtivo = p;
                    break; 
                }
            }
            if (projetoAtivo == null)
            {
                console.RFError(1, commandParts[1]);
                return false;
            }
            bool found = false;
            foreach(Particle particle in projetoAtivo.particles)
                if (commandParts[1] == particle.name)
                {
                    found = true;
                    break;
                }
            if (!found)
            {
                console.RFError(2, commandParts[1]);
                return false;
            }
            if (commandParts.Length != 4)
            {
                console.RFError(3, commandParts[1]);
                return false;
            }
            if (!double.TryParse(commandParts[2], out double forcaX) || !double.TryParse(commandParts[3], out double forcaY))
            {
                console.RFError(4, commandParts[1]);
                return false;
            }
        }
        break;
        case "LP":
        {
            Project projetoAtivo = null;
            foreach(Project p in projects)
            {
                if(p.state == true) 
                {
                    projetoAtivo = p;
                    break; 
                }
            }
            if (projetoAtivo == null)
            {
                console.LPError(2); 
                return false;
            }
            if (projetoAtivo.particles.Count == 0)
            {
                console.LPError(1); 
                return false;
            }
            if (commandParts.Length > 1 || commandParts[0] != "LP")
            {
                console.LPError(3);
                return false;
            }
            break;
        }
        case "TG":
        {
            Project projetoAtivo = null;
            foreach(Project p in projects)
            {
                if(p.state == true) 
                {
                    projetoAtivo = p;
                    break; 
                }
            }
            if (projetoAtivo == null)
            {
                console.TGError(1); 
                return false;
            }
            if (commandParts.Length != 2 || (commandParts[1] != "ON" && commandParts[1] != "OFF"))
            {
                console.TGError(2);
                return false;
            }
        }
        break;
        case "SMC":
        {
            Project projetoAtivo = null;
            foreach(Project p in projects)
            {
                if(p.state == true) 
                {
                    projetoAtivo = p;
                    break; 
                }
            }
            if (projetoAtivo == null)
            {
                console.SMCError(1); 
                return false;
            }
            if (projetoAtivo.particles.Count == 0)
            {
                console.SMCError(2); 
                return false;
            }
            if (commandParts.Length > 1 || commandParts[0] != "SMC")
            {
                console.SMCError(3);
                return false;
            }
            if (Convert.ToDouble(commandParts[1]) > Convert.ToDouble(commandParts[2]))
            {
                console.SMCError(4);
                return false;
            }

            if (!double.TryParse(commandParts[1], out double duracaoSimulacao) 
            || !double.TryParse(commandParts[2], out double passoTemporal))
            {
                console.SMCError(3);
                return false;
            }


        }
            break;
        case "SMD":
        {
            Project projetoAtivo = null;
            foreach(Project p in projects)
            {
                if(p.state == true) 
                {
                    projetoAtivo = p;
                    break; 
                }
            }
            if (projetoAtivo == null)
            {
                console.SMDError(1, commandParts[1]); 
                return false;
            }
            bool found = false;
            foreach(Particle particle in projetoAtivo.particles)
                if (commandParts[1] == particle.name)
                {
                    found = true;
                    break;
                }
            if (!found)
            {
                console.SMDError(2, commandParts[1]);
                return false;
            }
            if (commandParts.Length > 3 || commandParts[0] != "SMD")
            {
                console.SMDError(5, commandParts[1]);
                return false;
            }
            if (Convert.ToDouble(commandParts[2]) > Convert.ToDouble(commandParts[3]))
            {
                console.SMDError(4, commandParts[1]);
                return false;
            }

            if (!double.TryParse(commandParts[2], out double duracaoSimulacao) 
            || !double.TryParse(commandParts[3], out double passoTemporal))
            {
                console.SMDError(3, commandParts[1]);
                return false;
            }
        }
        break;
        case "Exit":
            if (commandParts.Length != 1 || commandParts[0] != "Exit")
            {
                console.ExitError(1);
                return false;
            }
        break;
        }
        return true; //remove this later
    }
}