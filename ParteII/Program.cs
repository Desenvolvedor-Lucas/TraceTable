/*
 * PROBLEMA 1:	Crie uma Tabela que calcule pela fórmula o Rendimento de um Investimento.				
 * Valor Presente	1000				
 * Taxa de Juros	5%				
 * Período (mês)	12
*/ //Ok

/*
 * PROBLEMA 2: 	Crie uma Tabela por iteração, sem usar fórmula, mas função recursiva, para 6 meses (Dica: Use vetor)						
 * Valor Presente	3800						
 * Taxa de Juros	1,25%						
 * Período (mês)	6
*/ //Ok

/*
 * PROBLEMA 3: 	Elabore um programa em C# que leia as Entradas e mostre o rendimento calculado.				
 * Valor Presente	?				
 * Taxa de Juros	?				
 * Período (anos)	?				
*/ //Ok

/*
 * PROBLEMA 4: 	Elabore um tabela de iteração, caso ocorra um Resgate do Rendimento no 5º mês, o Saldo?.					
 * Valor Presente	2000		Acumulado		    ?	
 * Taxa de Juros	4,50%		Resgate Rendimento:	?	
 * Período (mês)	12		    Saldo Pós Resgate	?	
*/ //Ok

/*
 * PROBLEMA 5:	Quais seriam os cálculos para Problema 2, dado Valor Futuro R$ 7.390,61:				
 * Valor Presente Investido:		? 		
 * Taxa de Juros		            ? 		
 * Número Períodos (mes)		    ? 		
 */ //Ok

#pragma warning disable CS8604 // Possível argumento de referência nula.
var isCalcular = true;
while (isCalcular)
{
    try
    {
        Console.WriteLine("\nCALCULANDO JUROS COMPOSTO\n");
        Console.WriteLine("Quer calcular qual é o valor futuro ou inicial?");
        Console.Write("1 para futuro e 0 para inicial: ");
        var tipoCalcula = int.Parse(Console.ReadLine());
        if (tipoCalcula > 1 || tipoCalcula < 0)
            throw new Exception();

        if(tipoCalcula == 1)
            CalcularValorFuturo();
        else
            CalcularValorInicial();

        isCalcular = ContinuarCalculando();
    }
    catch
    {
        Console.WriteLine("Valor invalido, digite somente os números possíveis!!");
        isCalcular = ContinuarCalculando();
    }
}

bool ContinuarCalculando()
{
    Console.Write("\nDeseja calcular mais? 1 para sim e 0 não: ");
    if (int.Parse(Console.ReadLine()) == 1)
        return true;
    else
        return false;
}

