using System.Text;
Console.OutputEncoding = Encoding.UTF8;

Console.Title = "Calculadora";

static bool Parar()
{
    try
    {
        Console.WriteLine("Você deseja parar? [S/N]");
        string? resposta = Console.ReadLine()!.ToUpper();

        if (resposta == "S")
        {
            return true;
        }
        else if (resposta == "N")
        {
            return false;
        }
        else
        {
            return Parar();
        }
    }
    catch
    {
        Console.WriteLine("Algo deu errado.");
        return false;
    }
}

int continuar = 1;

while (continuar != 0)
{
    Console.WriteLine("Digite a operação que você deseja realizar: ( + - / * )");
    string? operacao = Console.ReadLine();

    string[] itens_operacao = operacao.Split();

    Calculadora calculadora = new Calculadora(itens_operacao);
    calculadora.show();

    bool continuar_parar = Parar();

    if (continuar_parar)
    {
        break;
    }
}

class Calculadora
{
    private int valorA;
    private int valorB;
    private char operacao;
    private int resultado;
    private bool naoRodar;

    // Capturar Informações
    public Calculadora(string[] _operacao)
    {
        if (verificador(_operacao))
        {
            this.valorA = Convert.ToInt32(_operacao[0]);
            this.valorB = Convert.ToInt32(_operacao[2]);
            this.operacao = Convert.ToChar(_operacao[1]);

            this.naoRodar = false;
        }
        else
        {
            this.naoRodar = true;

            Console.WriteLine("Valores errados");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }

    // Verificação completa
    private bool verificador(string[] _oper)
    {
        if (_oper.Count() > 3 || _oper.Count() < 3)
        {
            return false;
        }
        else if (verificarZero(_oper[2], _oper[1]))
        {
            Console.WriteLine("ERRO! Operação de divisão com 0!");
            return false;
        }
        else if (verificarNumero(_oper[0]) && verificarNumero(_oper[2]) && verificarOperador(_oper[1]))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Verificar número Inteiro
    private bool verificarNumero(string _num)
    {
        try
        {
            int numero = Convert.ToInt32(_num);
            return true;
        }
        catch
        {
            return false;
        }
    }

    // Verificar Operador
    private bool verificarOperador(string _operador)
    {
        try
        {
            char valorOperacao = Convert.ToChar(_operador);
            
            if ("+-/*".Contains(valorOperacao))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    // Verificar Operacao com zero
    private bool verificarZero(string numB, string operB)
    {
        int numero_zero = Convert.ToInt32(numB);
        char char_zero = Convert.ToChar(operB);

        if (numero_zero == 0 && "/".Contains(char_zero))
        {
            return true;
        }
        return false;
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
                int valor_divisao = valorA / valorB;
                definirResultado(valor_divisao);
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
        if (!naoRodar)
        {
            calcular();

            Console.Clear();
            Console.WriteLine($"Resultado da operação:\n{valorA} {operacao} {valorB} = {resultado}");
            Thread.Sleep(3000);
        }
    }
}
