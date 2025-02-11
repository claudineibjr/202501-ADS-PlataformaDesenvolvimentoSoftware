/* Escreva um programa que receba o valor total de um financiamento, o número
total de parcelas e o número de parcelas já pagas. (nível 4) Com base nisso, informe ao usuário:
Valor da parcela mensal
Valor já pago
Valor a pagar
Valor total do financiamento
Número de parcelas pagas
Número de parcelas a pagar
% já pago
Ordem dos dados de entrada: Valor total do financiamento / Número total de parcelas / Número de parcelas pagas
*/

// Entrada
decimal valorTotal = Convert.ToDecimal(Console.ReadLine());
int numParcelas = Convert.ToInt32(Console.ReadLine());
int numParcelasPagas = Convert.ToInt32(Console.ReadLine());

// Cálculo
decimal parcelaMensal = valorTotal / numParcelas;
decimal valorPago = numParcelasPagas * parcelaMensal;
decimal numParcelasAPagar = numParcelas - numParcelasPagas;
decimal valorAPagar = numParcelasAPagar * parcelaMensal;
decimal percentualPago = (decimal)(numParcelasPagas) / (decimal)(numParcelas) * 100;

string mensagem = @$"Resumo do financiamento
 - Parcela mensal: R$ {parcelaMensal:f2}
 - Valor total pago: R$ {valorPago:f2} | Valor a pagar: R$ {valorAPagar:f2}
 - Valor total: R$ {valorTotal:f2}
 - Progresso: {numParcelasPagas} / {numParcelas} ({percentualPago:f2}%) de parcelas pagas - {numParcelasAPagar} parcelas a pagar";

Console.WriteLine(mensagem);