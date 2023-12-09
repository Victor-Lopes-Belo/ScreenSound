 Dictionary<String, List<float>> bandasRegistradas = new Dictionary<String, List<float>>();
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound :)";
ExibirOpcoesDoMenu();

void ExibirMensagemDeBoasVindas()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu() {
    ExibirMensagemDeBoasVindas();
    int opcaoescolitanumerica = 0;
    while (true)
    {
        try
        {
            Console.WriteLine("\n#################-MENU-##################");
            Console.WriteLine("Digite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para mostrar todas as bandas");
            Console.WriteLine("Digite 3 para avaliar uma banda");
            Console.WriteLine("Digite 4 para exibir a média de uma banda");
            Console.WriteLine("Digite 0 para sair");

            Console.Write("\nDigite a sua opção: ");
            opcaoescolitanumerica = int.Parse(Console.ReadLine()!);
        }
        catch (Exception ex)
        {
            Console.Write("\nDigite apenas número ");
            Thread.Sleep(1500);
            Console.Clear();
            ExibirOpcoesDoMenu(); // break;
        }
        finally
        {
            switch (opcaoescolitanumerica)
            {
                case 1:
                    RegistrarBandas();
                    break;
                case 2:
                    ExbirBandas();
                    break;
                case 3:
                    AvaliarBanda();
                    break;
                case 4:
                    ExibirMediaBanda();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("opção inválida");
                    Thread.Sleep(1500);
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                    break;
            }
        }
    } 
}

void RegistrarBandas()
{
    Console.Clear();
    ExibiTituloDaOpcao("Registro de bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine().ToUpper()!;
    if (bandasRegistradas.ContainsKey(nomeBanda))
    {
        Console.WriteLine($"\nA banda {nomeBanda} já foi cadastrada!");
    } else
    {
        bandasRegistradas.Add(nomeBanda,new List<float>());
        Console.WriteLine($"\nA banda {nomeBanda} foi cadastrada com sucesso!");
    }
    Thread.Sleep(1500);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExbirBandas()
{
    Console.Clear();
    ExibiTituloDaOpcao("Listando as bandas");

    if (bandasRegistradas.Count == 0)
    {
        Console.Write("Não há bandas para serem listadas");
    } else {
        foreach (var banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }
        Console.Write("\nDigite qualquer tecla para volta ao menu inicial ");
        Console.ReadKey();
    }
    Thread.Sleep(1500);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarBanda()
{
    Console.Clear();
    ExibiTituloDaOpcao("Avaliando as bandas");
    float nota = 0;

    if (bandasRegistradas.Count == 0)
    {
        Console.Write("Não há bandas para serem avaliadas");
    }
    else
    {
        Console.Write("Informe o nome da banda que deseja realizar a avalição: ");
        string bandaAvaliada = Console.ReadLine().ToUpper()!;
        if (!bandasRegistradas.ContainsKey(bandaAvaliada))
        {
            Console.Write($"\nA banda {bandaAvaliada} ainda não cadastrada! Utilize a opção 1 para realizar o cadastro ou" +
                          $" utilize a opção 2 para ver todas as bandas já cadastradas!");
            Thread.Sleep(5000);
        } else
        {
            try
            {
                Console.Write($"Informe a nota para a {bandaAvaliada}: ");
                nota = float.Parse(Console.ReadLine()!);
            }
            catch (Exception ex)
            {
                Console.Write("\nDigite apenas número ");
                Thread.Sleep(1500);
                Console.Clear();
                AvaliarBanda();
            }
            finally
            {
                bandasRegistradas[bandaAvaliada].Add(nota);
                Console.Write($"A nota foi registrada com sucesso! ");
            }
        }
    }
    Thread.Sleep(1500);
    Console.Clear();
    ExibirOpcoesDoMenu();
}
void ExibiTituloDaOpcao(string titulo)
{
    string asterisco = string.Empty;
    foreach (var letra in titulo)
    {
        asterisco = asterisco + '*';
    }
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

void ExibirMediaBanda()
{
    Console.Clear();
    ExibiTituloDaOpcao("Media da banda");

    if (bandasRegistradas.Count == 0)
    {
        Console.Write("Não há bandas para serem avaliadas");
    }
    else
    {
        Console.Write("Informe o nome da banda que deseja ver a média: ");
        string bandaAvaliada = Console.ReadLine().ToUpper()!;
        if (!bandasRegistradas.ContainsKey(bandaAvaliada))
        {
            Console.Write($"\nA banda {bandaAvaliada} ainda não cadastrada! Utilize a opção 1 para realizar o cadastro ou" +
                          $" utilize a opção 2 para ver todas as bandas já cadastradas!");
            Thread.Sleep(5000);
        }
        else
        {
            double mediabanda = bandasRegistradas[bandaAvaliada].Average();
            Console.WriteLine($"Média da {bandaAvaliada} é: {mediabanda}");
        }
    }
    Thread.Sleep(5000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}