void CalcularValorFuturo()
{
    Console.Write("Digite o número do valor presente inicial: ");
    double valorPresente = double.Parse(Console.ReadLine());
    Console.Write("Digite o número da taxa de Juros: ");
    double taxaJuros = double.Parse(Console.ReadLine());

    double valorFuturo = 0.0;
    int periodo = 0;
    var isResgate = false;
    var valorDeEntrada = valorPresente;

    Console.Write("Digite o número de periodo sendo 1 para mês e 0 para ano: ");
    int tipoPeriodo = int.Parse(Console.ReadLine());

    if (tipoPeriodo == 0)
    {
        Console.Write("Digite o número de Anos: ");
        int ano = int.Parse(Console.ReadLine());
        periodo = ano;

        Console.Write("Tem resgate de rendimento? 1 para sim e 0 para não: ");
        if (int.Parse(Console.ReadLine()) == 1)
            isResgate = true;

        if (isResgate)
        {
            Console.Write($"Qual ano entre 1 e {periodo} será o resgate? número: ");
            var resgateAno = int.Parse(Console.ReadLine());
            if (resgateAno < 1 || resgateAno > periodo)
                throw new Exception();

            Console.WriteLine("\nAnos   |    Valor com juros    |    Resgate de rendimento");
            for (var i = 1; i <= periodo; i++)
            {
                if (i != resgateAno)
                {
                    for (var j = 1; j <= 12; j++)
                    {
                        valorFuturo = valorPresente * (1 + (taxaJuros / 100));
                        valorPresente = valorFuturo;
                    }
                    Console.WriteLine($"{i}           {valorFuturo.ToString("C")}             {0.ToString("C")}");

                }
                else
                {
                    Console.WriteLine("\n------------------------------------------------------------------------");
                    Console.WriteLine("Chegou o ano do resgate!!!");
                    Console.Write($"Informe o valor sendo ele maior que 0 e menor que {valorPresente.ToString("C")}: ");
                    var resgateValor = double.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------\n");
                    if (resgateValor < 1 || resgateValor > valorPresente)
                        throw new Exception();

                    valorPresente -= resgateValor;
                    for (var j = 1; j <= 12; j++)
                    {
                        valorFuturo = valorPresente * (1 + (taxaJuros / 100));
                        valorPresente = valorFuturo;
                    }
                    Console.WriteLine($"{i}           {valorFuturo.ToString("C")}             {resgateValor.ToString("C")}");

                }
            }
        }
        else
        {
            Console.WriteLine("\nAnos   |    Valor com juros");
            for (int i = 1; i <= periodo; i++)
            {
                for (var j = 1; j <= 12; j++)
                {
                    valorFuturo = valorPresente * (1 + (taxaJuros / 100));
                    valorPresente = valorFuturo;
                }
                Console.WriteLine($"{i}           {valorFuturo.ToString("C")}");
            }
        }
    }
    else if (tipoPeriodo == 1)
    {
        Console.Write("Digite o número de mês: ");
        int mes = int.Parse(Console.ReadLine());
        periodo = mes;

        Console.Write("Tem resgate de rendimento? 1 para sim e 0 para não: ");
        if (int.Parse(Console.ReadLine()) == 1)
            isResgate = true;

        if (isResgate)
        {
            Console.Write($"Qual mês entre 1 e {periodo} será o resgate? número: ");
            var resgateMes = int.Parse(Console.ReadLine());
            if (resgateMes < 1 || resgateMes > periodo)
                throw new Exception();

            Console.WriteLine("\nMês    |    Valor com juros    |    Resgate de rendimento");
            for (var i = 1; i <= periodo; i++)
            {
                if (i != resgateMes)
                {
                    valorFuturo = valorPresente * (1 + (taxaJuros / 100));
                    Console.WriteLine($"{i}           {valorFuturo.ToString("C")}             {0.ToString("C")}");
                    valorPresente = valorFuturo;
                }
                else
                {
                    Console.WriteLine("\n------------------------------------------------------------------------");
                    Console.WriteLine("Chegou o mês do resgate!!!");
                    Console.Write($"Informe o valor sendo ele maior que 0 e menor que {valorPresente.ToString("C")}: ");
                    var resgateValor = double.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------\n");
                    if (resgateValor < 1 || resgateValor > valorPresente)
                        throw new Exception();

                    valorPresente -= resgateValor;
                    valorFuturo = valorPresente * (1 + (taxaJuros / 100));
                    Console.WriteLine($"{i}           {valorFuturo.ToString("C")}             {resgateValor.ToString("C")}");
                    valorPresente = valorFuturo;
                }
            }
        }
        else
        {
            Console.WriteLine("\nMês    |    Valor com juros");
            for (var i = 1; i <= periodo; i++)
            {
                valorFuturo = valorPresente * (1 + (taxaJuros / 100));
                Console.WriteLine($"{i}           {valorFuturo.ToString("C")}");
                valorPresente = valorFuturo;
            }
        }
    }
    else
    {
        Console.WriteLine("Digite apenas 1 para mês e 0 para ano");
        throw new Exception();
    }


    Console.WriteLine($"\nRESULTADO APÓS JUROS\n" +
   $"\nValor Presente: {valorDeEntrada}" +
   $"\nTaxa de Juros : {taxaJuros}%" +
   $"\nPeriodo : {periodo}" +
   $"\nValor Futuro : {valorFuturo.ToString("C")}\n");

}

