public static class OutputView
{
    // Generic output for invalid instructions based on its type
    public static void InvalidSintax(string[] parts)
    {
        switch(parts[0])
        {
            case "RPJ":
                Console.WriteLine("Comando inválido. Sintaxe correta: RPJ <NomeProjeto>.");
                break;
            case "LPJ":
                Console.WriteLine("Comando inválido: Sintaxe correta: LPJ");
                break;
            case "SPJ":
                Console.WriteLine("Comando inválido: Sintaxe correta: SPJ <NomeProjeto>.");
                break;
            default:
                Console.WriteLine("Instrução inválida.");
                break;
        }
    }

    //Related Text to commands to Project
    public static void ProjectRegistered(bool sucess, string projectName)
    {
        if(sucess)
        {
            Console.WriteLine("Projeto registado com sucesso.");
        }
        else
        {
            Console.WriteLine($"Já existe um projeto registado com o nome {projectName}.");
        }
    }

    public static void ListProject(string projectName, string state)
    {
        if(projectName == null)
        {
            Console.WriteLine("Nenhum projeto registado.");
            return;
        }
        else
        {
            Console.WriteLine($"{projectName} | Estado: {state}");
        }
    }

    public static void SelectProject(string projectName,bool found, bool state)
    {
        if(found && state == false)
        {
            Console.WriteLine($"Projeto {projectName} selecionado com sucesso.");
        }
        else if(found && state == true)
        {
            Console.WriteLine($"Projeto {projectName} já se encontra selecionado.");
        }
        else
        {
            Console.WriteLine($"Projeto {projectName} não encontrado.");
        }
    }

    // Related Text to commands to particles


}
