// Conversões implícitas

// int >> long
int intValor1 = 10;
long lngValor1 = intValor1;

// int >> float
int intValor2 = 10;
float fltValor2 = intValor2;

// float >> double
float fltValor3 = 10.5f;
double dblValor3 = fltValor3;

// ===================================
// === Conversões explícitas =========
// ===================================

// long >> int
long lngValor4 = 412;
int intValor4 = (int)lngValor4;

// float >> int
float fltValor5 = 1124.10f;
int intValor5 = (int) fltValor5;

// string >> int
string strValor6 = "400";
int intValor6 = Convert.ToInt32(strValor6);

// string >> float
string strValor7 = "250.90";
float fltValor7 = float.Parse(strValor7);

// string >> double
string strValor8 = "509.88";
double dblValor8 = Convert.ToDouble(strValor8);
Console.WriteLine(dblValor8);

// string >> decimal
string strValor9 = "1366.20";
decimal dcmValor9 = Convert.ToDecimal(strValor9);
Console.WriteLine(dcmValor9);;