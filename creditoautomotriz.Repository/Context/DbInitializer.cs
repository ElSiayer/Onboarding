using creditoautomotriz.Entity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditoautomotriz.Repository.Context
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext applicationBuilder)
        {
            AppDbContext context = applicationBuilder;
            //Carga inicial de estado civil
            if (!context.EstadoCivil.Any())
            {

                List<EstadoCivil> estados = new List<EstadoCivil>{ new EstadoCivil("Soltero"), new EstadoCivil("Casado") ,
                    new EstadoCivil("Union Libre") , new EstadoCivil("Divorciado"), new EstadoCivil("Viudo") };

                context.EstadoCivil.AddRange(estados);
            }
            context.SaveChanges();
            //Carga inicial de marca
            if (!context.Marca.Any())
            {

                List<Marca> marcas = new List<Marca>();
                StreamReader reader = new StreamReader(File.OpenRead(@"..\creditoautomotriz.Repository\Datos\Marcas.csv"));
                List<string> nombres = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (!nombres.Contains(values[0]))
                    {
                        nombres.Add(values[0]);
                        marcas.Add(new Marca(values[0]));
                    }
                    else
                    {
                        Console.WriteLine($"La Marca {values[0]} ya esta registrada.");
                        //throw new FileNotFoundException(@"[data.txt not in c:\temp directory]", e);
                    }
                }
                reader.Close();
                context.Marca.AddRange(marcas);
            }

            context.SaveChanges();

            if (!context.EstadoCredito.Any())
            {

                List<EstadoCredito> estados = new List<EstadoCredito>{ new EstadoCredito("Registrada"), new EstadoCredito("Despachada") ,
                    new EstadoCredito("Cancelada")};

                context.EstadoCredito.AddRange(estados);
            }
            context.SaveChanges();

            if (!context.Patio.Any())
            {

                List<Patio> patios = new List<Patio>{ new Patio("Patio Nombre 1","Patio Direccion 1", "0999999991"), new Patio("Patio Nombre 2","Patio Direccion 2", "0999999992") ,
                    new Patio("Patio Nombre 3","Patio Direccion 3", "0999999993")};

                context.Patio.AddRange(patios);
            }
            context.SaveChanges();

            if (!context.Ejecutivo.Any())
            {
                StreamReader reader = new StreamReader(File.OpenRead(@"..\creditoautomotriz.Repository\Datos\Ejecutivos.csv"));
                List<Ejecutivo> ejecutivos = new List<Ejecutivo>();
                List<string> ids = new List<string>();
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (!ids.Contains(values[0]))
                    {
                        Ejecutivo EjecutivoAux = new Ejecutivo();
                        EjecutivoAux.Identificacion = values[0];
                        ids.Add(EjecutivoAux.Identificacion);
                        EjecutivoAux.Nombres = values[1];
                        EjecutivoAux.Apellidos = values[2];
                        EjecutivoAux.Direccion = values[4];
                        EjecutivoAux.Edad = int.Parse(values[3]);
                        EjecutivoAux.TelefonoCon = values[5];
                        EjecutivoAux.Celular = values[6];
                        EjecutivoAux.PatioId = int.Parse(values[7]);
                        ejecutivos.Add(EjecutivoAux);
                    }
                    else
                    {
                        Console.WriteLine($"El ejecutivo con identificacion {values[0]} ya esta registrado.");
                    }
                }
                reader.Close();
                context.Ejecutivo.AddRange(ejecutivos);
                context.SaveChanges();
            }

            if (!context.Cliente.Any())
            {
                StreamReader reader = new StreamReader(File.OpenRead(@"..\creditoautomotriz.Repository\Datos\Clientes.csv"));
                List<Cliente> clientes = new List<Cliente>();
                List<string> ids = new List<string>();
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (!ids.Contains(values[0]))
                    {
                        Cliente clienteAux = new Cliente();
                        clienteAux.Identificacion = values[0];
                        ids.Add(clienteAux.Identificacion);
                        clienteAux.Nombres = values[1];
                        clienteAux.Apellidos = values[2];
                        clienteAux.Edad = int.Parse(values[3]);
                        clienteAux.FechaNacimiento = Convert.ToDateTime(values[4]);
                        clienteAux.Direccion = values[5];
                        clienteAux.Telefono = values[6];
                        clienteAux.EstadoCivilId = int.Parse(values[7]);
                        if (clienteAux.EstadoCivilId == 2)
                        {
                            clienteAux.IdentificacionConyugue = values[8];
                            clienteAux.NombreConyugue = values[9];
                        }
                        clienteAux.SujetoCredito = bool.Parse(values[10]);
                        clientes.Add(clienteAux);
                    }
                    else
                    {
                        Console.WriteLine($"El cliente con identificacion {values[0]} ya esta registrado.");
                    }
                }
                context.Cliente.AddRange(clientes);
                context.SaveChanges();
            }
        }
    }
}
