// Alunos: Arthur Rocha Fonseca e Maria Fernanda Werneck, 205

using System.Globalization;

int opcao = 0;
        do
        {
            Console.WriteLine("Informe o que deseja fazer:");
            Console.WriteLine("(1) Calcular IMC");
            Console.WriteLine("(2) Peso Ideal");
            Console.WriteLine("(3) Jogo de adivinhação");
            Console.WriteLine("(4) Exibir 5 valores fornecidos pelo usuário em ordem decrescente");
            Console.WriteLine("(5) Calcular Fatorial");
            Console.WriteLine("(6) Verificar Primo");
            Console.WriteLine("(7) Calcular Área do Retângulo");
            Console.WriteLine("(8) Calcular Área do Triângulo");
            Console.WriteLine("(9) Calcular Área da Circunferência");
            Console.WriteLine("(0) Encerrar");
            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CalcularIMC();
                    break;
                case 2:
                    PesoIdeal();
                    break;
                case 3:
                    JogoAdivinhacao();
                    break;
                case 4:
                    OrdenarValores();
                    break;
                case 5:
                    CalcularFatorial();
                    break;
                case 6:
                    Console.WriteLine("Informe um número inteiro:");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(VerificaPrimo(numero));
                    break;
                case 7:
                    CalcularAreaRetangulo();
                    break;
                case 8:
                    CalcularAreaTriangulo();
                    break;
                case 9:
                    CalcularAreaCircunferencia();
                    break;
            }
        } while (opcao != 0);
        Console.WriteLine("Obrigado por sua participação!");
        Console.WriteLine("Programa Finalizado");
    

    static void CalcularIMC()
    {
        Console.WriteLine("Informe seu peso:");
        int peso = int.Parse(Console.ReadLine());
        Console.WriteLine("Informe sua altura:");
        float altura = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        float imc = peso / (altura * altura);
        Console.WriteLine($"Para o peso {peso} e a altura {altura} o imc calculado foi {imc:f1}");
        string status = string.Empty;
        if (imc <= 16.9)
            status = "muito abaixo do peso";
        else if (imc <= 18.4)
            status = "magreza";
        else if (imc <= 24.9)
            status = "normal";
        else if (imc <= 29.9)
            status = "Sobrepeso";
        else if (imc <= 39.9)
            status = "Obesidade";
        else
            status = "Obesidade Grave";
        Console.WriteLine($"O IMC {imc} indica a classificação {status}");
    }

    static void PesoIdeal()
    {
        Console.WriteLine("Informe sua altura:");
        float altura = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        float minIdeal = (float)(Math.Pow(altura, 2) * 18.5);
        float maxIdeal = (float)(Math.Pow(altura, 2) * 24.9);
        Console.WriteLine($"Pelo IMC o peso ideal de uma pessoa com altura {altura} fica entre {minIdeal:f1} e {maxIdeal:f1}");
    }

    static void JogoAdivinhacao()
    {
        Console.WriteLine("Você tem 10 tentativas para adivinhar um número entre 1 e 100!");
        Random random = new Random();
        int valorSorteado = random.Next(1, 100);
        int tentativa;
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{i + 1}a. tentativa:");
            tentativa = Convert.ToInt32(Console.ReadLine());
            if (tentativa == valorSorteado)
            {
                Console.WriteLine($"Parabéns!! Você adivinhou o número em {i + 1} tentativas!!!");
                break;
            }
            if (i < 9)
            {
                if (tentativa < valorSorteado)
                    Console.WriteLine("O valor sorteado é maior que o número informado. Tente novamente!");
                else if (tentativa > valorSorteado)
                    Console.WriteLine("O valor sorteado é menor que o número informado. Tente novamente!");
            }
            else
            {
                Console.WriteLine("Você não possui mais tentativas!");
            }
        }
        Console.WriteLine("Fim de Jogo!");
    }

    static void OrdenarValores()
    {
        int tamanho = 5;
        int[] valores = new int[tamanho];
        for (int i = 0; i < valores.Length; i++)
        {
            Console.WriteLine("Informe o {0}o. valor: ", i + 1);
            valores[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Valores Informados:");
        foreach (var valor in valores)
        {
            Console.WriteLine(valor + " ");
        }
        for (int i = 0; i < valores.Length; i++)
        {
            for (int j = i + 1; j < valores.Length; j++)
            {
                if (valores[i] < valores[j])
                {
                    var temp = valores[i];
                    valores[i] = valores[j];
                    valores[j] = temp;
                }
            }
        }
        Console.WriteLine("Valores ordenados:");
        foreach (var valor in valores)
        {
            Console.WriteLine(valor + " ");
        }
    }

    static string VerificaPrimo(int numero)
    {
        int cont = numero / 2;

        for (int divisor = 2; divisor <= cont; divisor++)
        {
            if ((numero % divisor) == 0)
                return "não é primo";
        }
        return "é primo";
    }

    static void CalcularAreaRetangulo()
    {
        Console.WriteLine("Informe a base do retângulo:");
        float baseRetangulo = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Informe a altura do retângulo:");
        float alturaRetangulo = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        float areaRetangulo = baseRetangulo * alturaRetangulo;
        Console.WriteLine($"A área do retângulo é: {areaRetangulo:f2}\n\n");
    }

    static void CalcularAreaTriangulo()
    {
        Console.WriteLine("Informe o lado A do triângulo:");
        float ladoA = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Informe o lado B do triângulo:");
        float ladoB = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("Informe o lado C do triângulo:");
        float ladoC = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        if (ladoA + ladoB > ladoC && ladoA + ladoC > ladoB && ladoB + ladoC > ladoA)
        {
            float p = (ladoA + ladoB + ladoC) / 2;
            float areaTriangulo = (float)Math.Sqrt(p * (p - ladoA) * (p - ladoB) * (p - ladoC));
            Console.WriteLine($"A área do triângulo é: {areaTriangulo:f2}\n\n");
        }
        else
        {
            Console.WriteLine("Os valores fornecidos não formam um triângulo válido.");
        }
    }
    
    static void CalcularAreaCircunferencia()
    {
        Console.WriteLine("Informe o raio da circunferência:");
        float raio = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        float pi = 3.14f;
        float areaCircunferencia2 = raio * raio;
        float areaCircunferencia = (pi * areaCircunferencia2 );
        Console.WriteLine($"Consideirando que pi = 3,14\nA área da circunferência é: {areaCircunferencia:f2} ou {areaCircunferencia2:f2}pi\n\n");
    }

    static void CalcularFatorial()
    {
        Console.WriteLine("Informe um número inteiro para calcular o fatorial:");
        int numero = Convert.ToInt32(Console.ReadLine());
        decimal fatorial = 1;

        for (int i = 1; i <= numero; i++)
        {
            fatorial *= i;
        }

        Console.WriteLine($"O fatorial de {numero} é {fatorial}.\n\n");
    }