void CalcularValorInicial()
{
    Console.Write("Digite o número do valor futuro: ");
    double valorFuturo = double.Parse(Console.ReadLine());
    Console.Write("Digite o número da taxa de Juros: ");
    double taxaJuros = double.Parse(Console.ReadLine());

    double valorInicial = 0.0;
    int periodo = 0;
    var isResgate = false;
    var valorDeEntrada = valorFuturo;

    Console.Write("Digite o número de periodo sendo 1 para mês e 0 para ano: ");
    int tipoPeriodo = int.Parse(Console.ReadLine());

    if (tipoPeriodo == 0)
    {
        Console.Write("Digite o número de Anos: ");
        int ano = int.Parse(Console.ReadLine());
        periodo = ano;

        Console.Write("Tem resgate de rendimento? 1 para sim e 0 para não: ");
        if (int.Parse(Console.ReadLine()) == 1)
            isResgate = true;

        if (isResgate)
        {
            Console.Write($"Qual ano entre 1 e {periodo} será o resgate? número: ");
            var resgateAno = int.Parse(Console.ReadLine());
            if (resgateAno < 1 || resgateAno > periodo)
                throw new Exception();

            Console.WriteLine("\nAnos   |    Valor com juros    |    Resgate de rendimento");
            for (var i = 1; i <= periodo; i++)
            {
                if (i != resgateAno)
                {
                    for (var j = 1; j <= 12; j++)
                    {
                        valorInicial = valorFuturo / (1 + (taxaJuros / 100));
                        valorFuturo = valorInicial;
                    }
                    Console.WriteLine($"{i}           {valorInicial.ToString("C")}             {0.ToString("C")}");

                }
                else
                {
                    Console.WriteLine("\n------------------------------------------------------------------------");
                    Console.WriteLine("Chegou o ano do resgate!!!");
                    Console.Write($"Informe o valor sendo ele maior que 0 e menor que {valorFuturo.ToString("C")}: ");
                    var resgateValor = double.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------\n");
                    if (resgateValor < 1 || resgateValor > valorFuturo)
                        throw new Exception();

                    valorFuturo -= resgateValor;
                    for (var j = 1; j <= 12; j++)
                    {
                        valorInicial = valorFuturo / (1 + (taxaJuros / 100));
                        valorFuturo = valorInicial;
                    }
                    Console.WriteLine($"{i}           {valorInicial.ToString("C")}             {resgateValor.ToString("C")}");

                }
            }
        }
        else
        {
            Console.WriteLine("\nAnos   |    Valor com juros");
            for (int i = 1; i <= periodo; i++)
            {
                for (var j = 1; j <= 12; j++)
                {
                    valorInicial = valorFuturo / (1 + (taxaJuros / 100));
                    valorFuturo = valorInicial;
                }
                Console.WriteLine($"{i}           {valorInicial.ToString("C")}");
            }
        }
    }
    else if (tipoPeriodo == 1)
    {
        Console.Write("Digite o número de mês: ");
        int mes = int.Parse(Console.ReadLine());
        periodo = mes;

        Console.Write("Tem resgate de rendimento? 1 para sim e 0 para não: ");
        if (int.Parse(Console.ReadLine()) == 1)
            isResgate = true;

        if (isResgate)
        {
            Console.Write($"Qual mês entre 1 e {periodo} será o resgate? número: ");
            var resgateMes = int.Parse(Console.ReadLine());
            if (resgateMes < 1 || resgateMes > periodo)
                throw new Exception();

            Console.WriteLine("\nMês    |    Valor com juros    |    Resgate de rendimento");
            for (var i = 1; i <= periodo; i++)
            {
                if (i != resgateMes)
                {
                    valorInicial = valorFuturo / (1 + (taxaJuros / 100));
                    Console.WriteLine($"{i}           {valorInicial.ToString("C")}             {0.ToString("C")}");
                    valorFuturo = valorInicial;
                }
                else
                {
                    Console.WriteLine("\n------------------------------------------------------------------------");
                    Console.WriteLine("Chegou o mês do resgate!!!");
                    Console.Write($"Informe o valor sendo ele maior que 0 e menor que {valorFuturo.ToString("C")}: ");
                    var resgateValor = double.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------\n");
                    if (resgateValor < 1 || resgateValor > valorFuturo)
                        throw new Exception();

                    valorFuturo -= resgateValor;
                    valorInicial = valorFuturo / (1 + (taxaJuros / 100));
                    Console.WriteLine($"{i}           {valorInicial.ToString("C")}             {resgateValor.ToString("C")}");
                    valorFuturo = valorInicial;
                }
            }
        }
        else
        {
            Console.WriteLine("\nMês    |    Valor com juros");
            for (var i = 1; i <= periodo; i++)
            {
                valorInicial = valorFuturo / (1 + (taxaJuros / 100));
                Console.WriteLine($"{i}           {valorInicial.ToString("C")}");
                valorFuturo = valorInicial;
            }
        }
    }
    else
    {
        Console.WriteLine("Digite apenas 1 para mês e 0 para ano");
        throw new Exception();
    }


    Console.WriteLine($"\nRESULTADO APÓS JUROS\n" +
   $"\nValor Futuro: {valorDeEntrada.ToString("C")}" +
   $"\nTaxa de Juros : {taxaJuros}%" +
   $"\nPeriodo : {periodo}" +
   $"\nValor Inicial : {valorInicial.ToString("C")}\n");

}

#pragma warning restore CS8604 // Possível argumento de referência nula.