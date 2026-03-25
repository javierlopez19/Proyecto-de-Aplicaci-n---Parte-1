using System;

namespace Proyecto1_Parte2
{
    class Program
    {
        static void Main(string[] args)
        {
          

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(" SMARTPARK - REGISTRO INICIAL ");

            Console.ResetColor();

            string nombreOperador = "";
            do
            {
                Console.Write("Nombre del operador: ");
                nombreOperador = Console.ReadLine().Trim();
                if (nombreOperador == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El nombre no puede estar vacío.");
                    Console.ResetColor();
                }
            } while (nombreOperador == "");


            string codigoTurno = "";
            do
            {
                Console.Write("Código de turno (exactamente 4 caracteres): ");
                codigoTurno = Console.ReadLine();
                if (codigoTurno.Length != 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: El código debe tener exactamente 4 caracteres.");
                    Console.ResetColor();
                }
            } while (codigoTurno.Length != 4);


            int capacidadParqueo = 0;
            do
            {
                Console.Write("Capacidad del parqueo (mínimo 10): ");
                if (!int.TryParse(Console.ReadLine(), out capacidadParqueo) || capacidadParqueo < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: La capacidad debe ser un número entero mayor o igual a 10.");
                    Console.ResetColor();
                    capacidadParqueo = 0;
                }
            } while (capacidadParqueo < 10);

            
            int ticketsCreados = 0;       
            int ticketsCerrados = 0;       
            double dineroRecaudado = 0.0;   
            int tiempoSimulado = 0;       

            
            bool hayTicketActivo = false;  
            string clienteActual = "";     
            string placaActual = "";     
            int tipoVehiculoActual = 0;      
            int minutoEntradaActual = 0;     
            bool esVipActual = false;  

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Sistema inicializado correctamente.");
            Console.WriteLine($"  Operador : {nombreOperador}");
            Console.WriteLine($"  Turno    : {codigoTurno}");
            Console.WriteLine($"  Capacidad: {capacidadParqueo} espacios");
            Console.ResetColor();

            

            int opcion = 0;

            while (opcion != 5)
            {
                
                int espaciosOcupados = hayTicketActivo ? 1 : 0;
                int espaciosDisponibles = capacidadParqueo - espaciosOcupados;

               
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine(" SMARTPARK - MENÚ ");

                Console.WriteLine(" 1. Crear ticket de entrada ");
                Console.WriteLine(" 2. Registrar salida y cobro ");
                Console.WriteLine(" 3. Ver estado del parqueo ");
                Console.WriteLine(" 4. Simular paso del tiempo ");
                Console.WriteLine(" 5. Salir ");

                Console.ResetColor();

                Console.Write("Seleccione una opción (1-5): ");

               
                if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Opción inválida. Ingrese un número del 1 al 5.");
                    Console.ResetColor();
                    opcion = 0;
                    continue;
                }



                if (opcion == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n CREAR TICKET DE ENTRADA ");
                    Console.ResetColor();

                 
                    if (hayTicketActivo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Ya existe un ticket activo. Registre la salida antes de crear uno nuevo.");
                        Console.ResetColor();
                        continue;
                    }

                    
                    if (espaciosOcupados >= capacidadParqueo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: El parqueo está lleno. No se pueden registrar más vehículos.");
                        Console.ResetColor();
                        continue;
                    }

                   
                    bool placaValida = false;
                    do
                    {
                        Console.Write("Número de placa (6-8 caracteres, sin espacios): ");
                        placaActual = Console.ReadLine().Trim().ToUpper();
                        placaValida = true;

                        if (placaActual.Length < 6 || placaActual.Length > 8)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: La placa debe tener entre 6 y 8 caracteres.");
                            Console.ResetColor();
                            placaValida = false;
                        }
                        else if (placaActual.Contains(" "))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: La placa no puede contener espacios.");
                            Console.ResetColor();
                            placaValida = false;
                        }
                    } while (!placaValida);

                   
                    do
                    {
                        Console.Write("Tipo de vehículo (1. Moto, 2. Auto, 3. Pickup/SUV: ");
                        if (!int.TryParse(Console.ReadLine(), out tipoVehiculoActual) ||
                            tipoVehiculoActual < 1 || tipoVehiculoActual > 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Seleccione 1. Moto, 2. Auto o 3. Pickup/SUV ");
                            Console.ResetColor();
                            tipoVehiculoActual = 0;
                        }
                    } while (tipoVehiculoActual < 1 || tipoVehiculoActual > 3);

                    
                    do
                    {
                        Console.Write("Nombre del cliente: ");
                        clienteActual = Console.ReadLine().Trim();
                        if (clienteActual == "")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: El nombre del cliente no puede estar vacío.");
                            Console.ResetColor();
                        }
                    } while (clienteActual == "");

                   
                    string respuestaVip = "";
                    do
                    {
                        Console.Write("¿Es cliente VIP? (si/no): ");
                        respuestaVip = Console.ReadLine().Trim().ToLower();
                        if (respuestaVip != "si" && respuestaVip != "no")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Ingrese 'si' o 'no' ");
                            Console.ResetColor();
                        }
                    } while (respuestaVip != "si" && respuestaVip != "no");
                    esVipActual = (respuestaVip == "si");

                 
                    minutoEntradaActual = tiempoSimulado;   
                    hayTicketActivo = true;              
                    ticketsCreados++;                        

                   
                    string tipoNombreEntrada = (tipoVehiculoActual == 1) ? "Moto" :
                                              (tipoVehiculoActual == 2) ? "Auto" : "Pickup/SUV";

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Ticket creado exitosamente.");
                    Console.WriteLine($"  Cliente   : {clienteActual}");
                    Console.WriteLine($"  Placa     : {placaActual}");
                    Console.WriteLine($"  Vehículo  : {tipoNombreEntrada}");
                    Console.WriteLine($"  VIP       : {(esVipActual ? "Sí" : "No")}");
                    Console.WriteLine($"  Min. entrada: {minutoEntradaActual}");
                    Console.ResetColor();
                }

               
                else if (opcion == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n REGISTRAR SALIDA Y COBRO ");
                    Console.ResetColor();

                    
                    if (!hayTicketActivo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: No existe ningún ticket activo en este momento.");
                        Console.ResetColor();
                        continue;
                    }

                    
                    int minutosEstacionados = tiempoSimulado - minutoEntradaActual;
                    if (minutosEstacionados < 0) minutosEstacionados = 0;

                  
                    double tarifaHora = (tipoVehiculoActual == 1) ? 5.0 :
                                        (tipoVehiculoActual == 2) ? 10.0 : 15.0;

                    string tipoNombreSalida = (tipoVehiculoActual == 1) ? "Moto" :
                                             (tipoVehiculoActual == 2) ? "Auto" : "Pickup/SUV";

                    double monto = 0.0;
                    double descuento = 0.0;
                    string notaCobro = "";

                   
                    if (minutosEstacionados <= 15)
                    {
                        monto = 0.0;
                        notaCobro = "Gratuito por haber estado menos de 25 minutos";
                    }
                    else
                    {
                        
                        int horasFraccion = minutosEstacionados / 60;
                        if (minutosEstacionados % 60 > 0) horasFraccion++;

                        monto = horasFraccion * tarifaHora;
                        notaCobro = $"{horasFraccion} hora(s) x Q{tarifaHora:F2}/h";

                       
                        if (horasFraccion > 6)
                        {
                            monto += 25.0;
                            notaCobro += " + Multa Q25.00 (mas de 6h)";
                        }
                    }

                    
                    if (esVipActual && monto > 0)
                    {
                        descuento = monto * 0.10;
                        monto -= descuento;
                    }

                    
                    dineroRecaudado += monto;
                    ticketsCerrados++;
                    hayTicketActivo = false;

                 
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine(" RECIBO DE PAGO ");
               
                    Console.WriteLine($"  Cliente    : {clienteActual}");
                    Console.WriteLine($"  Placa      : {placaActual}");
                    Console.WriteLine($"  Vehículo   : {tipoNombreSalida}");
                    Console.WriteLine($"  Min. entrada: {minutoEntradaActual}");
                    Console.WriteLine($"  Min. salida : {tiempoSimulado}");
                    Console.WriteLine($"  Tiempo      : {minutosEstacionados} minutos");
                    Console.WriteLine($"  Cobro       : {notaCobro}");
                    if (esVipActual && descuento > 0)
                        Console.WriteLine($"  Descuento VIP (10%): -Q{descuento:F2}");
                    Console.WriteLine($"  TOTAL A PAGAR: Q{monto:F2}");
                    Console.ResetColor();
                }

           
                else if (opcion == 3)
                {
                 
                    int ocupados2 = hayTicketActivo ? 1 : 0;
                    int disponibles2 = capacidadParqueo - ocupados2;

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine(" ESTADO DEL PARQUEO ");
            
                    Console.ResetColor();
                    Console.WriteLine($"  Capacidad total    : {capacidadParqueo} espacios");
                    Console.WriteLine($"  Espacios ocupados  : {ocupados2}");
                    Console.WriteLine($"  Espacios disponibles: {disponibles2}");
                    Console.WriteLine($"  Tiempo simulado    : {tiempoSimulado} minutos");
                    Console.WriteLine($"  Total recaudado    : Q{dineroRecaudado:F2}");
                    Console.WriteLine($"  Tickets creados    : {ticketsCreados}");
                    Console.WriteLine($"  Tickets cerrados   : {ticketsCerrados}");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ResetColor();
                }

           
                else if (opcion == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n SIMULAR PASO DEL TIEMPO ");
                    Console.ResetColor();


                    int minutosSimular = 0;
                    do
                    {
                        Console.Write("Minutos a simular (1-1440): ");
                        if (!int.TryParse(Console.ReadLine(), out minutosSimular) ||
                            minutosSimular < 1 || minutosSimular > 1440)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: Ingrese un valor entero entre 1 y 1440.");
                            Console.ResetColor();
                            minutosSimular = 0;
                        }
                    } while (minutosSimular < 1 || minutosSimular > 1440);

                 
                    tiempoSimulado += minutosSimular;

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" Se avanzaron {minutosSimular} minuto(s).");
                    Console.WriteLine($"  Tiempo acumulado del sistema: {tiempoSimulado} minutos.");
                    Console.ResetColor();
                }

          
                else if (opcion == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine(" RESUMEN FINAL DEL TURNO ");
          
                    Console.ResetColor();
                    Console.WriteLine($"  Operador          : {nombreOperador}");
                    Console.WriteLine($"  Código de turno   : {codigoTurno}");
                    Console.WriteLine($"  Tiempo simulado   : {tiempoSimulado} minutos");
                    Console.WriteLine($"  Tickets creados   : {ticketsCreados}");
                    Console.WriteLine($"  Tickets cerrados  : {ticketsCerrados}");
                    Console.WriteLine($"  Total recaudado   : Q{dineroRecaudado:F2}");
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine(" Gracias por usar SmartPark ");
              
                    Console.ResetColor();
                }

            } 

        } 
    } 
} 