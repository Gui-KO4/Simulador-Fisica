
public class ConsoleView
{
    public ConsoleView(){}

    public string ReadCommand()
    {
        return Console.ReadLine();
    }

    public void RPJError(int error, string projectName)
    {
        switch (error)
        {
            case 1:
            Console.WriteLine("Já existe um projeto registado com o nome " + projectName);
            break;
            case 2:
            Console.WriteLine("Comando Inválido. Sintaxe correta: RPJ <NomeProjeto>");
            break;
        }  
    }
    public void LPJError(int error)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Não existem projetos registados.");
            break;
            case 2:
                Console.WriteLine("Comando inválido: Sintaxe correta: LPJ.");
            break;
        }
    }
    public void SPJError(int error, string nomeProjeto)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Projeto " + nomeProjeto + " não encontrado.");
            break;
            case 2:
                Console.WriteLine("Projeto " + nomeProjeto + " já se encontra selecionado");
            break;
            case 3:
                Console.WriteLine("Comando inválido: Sintaxe correta: SPJ <NomeProjeto>");
            break;
        }
    }
    public void RPError(int error, string nomeParticula)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Nenhum projeto selecionado");
            break;
            case 2:
                Console.WriteLine("Já existe uma partícula neste projeto registada com o nome " + nomeParticula);
            break;
            case 3:
                Console.WriteLine("Comando invalido. Sintaxe correta: RP NomeParticula PosicaoInicialX PosicaoInicialY VelocidadeInicialX VelocidadeInicialY AcelaracaoX AcelaracaoY Massa");
            break;
            case 4:
                Console.WriteLine("Massa invalida. O valor da massa deve ser superior a 0.");
            break;
            case 5:
                Console.WriteLine("Parâmetros numérico inválidos.");
            break;
        }
    }
    public void RFError(int error, string nomeParticula)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Nenhum projeto selecionado.");
            break;
            case 2:
                Console.WriteLine("Partícula " + nomeParticula + " não encontrada.");
            break;
            case 3:
                Console.WriteLine("Comando inválido. Sintaxe correta: RF NomeParticula ForcaX ForcaY.");
            break;
            case 4:
                Console.WriteLine("Parâmetros númericos Inválidos.");
            break;
        }
    }
    public void LPError(int error)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Não existem partículas registadas no projeto atual.");
            break;
            case 2:
                Console.WriteLine("Nenhum projeto selecionado");
            break;
            case 3:
                Console.WriteLine("Comando inválido. Sintaxe correta: LP.");
            break;
        }
    }
    public void TGError(int error)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Nenhum Projeto selecionado.");
            break;
            case 2:
                Console.WriteLine("Comando inválido. Sintaxe correta: TG ON ou TG OFF.");
            break;
        }
    }
    public void SMCError(int error)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Nenhum projeto selecionado.");
            break;
            case 2:
                Console.WriteLine("Nenhuma partícula registada.");
            break;
            case 3:
                Console.WriteLine("O valor da duração da simulção ou do passo temporal inválido.");
            break;
            case 4:
                Console.WriteLine("Passo invalido. O passo não pode ser superior ao tempo total.");
            break;
            case 5:
                Console.WriteLine("Comando inválido. Sintaxe correta: SMC <DuracaoSimulacao> <PassoTemporal>");
            break;
        }
    }
    public void SMDError(int error, string nomeParticula)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Nenhum projeto selecionado.");
            break;
            case 2:
                Console.WriteLine("Particula " + nomeParticula + " não se encontra registada no projeto atualmente ativo.");
            break;
            case 3:
                Console.WriteLine("O valor da duração da simulação ou do passo temporal inválido.");
            break;
            case 4:
                Console.WriteLine("Passo inválido. O passo não pode ser superior ao tempo total.");
            break;
            case 5:
                Console.WriteLine("Comando Inválido. Sintaxe correta: SMC <NomeParticula> <DuracaoSimulacao> <PassoTemporal>.");
            break;

        }
    }
    public void ExitError(int error)
    {
        switch(error)
        {
            case 1:
                Console.WriteLine("Comando inválido. Sintaxe Correta: Exit");
            break;
        }
    }
    
}