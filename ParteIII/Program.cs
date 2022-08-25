/*
PROBLEMA 6:	Crie uma Tabela que leia valores da Entrada. Mostre os cálculos para um período de 8 meses e 10 dias e que mostre o Rendimento Futuro:								
Valor Presente Investido:		1000, 5500, 12000   Entradas: 1000, 5500, 12000
Taxa de Juros		3%, 2,48%, 2%	Taxas: 3 %, 2,48 % e 2 %
Número Períodos(mes)       8 meses e 10 dias	Período: 8 meses e 10 dias						
//Ok									
									
PROBLEMA 7:	Dado o enunciado do PROBLEMA 6. Mostre uma Tabela que calcula se houver um Resgate do Rendimento no 5º mês								
									
Valor Presente Investido:		5500
Taxa de Juros		2,48%							
Número Períodos (mes)		8 meses e 10 dias							
Resgate do Rendimento		500							
Saldo Líquido Restante		R$ 5.566,23							
Rendimento Restante		R$ 6.189,62							
//Ok

PROBLEMA8:	Dado o enunciado do PROBLEMA 7. Elabore um programa que leia as entradas e calcule, mostre em um formato de Tabela 								
									
Valor Investido	Taxa de Juros	Rendimento	    Período (a.m.)	    Resgate     Saldo Líquido	
R$ 12.000,00	2,00%	        R$ 13.608,23	8 meses e 10 dias	R$ 500,00	R$ 12.489,19
//Ok
*/

namespace ParteIII
{
    public class Program
    {
#pragma warning disable CS8604 // Possível argumento de referência nula.

        //Propriedades
        private static int TipoPeriodo { get; set; }
        private static int Periodo { get; set; }
        private static int IsResgate { get; set; }
        private static int ResgateAno { get; set; }
        private static int ResgateMes { get; set; }
        private static double ResgateValor { get; set; }
        private static int IsDias { get; set; }
        private static double Dias { get; set; }

        private static double ValorInicial { get; set; }
        private static double ValorAtual { get; set; }
        private static double ValorFuturo { get; set; }
        private static double TaxaJuros { get; set; }

        static void Main(string[] args)
        {
            var isCalcular = true;
            while (isCalcular)
            {
                try
                {
                    Console.WriteLine("\nCALCULANDO JUROS COMPOSTO\n");
                    CalcularValorFuturo();
                    isCalcular = ContinuarCalculando();
                }
                catch
                {
                    Console.WriteLine("Valor invalido, digite somente os números possíveis!!");
                    isCalcular = ContinuarCalculando();
                }
            }
        }

    //Metodos principais

        private static bool ContinuarCalculando()
        {
            Console.Write("\nDeseja calcular mais? 1 para sim e 0 não: ");
            if (int.Parse(Console.ReadLine()) == 1)
                return true;
            else
                return false;
        }
        private static void CalcularValorFuturo()
        {

            //Obtem o valor Inicial e o Atual
            Console.Write("Digite o número do valor presente inicial: ");
            ValorInicial = double.Parse(Console.ReadLine());
            ValorAtual = ValorInicial;
            ValorFuturo = ValorAtual;

            //Obtem a taxa de juros 
            Console.Write("Digite o número da taxa de Juros: ");
            TaxaJuros = double.Parse(Console.ReadLine());

            //Obtem o tipo do período sendo mês ou ano
            Console.Write("Digite o número de período sendo 1 para mês e 0 para ano: ");
            TipoPeriodo = int.Parse(Console.ReadLine());

            //Condição se o período for ano
            if (TipoPeriodo == 0)
            {
                //Obtem a quantidade do período em anos
                Console.Write("Digite o número de Anos: ");
                var anos = int.Parse(Console.ReadLine());
                Periodo = anos;

                //Descubre se vai ter resgate de rendiemento e o que fazer se tiver
                Console.Write("Tem resgate de rendimento? 1 para sim e 0 para não: ");
                IsResgate = int.Parse(Console.ReadLine());

                if (IsResgate == 1)
                    ConfigurarTabelaAnoResgateRendimento();
                else
                    ConfigurarTabelaAno();
            }
            else if (TipoPeriodo == 1)
            {
                //Se o período for mês, obtem a quantidade do período em mês
                Console.Write("Digite o número de meses: ");
                var meses = int.Parse(Console.ReadLine());
                Periodo = meses;

                //Obtem se vai acresentar dias a mais ou não
                Console.Write("Deseja adicionar dias a mais? 1 para sim e 0 para não: ");
                IsDias = int.Parse(Console.ReadLine());

                if (IsDias == 1)
                {
                    //Obtem o quantidade de dias a ser adicionado e verifica se é valido
                    Console.Write("Qual o número de dias quer adicionar? sendo maior de 0 e menor que 30: ");
                    Dias = double.Parse(Console.ReadLine());
                    if (Dias < 1 || Dias > 30)
                        throw new Exception();

                    //Descubre se vai ter resgate de rendiemento e o que fazer se tiver
                    Console.Write("Tem resgate de rendimento? 1 para sim e 0 para não: ");
                    IsResgate = int.Parse(Console.ReadLine());

                    if (IsResgate == 1)
                    {
                        ConfigurarTabelaMesResgateRendimento();
                        CalcularDias();
                    }
                    else
                    {
                        ConfigurarTabelaMes();
                        CalcularDias();
                    }
                }
                else
                {
                    //Se não houver dias a mais, descubre se tem resgate de rendimento e o que faz se tiver
                    Console.Write("Tem resgate de rendimento? 1 para sim e 0 para não: ");
                    IsResgate = int.Parse(Console.ReadLine());

                    if (IsResgate == 1)
                        ConfigurarTabelaMesResgateRendimento();
                    else
                        ConfigurarTabelaMes();
                }
            }
            else
            {
                //Caso o usúario não tenho informado um valor valido entre as opções
                Console.WriteLine("Digite apenas 1 para mês e 0 para ano");
                throw new Exception();
            }
            //Chamo o metodo para mostrar o resultado resumido
            ResultadoResumido();
        }


