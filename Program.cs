using System.Text;
Console.OutputEncoding = Encoding.UTF8;

Console.Title = "Calculadora";

static bool Verificador(string num_1, string num_2, string item_operacao)
{
    if (listaVerificar.Count() > 3 || listaVerificar.Count() < 3)
    {
        Console.WriteLine("ERRO! O número de elementos não está correto para uma operação!");
        return false;
    }
    else
    {
        try
        {
            int num1 = Convert.ToInt32(num_1);
            int num2 = Convert.ToInt32(num_2);
            char valorOperacao = Convert.ToChar(item_operacao);
            if ("+-/*".Contains(valorOperacao))
            {
                return true;
            }
        }
        catch
        {
            Console.WriteLine("ERRO! O primeiro elemento digitado não é um número inteiro legível!");
            return false;
        }
    }
    return false;
}

Console.WriteLine("Digite a operação que você deseja realizar: ( + - / * )");
string? operacao = Console.ReadLine();

string[] partes_operacao = operacao.Split();
string num1 = partes_operacao[0]
bool valores_testados = Verificador(partes_operacao);

if (valores_testados == true)
{
    Calculadora calculadora = new Calculadora(, valor2, operacaoAtual!);
}

//calculadora.calcular();
//calculadora.show();

Console.ReadKey();

class Calculadora
{
    private int valorA;
    private int valorB;
    private char operacao;
    private int resultado;

    // Capturar Informações
    public Calculadora(int _valorA, int _valorB, char _operacao)
    {
        this.valorA = _valorA;
        this.valorB = _valorB;
        this.operacao = _operacao;
    }

    // Calculadora  
    public void calcular()
    {
        switch (Convert.ToString(operacao))
        {
            case "+":
                int valor_soma = valorA + valorB;
                definirResultado(valor_soma);
                break;
            case "-":
                int valor_subtracao = valorA - valorB;
                definirResultado(valor_subtracao);
                break;
            case "*":
                int valor_multiplicacao = valorA * valorB;
                definirResultado(valor_multiplicacao);
                break;
            case "/":
                if (valorB == 0)
                {
                    Console.WriteLine("Não é possível fazer divisão por 0.");
                    break;
                }
                else
                {
                    int valor_divisao = valorA / valorB;
                    definirResultado(valor_divisao);
                }
                break;
            default:
                break;
        }
    }

    // Getter
    public int retornaResultado()
    {
        return resultado;
    }

    // Setter
    public void definirResultado(int _resultado)
    {
        resultado = _resultado;
    }

    // Mostrar Resultado
    public void show()
    {
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine($"Resultado da operação:\n{valorA} {operacao} {valorB} = {resultado}");
    }
}
