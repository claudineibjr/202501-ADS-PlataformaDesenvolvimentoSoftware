using System.Globalization;

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
 - Parcela mensal: {parcelaMensal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}
 - Valor total pago: {valorPago.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))} | Valor a pagar: {valorAPagar.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}
 - Valor total: {valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}
 - Progresso: {numParcelasPagas} / {numParcelas} ({percentualPago:f2}%) de parcelas pagas - {numParcelasAPagar} parcelas a pagar";

Console.WriteLine(mensagem);