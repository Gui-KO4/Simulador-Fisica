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
            case "RP":
                Console.WriteLine("Comando inválido: Sintaxe correta: RP NomeParticula PosicaoInicialX PosicaoInicialY VelocidadeInicialX VelocidadeInicialY AceleracaoX AceleracaoY Massa");
                break;
            case "RF":
                Console.WriteLine("Comando inválido: Sintaxe Correta: RF NomeParticula ForcaX ForcaY");
                break;
            case "LP":
                Console.WriteLine("Comando inválido: Sintaxe Correta: LP");
                break;
            case "TG":
                Console.WriteLine("Comando inválido: Sintaxe Correta: TG ON ou TG OFF");
                break;
            case "SMC":
                Console.WriteLine("Comando inválido: Sintaxe Correta: SMC <DuracaoSimulacao> <PassoTemporal>");
                break;
            case "SMD":
                Console.WriteLine("Comando inválido: Sintaxe Correta: SMD <NomeParticula> <DuracaoSimulacao> <PassoTemporal>");
                break;
            case "Exit":
                Console.WriteLine("Comando inválido: Sintaxe Correta: Exit");
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
    public static void ListProjectHeader()
    {
        Console.WriteLine("Lista de projetos: \n");
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

    public static void RegisterParticle(string particleName, bool selectedProject , bool found, bool invalidMass, bool invalidNumbers)
    {

        if (!selectedProject)
        {
            Console.WriteLine("Nenhum projeto selecionado.");
        }
        else if(!found)
        {
            Console.WriteLine($"Já existe uma particula neste projeto chamada {particleName}");
        }
        else if (!invalidMass)
        {
            Console.WriteLine("Mass invalida. O valor da massa deve ser superior a 0");
        }
        else if(!invalidNumbers)
        {
            Console.WriteLine("Parâmetros numéricos inválidos.");
        }
        else
        {
            Console.WriteLine($"Partícula {particleName} registada com sucesso.");
        }

    }

    public static void RegisterForce(string particleName, bool selectedProject, bool selectedParticle, bool invalidNumbers)
    {
        if(!selectedProject)
        {
            Console.WriteLine("Nenhum projeto selecionado.");
        }   
        else if(!selectedParticle)
        {
            Console.WriteLine($"Particula {particleName} não encontrada.");
        }
        else if(!invalidNumbers)
        {
            Console.WriteLine("Parâmetros numéricos inválidos.");
        }
        else
        {
            Console.WriteLine($"Força registada na partícula: {particleName}");
        }
    }

    public static void ListParticles(SortedDictionary<string, Particle> particles,bool selectedProject, bool noParticles)
    {
        if (!selectedProject)
        {
            Console.WriteLine("Nenhum projeto selecionado.");
        }   
        else if (!noParticles)
        {
            Console.WriteLine("Não existem partículas registadas no projeto atual.");
        } 
        else
        {
            Console.WriteLine("Lista de partículas do projeto atualmente selecionado:");
                foreach(Particle particle in particles.Values)
                {
                    Console.WriteLine(particle);   
                }
        }    
    }

    public static void ToggleGravity(bool selectedProject, bool gravity)
    {
        if (!selectedProject)
        {
            Console.WriteLine("Nenhum projeto selecionado");
        }
        else if(gravity)
        {
            Console.WriteLine("Gravidade ativada (g = 9.80 m/s^2).");
        }
        else
        {
            Console.WriteLine("Gradidade desativada.");
        }
    }

    // Related Text to commands to Simulation


        public static void SimulationSummary(double duration, double step, int iterations, string target = null)
    {
        Console.WriteLine($"Tempo total: {duration:F2}s");
        Console.WriteLine($"Passo: {step:F2}s");
        Console.WriteLine($"Número de iterações: {iterations}");
        if (target != null) 
        {
            Console.WriteLine($"Partícula: {target}");
        }
    }

    public static void SimulationTime(double t)
    {
        Console.WriteLine("\n==================================================");
        Console.WriteLine($"INSTANTE DE TEMPO: {t:F2} s");
        Console.WriteLine("==================================================");
    }

    public static void SimulationParticle(string name, double px, double py, double vx, double vy, double ax, double ay, bool isKinematic, double distTotal = 0, double distIntervalo = 0, Force fRes = null)
    {
        if (isKinematic) 
        {
            Console.WriteLine($"\nPartícula: {name}");
        }
        if (!isKinematic && fRes != null)
        {
            Console.WriteLine($"\nPosição: ({px:F2}, {py:F2}) m | módulo = {PhysicEngine.GetMagnitude(px, py):F2} m | ângulo = {PhysicEngine.AngleInDegrees(px, py):F2} graus");
            Console.WriteLine($"Velocidade: ({vx:F2}, {vy:F2}) m/s | módulo = {PhysicEngine.GetMagnitude(vx, vy):F2} m/s | ângulo = {PhysicEngine.AngleInDegrees(vx, vy):F2} graus");
            Console.WriteLine($"Aceleração: ({ax:F2}, {ay:F2}) m/s^2 | módulo = {PhysicEngine.GetMagnitude(ax, ay):F2} m/s^2 | ângulo = {PhysicEngine.AngleInDegrees(ax, ay):F2} graus");
            Console.WriteLine($"Força resultante: ({fRes.X:F2}, {fRes.Y:F2}) N | módulo = {PhysicEngine.GetMagnitude(fRes.X, fRes.Y):F2} N | ângulo = {PhysicEngine.AngleInDegrees(fRes.X, fRes.Y):F2} graus");
        }
        else
        {
            Console.WriteLine($"Posição: ({px:F2}, {py:F2}) m | módulo = {PhysicEngine.GetMagnitude(px, py):F2} m | ângulo = {PhysicEngine.AngleInDegrees(px, py):F2} graus");
            Console.WriteLine($"Velocidade: ({vx:F2}, {vy:F2}) m/s | módulo = {PhysicEngine.GetMagnitude(vx, vy):F2} m/s | ângulo = {PhysicEngine.AngleInDegrees(vx, vy):F2} graus");
            Console.WriteLine($"Aceleração: ({ax:F2}, {ay:F2}) m/s^2 | módulo = {PhysicEngine.GetMagnitude(ax, ay):F2} m/s^2 | ângulo = {PhysicEngine.AngleInDegrees(ax, ay):F2} graus");
            Console.WriteLine($"Deslocamento no intervalo: {distTotal:F2} m");
            Console.WriteLine($"Distância percorrida no intervalo: {distIntervalo:F2} m");
            Console.WriteLine("\n------------------------------------------------");
        }
    }

    public static bool ValidateTime(Project proj, string dStr, string sStr, out double d, out double s)
    {
        d = s = 0;
        if (proj == null) 
        { 
            Console.WriteLine("Nenhum projeto selecionado."); return false;
        }
        if (!double.TryParse(dStr, out d) || !double.TryParse(sStr, out s) || d <= 0 || s <= 0) 
        {
            Console.WriteLine("O valor da duração da simulação ou do passo temporal inválido.");
            return false;
        }
        if (s > d) 
        {
            Console.WriteLine("Passo invalido. O passo não pode ser superior ao tempo total.");
            return false;
        }
        return true;
    }

    public static void ExitSuccess()
    {
        Console.WriteLine("Programa terminado com sucesso!");
    }
}
