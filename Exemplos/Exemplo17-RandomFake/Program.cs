Random random = new Random(0);

int num1 = random.Next();
int num2 = random.Next(10);
int num3 = random.Next(10, 22);

Console.WriteLine($@"Num 1: {num1}
Num 2: {num2}
Num 3: {num3}");