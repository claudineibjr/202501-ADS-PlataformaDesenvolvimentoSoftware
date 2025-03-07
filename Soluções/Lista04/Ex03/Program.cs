/*3. (Exibição do nome de trás para frente) Implemente um programa
que leia o nome do usuário e exiba este nome escrito de trás para
frente.*/

string nome = Console.ReadLine();

for (int iCount = nome.Length -1; iCount >= 0; iCount--)
{
    Console.Write(nome[iCount]);
}