    //Metodos de auxilio ao CalcularValorFuturo()

        private static void ConfigurarTabelaAnoResgateRendimento()
        {
            //Obtem o período que vai haver o resgate e verifica se é valido
            Console.Write($"Qual ano entre 1 e {Periodo} será o resgate? número: ");
            ResgateAno = int.Parse(Console.ReadLine());
            if (ResgateAno < 1 || ResgateAno > Periodo)
                throw new Exception();

            //Começa a escrever a tabela sendo as colunas Anos, Valor com juros e Resgate de rendimento
            Console.WriteLine("\nAnos   |    Valor com juros    |    Resgate de rendimento");

            //Percorre todo o período de anos
            for (var i = 1; i <= Periodo; i++)
            {
                //Se o período do ano for diferente do ano de resgate
                if (i != ResgateAno)
                {
                    //Percorre todos os meses de um ano
                    for (var j = 1; j <= 12; j++)
                    {
                        //Calcula o valor futuro de acordo com o juros e redefine o valor atual
                        ValorFuturo *= (1 + (TaxaJuros / 100));
                        ValorAtual = ValorFuturo;
                    }
                    //Escreve os valores das colunas sendo o período do ano, valor futuro e o valor de resgate
                    Console.WriteLine($"{i}           {ValorFuturo.ToString("C")}             {0.ToString("C")}");
                }
                else
                {
                    //Obtem o valor de resgate do rendimento e verifica se é valido
                    Console.WriteLine("\n------------------------------------------------------------------------");
                    Console.WriteLine("Chegou o ano do resgate!!!");
                    Console.Write($"Informe o valor sendo ele maior que 0 e menor que {ValorAtual.ToString("C")}: ");
                    ResgateValor = double.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------\n");
                    if (ResgateValor < 1 || ResgateValor > ValorAtual)
                        throw new Exception();

                    //Faz o resgate de rendimento do valor atual
                    ValorFuturo -= ResgateValor;

                    //Percorre todos os meses de um ano
                    for (var j = 1; j <= 12; j++)
                    {
                        //Calcula o valor futuro de acordo com o juros e redefine o valor atual
                        ValorFuturo *= 1 + (TaxaJuros / 100);
                        ValorAtual = ValorFuturo;
                    }
                    //Escreve os valores das colunas sendo o período do ano, valor futuro e o valor de resgate
                    Console.WriteLine($"{i}           {ValorFuturo.ToString("C")}             {ResgateValor.ToString("C")}");
                }
            }
        }
        private static void ConfigurarTabelaAno()
        {
            //Começa a escrever a tabela sendo as colunas Anos e Valor com juros
            Console.WriteLine("\nAnos   |    Valor com juros");

            //Percorre todo o período de anos
            for (int i = 1; i <= Periodo; i++)
            {
                //Percorre todos os meses de um ano
                for (var j = 1; j <= 12; j++)
                {
                    //Calcula o valor futuro de acordo com o juros e redefine o valor atual
                    ValorFuturo *= 1 + (TaxaJuros / 100);
                    ValorAtual = ValorFuturo;
                }
                //Escreve os valores das colunas sendo o período do ano e valor futuro
                Console.WriteLine($"{i}           {ValorFuturo.ToString("C")}");
            }
        }
        private static void CalcularDias()
        {
            //Calcula o valor futuro de acordo com o juros e com os dias
            ValorFuturo *= Math.Pow(1 + (TaxaJuros / 100), Dias / 30);

            Console.WriteLine("\n------------------------------------------------------------------------");
            Console.WriteLine($"Valor {ValorAtual.ToString("C")} com mais os {Dias} dias de juros: {ValorFuturo.ToString("C")}");
            Console.WriteLine("------------------------------------------------------------------------");

            //Redefine o valor atual
            ValorAtual = ValorFuturo;
        }
        private static void ConfigurarTabelaMesResgateRendimento()
        {
            //Obtem o período que vai haver o resgate e verifica se é valido
            Console.Write($"Qual mês entre 1 e {Periodo} será o resgate? número: ");
            ResgateMes = int.Parse(Console.ReadLine());
            if (ResgateMes < 1 || ResgateMes > Periodo)
                throw new Exception();

            //Começa a escrever a tabela sendo as colunas Mês, Valor com juros e Resgate de rendimento
            Console.WriteLine("\nMês    |    Valor com juros    |    Resgate de rendimento");

            //Percorre todo o período de meses
            for (var i = 1; i <= Periodo; i++)
            {
                //Se o período do mês for diferente do mês de resgate
                if (i != ResgateMes)
                {
                    //Calcula o valor futuro de acordo com o juros, escreve os valores de mês, valor futuro e valor de resgate na tabela e redefine o valor atual
                    ValorFuturo *= 1 + (TaxaJuros / 100);
                    Console.WriteLine($"{i}           {ValorFuturo.ToString("C")}             {0.ToString("C")}");
                    ValorAtual = ValorFuturo;
                }
                else
                {
                    //Obtem o valor de resgate do rendimento e verifica se é valido
                    Console.WriteLine("\n------------------------------------------------------------------------");
                    Console.WriteLine("Chegou o mês do resgate!!!");
                    Console.Write($"Informe o valor sendo ele maior que 0 e menor que {ValorAtual.ToString("C")}: ");
                    ResgateValor = double.Parse(Console.ReadLine());
                    Console.WriteLine("------------------------------------------------------------------------\n");
                    if (ResgateValor < 1 || ResgateValor > ValorAtual)
                        throw new Exception();

                    //Faz o resgate de rendimento do valor atual
                    ValorFuturo -= ResgateValor;

                    //Calcula o valor futuro de acordo com o juros, escreve os valores de mês, valor futuro e valor de resgate na tabela e redefine o valor atual
                    ValorFuturo *= 1 + (TaxaJuros / 100);
                    Console.WriteLine($"{i}           {ValorFuturo.ToString("C")}             {ResgateValor.ToString("C")}");
                    ValorAtual = ValorFuturo;
                }
            }
        }
        private static void ConfigurarTabelaMes()
        {
            //Começa a escrever a tabela sendo as colunas Mês, Valor com juros
            Console.WriteLine("\nMês    |    Valor com juros");

            //Percorre todo o período de meses
            for (var i = 1; i <= Periodo; i++)
            {
                //Calcula o valor futuro de acordo com o juros, escreve os valores de mês e valor futuro na tabela e redefine o valor atual
                ValorFuturo *= (1 + (TaxaJuros / 100));
                Console.WriteLine($"{i}           {ValorFuturo.ToString("C")}");
                ValorAtual = ValorFuturo;
            }
        }
        private static void ResultadoResumido()
        {
            //Configura o texto de periodoFormatado
            var periodoFormatado = "";
            if (TipoPeriodo == 1)
                if (IsDias == 1)
                    periodoFormatado = $"{Periodo} Meses e {Dias} dias";
                else
                    periodoFormatado = $"{Periodo} Meses";
            else
                periodoFormatado = $"{Periodo} anos";

            //Configura o texto de resgateFormatado
            var resgateFormatado = "0";
            if (IsResgate == 1)
                if (TipoPeriodo == 1)
                    resgateFormatado = $"Mês {ResgateMes}  -  Valor de resgate {ResgateValor.ToString("C")}";
                else
                    resgateFormatado = $"Ano {ResgateAno}  -  Valor de resgate {ResgateValor.ToString("C")}";

            //Escreve o resultado de forma resumida com detalhes das informações
            Console.WriteLine($"\nRESULTADO APÓS JUROS\n" +
           $"\nValor Presente: {ValorInicial.ToString("C")}" +
           $"\nTaxa de Juros : {TaxaJuros}%" +
           $"\nPeriodo : {periodoFormatado}" +
           $"\nResgate de rendimento : {resgateFormatado}" +
           $"\nValor Futuro : {ValorFuturo.ToString("C")}\n");
        }

#pragma warning restore CS8604 // Possível argumento de referência nula.
    }
}