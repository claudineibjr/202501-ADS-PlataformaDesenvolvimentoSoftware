using System;
using S11ProjetoPedidos.Database;

namespace S11ProjetoPedidos.Services;

public class DatabaseService
{
  public static PedidosManagerDbContext db = new PedidosManagerDbContext();
}
