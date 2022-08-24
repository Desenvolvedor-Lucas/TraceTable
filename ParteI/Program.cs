//Trace Table parte 1

//ex
//int[] v = new int[6];
//int a = 2;

//while(a < 6)
//{
//    v[a] = 10 * a;
//    a++;
//}
//for (int i = 2; i < 6; i++)
//    Console.WriteLine($"No vetor {i} o resultado é {v[i]}");


int[] v = new int[6];
var a = 7;
var b = a - 6;
while (b < a)
{
    v[b] = b + a;
    b = b + 2;
}

for (var i = 0; i < 6; i++)
    Console.WriteLine($"i({i}) v({v[i]})");