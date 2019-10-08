using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;

namespace Proyecto2
{
    //***Utiliza el nuget ColorFul***
    #region Modelo
    public class Peliculas
    {
        public string Nombre { get; set; }
        public string Sinopsis { get; set; }
        public int Sala { get; set; }
        public List<string> Horarios { get; set; }

    }
    #endregion
    class Program
    {
        private static Peliculas seleccionsala;
        public static List<Peliculas> Pelicula { get; set; }
        static bool[,,] asientos = new bool[10, 10, 12]; //matriz para asientos y salas
        static int[,] datos = new int[3, 12];//datos de voleto por horario
     
        static int BoletoA = 0, BoletoN = 0, BoletoAM = 0;
        static int opcion;

        #region Constructor
        static Program()
        {
            Pelicula = new List<Peliculas>
            {
                new Peliculas {Nombre = "Eso: capitulo 2", Sala = 1, Sinopsis = "En el misterioso pueblo de Derry, un malvado payaso\nllamado Pennywise vuelve 27 años después para atormentar\na los ya adultos miembros del Club de los Perdedores\nque ahora están más alejados unos de otros.", Horarios = new List<string> {"19:00", "21:30", "00:30" } },
                new Peliculas {Nombre = "Dora y la ciudad perdida", Sala = 2, Sinopsis = "Dora se pone al frente de un equipo formado por su amigo\npeludo Botas; Diego habitante de la jungla; y un\ndesorganizado grupo de adolescentes en una aventura\nen la que deberán salvar a los padres de Dora y resolver\nel misterio oculto tras una ciudad perdida de oro.", Horarios = new List<string> {"10:45", "13:20", "15:25" } },
                new Peliculas {Nombre = "Avengers: End Game", Sala = 3, Sinopsis= "Los Vengadores restantes deben encontrar una manera\nde recuperar a sus aliados para un enfrentamiento épico\ncon Thanos, el malvado que diezmó el planeta y\nel universo..", Horarios = new List<string> {"12:55", "15:25", "17:25" } },
                new Peliculas {Nombre = "El rey leon", Sala = 4, Sinopsis = "Se desarrolla en la sabana africana donde ha nacido el\nfuturo rey, Simba, quien idolatra a su padre, Mufasa,\ny se toma muy en serio su propio destino. Scar,\nel hermano de Mufasa y antiguo heredero al trono.", Horarios = new List<string> {"10:25", "19:30", "22:00" } },
            };
        }
        #endregion

        #region Cartelera
        public static void ImprimirMenu()
        {
            int x = 0, y = 0;

            foreach (var item in Pelicula)
            {
                if (item.Sala == 1)
                {
                    x = 5;
                    y = 14;
                    Console.SetCursorPosition(21, 8);
                    Console.WriteLine(item.Nombre, ColorTranslator.FromHtml("#FF0000"));
                    Console.SetCursorPosition(3, 8);
                    Console.WriteLine($"Sala {item.Sala}", ColorTranslator.FromHtml("#FFFFFF"));
                    Console.SetCursorPosition(3, 11);
                    Console.WriteLine("Horarios", ColorTranslator.FromHtml("#FFFFFF"));
                }
                if (item.Sala == 2)
                {
                    x = 53;
                    y = 14;
                    Console.SetCursorPosition(65, 8);
                    Console.WriteLine(item.Nombre, ColorTranslator.FromHtml("#FF4081"));
                    Console.SetCursorPosition(51, 8);
                    Console.WriteLine($"Sala {item.Sala}", ColorTranslator.FromHtml("#FFFFFF"));
                    Console.SetCursorPosition(51, 11);
                    Console.WriteLine("Horarios", ColorTranslator.FromHtml("#FFFFFF"));
                }
                if (item.Sala == 3)
                {
                    x = 5;
                    y = 24;
                    Console.SetCursorPosition(21, 18);
                    Console.WriteLine(item.Nombre, ColorTranslator.FromHtml("#7C4DFF"));
                    Console.SetCursorPosition(3, 18);
                    Console.WriteLine($"Sala {item.Sala}", ColorTranslator.FromHtml("#FFFFFF"));
                    Console.SetCursorPosition(3, 21);
                    Console.WriteLine("Horarios", ColorTranslator.FromHtml("#FFFFFF"));
                }
                if (item.Sala == 4)
                {
                    x = 53;
                    y = 24;
                    Console.SetCursorPosition(72, 18);
                    Console.WriteLine(item.Nombre, ColorTranslator.FromHtml("#FFC107"));
                    Console.SetCursorPosition(51, 18);
                    Console.WriteLine($"Sala {item.Sala}", ColorTranslator.FromHtml("#FFFFFF"));
                    Console.SetCursorPosition(51, 21);
                    Console.WriteLine("Horarios", ColorTranslator.FromHtml("#FFFFFF"));
                }
                foreach (var horario in item.Horarios)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(horario, ColorTranslator.FromHtml("#FFFFFF"));
                    x += 15;
                }
            }
        }
        #endregion

        #region DibujoCartelera

        public static void Salas()
        {

            Console.WriteAscii("Cartelera", ColorTranslator.FromHtml("#F0FF01"));
            Console.ForegroundColor = ColorTranslator.FromHtml("#F0FF01");
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║ ╔══════╗         ╔═════════════════╗          ║ ╔══════╗     ╔══════════════════════════╗    ║");
            Console.WriteLine("║ ║      ║         ║                 ║          ║ ║      ║     ║                          ║    ║");
            Console.WriteLine("║ ╚══════╝         ╚═════════════════╝          ║ ╚══════╝     ╚══════════════════════════╝    ║");
            Console.WriteLine("║ ╔════════╗                                    ║ ╔════════╗                                   ║");
            Console.WriteLine("║ ║        ║                                    ║ ║        ║                                   ║");
            Console.WriteLine("║ ╚════════╝                                    ║ ╚════════╝                                   ║");
            Console.WriteLine("║  ╔═══════╗      ╔═══════╗      ╔═══════╗      ║  ╔═══════╗      ╔═══════╗      ╔═══════╗     ║");
            Console.WriteLine("║  ║       ║      ║       ║      ║       ║      ║  ║       ║      ║       ║      ║       ║     ║");
            Console.WriteLine("║  ╚═══════╝      ╚═══════╝      ╚═══════╝      ║  ╚═══════╝      ╚═══════╝      ╚═══════╝     ║");
            Console.WriteLine("║══════════════════════════════════════════════════════════════════════════════════════════════║");
            Console.WriteLine("║ ╔══════╗         ╔════════════════════╗       ║ ╔══════╗           ╔═══════════════╗         ║");
            Console.WriteLine("║ ║      ║         ║                    ║       ║ ║      ║           ║               ║         ║");
            Console.WriteLine("║ ╚══════╝         ╚════════════════════╝       ║ ╚══════╝           ╚═══════════════╝         ║");
            Console.WriteLine("║ ╔════════╗                                    ║ ╔════════╗                                   ║");
            Console.WriteLine("║ ║        ║                                    ║ ║        ║                                   ║");
            Console.WriteLine("║ ╚════════╝                                    ║ ╚════════╝                                   ║");
            Console.WriteLine("║  ╔═══════╗      ╔═══════╗      ╔═══════╗      ║  ╔═══════╗      ╔═══════╗      ╔═══════╗     ║");
            Console.WriteLine("║  ║       ║      ║       ║      ║       ║      ║  ║       ║      ║       ║      ║       ║     ║");
            Console.WriteLine("║  ╚═══════╝      ╚═══════╝      ╚═══════╝      ║  ╚═══════╝      ╚═══════╝      ╚═══════╝     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

        }
        #endregion

        #region SeleccionPeli

        public static void SeleccionPelicula()
        {

            bool condicion;
            do
            {
                Salas();
                ImprimirMenu();
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("Escoja la pelicula que desea ver: ");
                condicion = int.TryParse(Console.ReadLine(), out opcion);
                Console.Clear();
            } while (condicion == false || opcion <= 0 || opcion > 4);

            seleccionsala = Pelicula.Find(sala => sala.Sala == opcion);
            horarios(opcion);
        }
        #endregion

        #region Escojer horarios + info de la peli
        public static void horarios(int opcion = 0, bool condicion = true, int horario = 0)
        {
            do
            {
                Console.Clear();
                if (opcion == 1)
                {
                    Console.WriteAscii(seleccionsala.Nombre, ColorTranslator.FromHtml("#FF0000"));
                    Console.WriteLine("Sinopsis:\n", ColorTranslator.FromHtml("#076DFF"));
                    Console.WriteLine($"{seleccionsala.Sinopsis}", ColorTranslator.FromHtml("#FFFFFF"));
                    ImprimirHorario();
                    swHorario(0, 1, 2);
                }
                else if (opcion == 2)
                {
                    Console.WriteAscii(seleccionsala.Nombre, ColorTranslator.FromHtml("#FF4081"));
                    Console.WriteLine("Sinopsis:\n", ColorTranslator.FromHtml("#076DFF"));
                    Console.WriteLine($"{seleccionsala.Sinopsis}", ColorTranslator.FromHtml("#FFFFFF"));
                    ImprimirHorario();
                    swHorario(3, 4, 5);
                }
                else if (opcion == 3)
                {
                    Console.WriteAscii(seleccionsala.Nombre, ColorTranslator.FromHtml("#7C4DFF"));
                    Console.WriteLine("Sinopsis:\n", ColorTranslator.FromHtml("#076DFF"));
                    Console.WriteLine($"{seleccionsala.Sinopsis}", ColorTranslator.FromHtml("#FFFFFF"));
                    ImprimirHorario();
                    swHorario(6, 7, 8);
                }
                else if (opcion == 4)
                {
                    Console.WriteAscii(seleccionsala.Nombre, ColorTranslator.FromHtml("#FFC107"));
                    Console.WriteLine("Sinopsis:\n", ColorTranslator.FromHtml("#076DFF"));
                    Console.WriteLine($"{seleccionsala.Sinopsis}", ColorTranslator.FromHtml("#FFFFFF"));
                    ImprimirHorario();
                    swHorario(9, 10, 11);
                }
            } while (condicion == false || horario <= 0 || horario > 3);

        }

        static void ImprimirHorario()
        {
            Console.WriteLine("\nHorarios:\n", ColorTranslator.FromHtml("#076DFF"));
            Console.ResetColor();

            for (int i = 0; i < seleccionsala.Horarios.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {seleccionsala.Horarios[i]}", ColorTranslator.FromHtml("#FFFFFF"));
            }
        }
        #endregion

        static void MenuPrincipal()
        {
            int op;
            bool condicion;
            do
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("     1- Comprar boletos");
                Console.WriteLine("     2- Ver estadísticas");
                Console.WriteLine("     3- Limpiar datos");
                Console.WriteLine("     4- Salir");
                Console.WriteLine("===============================");
                Console.WriteLine("Seleccione una opción: ");
                condicion = int.TryParse(Console.ReadLine(), out op);
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        SeleccionPelicula();
                        break;
                    case 2:
                        Console.Clear();
                        contraseña(op);
                        break;
                    case 3:
                        Console.Clear();
                        contraseña(op);
                        break;
                    case 4:
                        Environment.Exit(4);
                        break;
                }

            } while (condicion == false || op < 1 || op > 4);
        }
        static void Main(string[] args)
        {
            //llenado matriz
            #region
            for (int a = 0; a < asientos.GetLength(2); a++)
            {


                for (int i = 0; i < asientos.GetLength(1); i++)//llenado de asientos todos estan en false 
                {
                    for (int j = 0; j < asientos.GetLength(0); j++)
                    {
                        asientos[j, i, a] = false;
                    }
                }
            }
            #endregion
            MenuPrincipal();
        }
        //Validacion
        #region
        static int validaciones(string men, int lim1, int lim2)
        {
            bool esInt;
            int nOP;
            do
            {
                Console.WriteLine(men);
                esInt = int.TryParse(Console.ReadLine(), out nOP);
            } while (esInt == false || nOP < lim1 || nOP > lim2);
            return nOP;
        }
        #endregion

        #region seleccion horario

        static void swHorario(int a, int b, int c)
        {
            switch (validaciones("Escoja el horario: ", 1, 3))
            {
                case 1:
                    swEdadBoleto(a);
                    break;
                case 2:
                    swEdadBoleto(b);
                    break;
                case 3:
                    swEdadBoleto(c);
                    break;
                default:
                    break;
            }
        }
        #endregion 
        #region Estadisticas globales (no abrir)
        public static void totalGlobal()
        {
            decimal ingresoBN = ((datos[0, 0] + datos[0, 1] + datos[0, 2] + datos[0, 3] + datos[0, 4] + datos[0, 5] + datos[0, 6] + datos[0, 7] + datos[0, 8] + datos[0, 9] + datos[0, 10] + datos[0, 11]) * 2.25M);
            decimal ingresoBA = ((datos[1, 0] + datos[1, 1] + datos[1, 2] + datos[1, 3] + datos[1, 4] + datos[1, 5] + datos[1, 6] + datos[1, 7] + datos[1, 8] + datos[1, 9] + datos[1, 10] + datos[1, 11]) * 4.25M);
            decimal ingresoBAM = ((datos[2, 0] + datos[2, 1] + datos[2, 2] + datos[2, 3] + datos[2, 4] + datos[2, 5] + datos[2, 6] + datos[2, 7] + datos[2, 8] + datos[2, 9] + datos[2, 10] + datos[2, 11]) * 3.25M);
            decimal totalG = ingresoBA + ingresoBAM + ingresoBN;
            Console.WriteLine("\t *** DATOS GLOBALES ***");
            Console.WriteLine("Total de ingresos Boletos Niño: \t" + ingresoBN);
            Console.WriteLine("Total de ingresos Boletos Adulto: \t" + ingresoBA);
            Console.WriteLine("Total de ingresos Boletos AdultoMayor: \t" + ingresoBA);
            Console.WriteLine("\nTotal de ingresos global: \t" + totalG);
            Console.WriteLine("\nPresione <ENTER> para continuar");
            Console.ReadKey();
        }
        #endregion

        //Seleccion boletos
        #region 
        static void swEdadBoleto(int mCine = 0)
        {
            int cant = 0, cantAsientos, cantprov, c2;
            bool algo = true;
            cantAsientos = asientosDisponibles(mCine);
            c2 = cantAsientos;
            BoletoN = 0;
            BoletoA = 0;
            BoletoAM = 0;

            do
            {

                Console.Clear();
                switch (validaciones("\t*** PRECIOS Y EDADES ***\n* 1 *  Niño. \t\t|$2.25|  \n* 2 * Adulto. \t\t|$4.25| \n* 3 * Adulto Mayor. \t|$3.25| \n* 0 * Selección de asientos", 0, 3))
                {
                    case 1:
                        Console.WriteLine("Asientos disponibles: {0}", c2);
                        cantprov = validaciones("Cantidad Boleto", 1, cantAsientos);
                        cant += cantprov;
                        c2 -= cantprov;
                        datos[0, mCine] = +cantprov;
                        BoletoN = cantprov;
                        break;
                    case 2:
                        Console.WriteLine("Asientos disponibles: {0} ", c2);
                        cantprov = validaciones("Cantidad Boleto", 1, cantAsientos);
                        cant += cantprov;
                        c2 -= cantprov;
                        datos[1, mCine] = +cantprov;
                        BoletoA = cantprov;
                        break;
                    case 3:
                        Console.WriteLine("Asientos disponibles: {0}", c2);
                        cantprov = validaciones("Cantidad Boleto", 1, cantAsientos);
                        cant += cantprov;
                        c2 -= cantprov;
                        datos[2, mCine] = +cantprov;
                        BoletoAM = cantprov;
                        break;
                    default:
                        algo = false;
                        break;
                }
            } while (algo);
            if (cant < 1)
            {
                Console.Clear();
                swEdadBoleto();
            }
            else
            {
                reservar(mCine, cant);
            }
        }


        static void imprimirticket()
        {

            double total = 0;
            seleccionsala = Pelicula.Find(sala => sala.Sala == opcion);
            if (seleccionsala.Sala == 1)
            {
                Console.SetCursorPosition(21, 2);
                Console.WriteLine(seleccionsala.Nombre, ColorTranslator.FromHtml("#FF0000"));
                Console.SetCursorPosition(3, 2);
                Console.WriteLine($"Sala {seleccionsala.Sala}", ColorTranslator.FromHtml("#FFFFFF"));
                total = BoletoN * 2.25;
                total += BoletoA * 4.25;
                total += BoletoAM * 3.25;
                Console.SetCursorPosition(18, 5);
                Console.WriteLine($"Total a pagar: {total.ToString("c2")}");

            }
            if (seleccionsala.Sala == 2)
            {
                Console.SetCursorPosition(21, 2);
                Console.WriteLine(seleccionsala.Nombre, ColorTranslator.FromHtml("#FF4081"));
                Console.SetCursorPosition(3, 2);
                Console.WriteLine($"Sala {seleccionsala.Sala}", ColorTranslator.FromHtml("#FFFFFF"));
                total = BoletoN * 2.25;
                total += BoletoA * 4.25;
                total += BoletoAM * 3.25;
                Console.SetCursorPosition(18, 5);
                Console.WriteLine($"Total a pagar: {total.ToString("c2")}");

            }
            if (seleccionsala.Sala == 3)
            {
                Console.SetCursorPosition(21, 2);
                Console.WriteLine(seleccionsala.Nombre, ColorTranslator.FromHtml("#7C4DFF"));
                Console.SetCursorPosition(3, 2);
                Console.WriteLine($"Sala {seleccionsala.Sala}", ColorTranslator.FromHtml("#FFFFFF"));
                total = BoletoN * 2.25;
                total += BoletoA * 4.25;
                total += BoletoAM * 3.25;
                Console.SetCursorPosition(18, 5);
                Console.WriteLine($"Total a pagar: {total.ToString("c2")}");

            }
            if (seleccionsala.Sala == 4)
            {
                Console.SetCursorPosition(21, 2);
                Console.WriteLine(seleccionsala.Nombre, ColorTranslator.FromHtml("#FFC107"));
                Console.SetCursorPosition(3, 2);
                Console.WriteLine($"Sala {seleccionsala.Sala}", ColorTranslator.FromHtml("#FFFFFF"));
                total = BoletoN * 2.25;
                total += BoletoA * 4.25;
                total += BoletoAM * 3.25;
                Console.SetCursorPosition(18, 5);
                Console.WriteLine($"Total a pagar: {total.ToString("c2")}");

            }
        }
        static void ticket()
        {
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ ╔══════╗     ╔══════════════════════════╗     ║");
            Console.WriteLine("║ ║      ║     ║                          ║     ║");
            Console.WriteLine("║ ╚══════╝     ╚══════════════════════════╝     ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("║                                               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
        }

        #endregion
        //Disponibilidad asientos
        #region
        static int asientosDisponibles(int c)
        {
            int cAsientos = 0;
            for (int i = 0; i < asientos.GetLength(1); i++)
            {
                for (int j = 0; j < asientos.GetLength(0); j++)
                {
                    if (asientos[i, j, c] == false)
                    {
                        cAsientos++;
                    }
                }
            }
            Console.WriteLine("Asientos disponibles: {0} ", cAsientos);
            return cAsientos;
        }
        #endregion
        //Dibujar asientos
        #region
        static void dibujarAsiento(int x, int y, int a, int b, int c)//[x,y]pos de los asientos en pantalla y [a,b] pos de los asientos en la matriz
        {
            int alto = 3, ancho = 5;
            // Console.Clear();
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < alto; i++)
            {

                Console.Write("|");
                if (i == 0)
                {
                    for (int j = 0; j < ancho - 2; j++)
                    {
                        Console.Write("¯");
                    }
                }
                else if (i == alto - 1)
                {
                    for (int j = 0; j < ancho - 2; j++)
                    {
                        Console.Write("_");
                    }
                }
                else
                {
                    for (int m = 0; m < ancho - 2; m++)
                    {
                        if (asientos[a, b, c] == true)//comprueba si el asiento esta reservado
                        {
                            System.Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("¦");
                            Console.ResetColor();
                        }
                        else
                        {
                            System.Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("¦");
                            Console.ResetColor();
                        }
                    }
                }
                //Console.SetCursorPosition(x, y+1);
                Console.Write("|\n");
                y = y + 1;
                Console.SetCursorPosition(x, y);
            }
        }
        #endregion
        //Dibujar cine
        #region
        public static void dibujarCine(int c = 0)
        {
            Console.Clear();
            Console.SetWindowSize(150, 40);
            int a = 0;
            Console.SetCursorPosition(125, 3);
            Console.Write("Asientos :");
            Console.SetCursorPosition(125, 7);
            System.Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("¦ No disponibles");
            Console.SetCursorPosition(125, 13);
            System.Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("¦ Disponibles");


            for (int i = 1; i < 11; i++)// posicion asiento 1 en pantalla x
            {
                for (int j = 2; j < 12; j++)// pos asiento 1 en pantalla y
                {
                    //Console.Write(a);
                    a++;
                    dibujarAsiento(10 * j, 5 * i, i - 1, j - 2, c);//10 y 5 distancia entre los cuadros
                    Console.Write("  " + a);//numero de asiento
                }
            }
        }
        #endregion
        //Reserva asiento
        #region
        static void reservar(int c, int cant)
        {
            bool condicion;
            int asiento, x, y;
            while (true)
            {

                do
                {
                    Console.Clear();
                    dibujarCine(c);
                    Console.SetCursorPosition(20, 1);
                    Console.Write("Tiene {0} boletos", cant);
                    Console.SetCursorPosition(20, 2);
                    Console.Write("Ingrese el numero de asiento:");
                    condicion = int.TryParse(Console.ReadLine(), out asiento);
                } while (condicion == false || asiento < 1 || asiento > 100);
                asiento--;
                y = asiento % 10;
                x = Math.Abs(asiento / 10);
                if (asientos[x, y, c] == false)
                {
                    cant--;
                    asientos[x, y, c] = true;
                    dibujarAsiento(10 * (y + 2), 5 * (x + 1), x, y, c);
                    if (cant < 1)
                    {

                        Console.Clear();
                        ticket();
                        imprimirticket();
                        Console.ReadKey();
                        MenuPrincipal();
                    }
                }
                else
                {
                    Console.WriteLine("Asiento ocupado, escoja otro");
                }
            }

            /* asiento--;
         y = asiento % 10;
         x = Math.Abs(asiento / 10);
         asientos[x, y,c] = true;
         dibujarAsiento(10 * (y + 2), 5 * (x + 1), x, y,c);*/
        }
        #endregion
        //Estadisticas menu
        #region
        public static void estadisticasMenu()
        {
            bool condicion;
            int opEst;
            do
            {
                Console.Clear();
                Console.WriteLine("*** Menu de estadísticas ***");
                Console.WriteLine("Seleccione sala.");
                Console.WriteLine("* 1 * Sala 1");
                Console.WriteLine("* 2 * Sala 2");
                Console.WriteLine("* 3 * Sala 3");
                Console.WriteLine("* 4 * Sala 4");
                condicion = int.TryParse(Console.ReadLine(), out opEst);
            } while (condicion == false || opEst < 1 || opEst > 4);
            estadisticas(opEst);
            Console.WriteLine("Presione <ENTER> para continuar");
            Console.ReadKey();
            MenuPrincipal();
        }
        #endregion
        //Estadisticas
        #region
        public static void estadisticas(int opEst)
        {
            int opH;
            bool condicion;
            switch (opEst)
            {
                case 1:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*** Sala 1 ***");
                        Console.WriteLine("Seleccione un horario.");
                        Console.WriteLine("* 1 * Horario 1");
                        Console.WriteLine("* 2 * Horario 2");
                        Console.WriteLine("* 3 * Horario 3");
                        condicion = int.TryParse(Console.ReadLine(), out opH);
                    } while (condicion == false || opH < 1 || opH > 3);
                    switch (opH)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 1, Horario 1");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 0]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 0]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 0]);
                            decimal ingresos = ((datos[0, 0] * 2.25M) + (datos[1, 0] * 4.25M) + (datos[2, 0] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 1, Horario 2");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 1]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 1]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 1]);
                            ingresos = ((datos[0, 1] * 2.25M) + (datos[1, 1] * 4.25M) + (datos[2, 1] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 1, Horario 3");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 2]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 2]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 2]);
                            ingresos = ((datos[0, 2] * 2.25M) + (datos[1, 2] * 4.25M) + (datos[2, 2] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*** Sala 2 ***");
                        Console.WriteLine("Seleccione horario.");
                        Console.WriteLine("* 1 * Horario 1");
                        Console.WriteLine("* 2 * Horario 2");
                        Console.WriteLine("* 3 * Horario 3");
                        condicion = int.TryParse(Console.ReadLine(), out opH);
                    } while (condicion == false || opH < 1 || opH > 3);
                    switch (opH)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 2, Horario 1");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 3]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 3]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 3]);
                            decimal ingresos = ((datos[0, 3] * 2.25M) + (datos[1, 3] * 4.25M) + (datos[2, 3] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 2, Horario 2");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 4]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 4]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 4]);
                            ingresos = ((datos[0, 4] * 2.25M) + (datos[1, 4] * 4.25M) + (datos[2, 4] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 2, Horario 3");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 5]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 5]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 5]);
                            ingresos = ((datos[0, 5] * 2.25M) + (datos[1, 5] * 4.25M) + (datos[2, 5] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*** Sala 3 ***");
                        Console.WriteLine("Seleccione horario.");
                        Console.WriteLine("* 1 * Horario 1");
                        Console.WriteLine("* 2 * Horario 2");
                        Console.WriteLine("* 3 * Horario 3");
                        condicion = int.TryParse(Console.ReadLine(), out opH);
                    } while (condicion == false || opH < 1 || opH > 3);
                    switch (opH)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 3, Horario 1");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 6]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 6]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 6]);
                            decimal ingresos = ((datos[0, 6] * 2.25M) + (datos[1, 6] * 4.25M) + (datos[2, 6] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 3, Horario 2");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 7]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 7]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 7]);
                            ingresos = ((datos[0, 7] * 2.25M) + (datos[1, 7] * 4.25M) + (datos[2, 7] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 3, Horario 3");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 8]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 8]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 8]);
                            ingresos = ((datos[0, 8] * 2.25M) + (datos[1, 8] * 4.25M) + (datos[2, 8] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        default:
                            break;
                    }
                    break;
                case 4:
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("*** Sala 4 ***");
                        Console.WriteLine("Seleccione horario.");
                        Console.WriteLine("* 1 * Horario 1");
                        Console.WriteLine("* 2 * Horario 2");
                        Console.WriteLine("* 3 * Horario 3");
                        condicion = int.TryParse(Console.ReadLine(), out opH);
                    } while (condicion == false || opH < 1 || opH > 3);
                    switch (opH)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 4, Horario 1");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 9]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 9]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 9]);
                            decimal ingresos = ((datos[0, 9] * 2.25M) + (datos[1, 9] * 4.25M) + (datos[2, 9] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 4, Horario 2");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 10]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 10]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 10]);
                            ingresos = ((datos[0, 10] * 2.25M) + (datos[1, 10] * 4.25M) + (datos[2, 10] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Mostrando datos de Sala 4, Horario 3");
                            Console.WriteLine("Boletos Niño: \t\t" + datos[0, 11]);
                            Console.WriteLine("Boletos Adulto: \t" + datos[1, 11]);
                            Console.WriteLine("Boletos Adulto Mayor: \t" + datos[2, 11]);
                            ingresos = ((datos[0, 11] * 2.25M) + (datos[1, 11] * 4.25M) + (datos[2, 11] * 3.25M));
                            Console.WriteLine("Ingresos: \t\t" + ingresos.ToString("C2"));
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }

        #endregion
        //Clear datos
        #region
        static void reset()
        {
            int op;
            op = validaciones("1- Limpiar una sala y sus datos \n2- Limpiar todas las salas y sus datos ", 1, 2);
            switch (op)
            {
                case 1:
                    Console.Clear();
                    op = validaciones("Sala \"1\"  \"ESO: Capitulo 2\" \nSala \"2\"  \"Dora y la ciudad perdida\" \nSala \"3\"  \"Avengers: End Game\" \nSala \"4\"  \"El Rey Leon\" \nIngrese la sala que desea resetear", 1, 4);
                    switch (op)
                    {
                        case 1:
                            Console.Clear();
                            op = validaciones("Sala 1: Pelicula: \"ESO: Capitulo 2\" \nHORARIOS: \n1- 19:00 \n2- 21:30 \n3- 00:30 \nElija el horario que desea resetear", 1, 3);
                            switch (op)
                            {
                                case 1:
                                    reset1(0);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                                case 2:
                                    reset1(1);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                                case 3:
                                    reset1(2);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                            }
                            break;
                        case 2:
                            Console.Clear();
                            op = validaciones("Sala 2: Pelicula: \"Dora y la ciudad perdida\" \nHORARIOS: \n1- 10:45 \n2- 13:20 \n3- 15:25 \nElija el horario que desea resetear", 1, 3);
                            switch (op)
                            {
                                case 1:
                                    reset1(3);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                                case 2:
                                    reset1(4);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                                case 3:
                                    reset1(5);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                            }
                            break;
                        case 3:
                            Console.Clear();
                            op = validaciones("Sala 3: Pelicula: \"Avengers: End Game\" \nHORARIOS: \n1- 12:55 \n2- 15:25 \n3- 17:25 \nElija el horario que desea resetear", 1, 3);

                            switch (op)
                            {
                                case 1:
                                    reset1(6);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                                case 2:
                                    reset1(7);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                                case 3:
                                    reset1(8);
                                    for (int i = 0; i < 3; i++)
                                    {
                                        datos[i, 8] = 0;
                                    }
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                            }
                            break;
                        case 4:
                            Console.Clear();
                            op = validaciones("Sala 4: Pelicula: \"El Rey Leon\" \nHORARIOS: \n1- 10:25 \n2- 19:30 \n3- 22:00 \nElija el horario que desea resetear", 1, 3);
                            switch (op)
                            {
                                case 1:
                                    reset1(9);
                                    for (int i = 0; i < 3; i++)
                                    {
                                        datos[i, 9] = 0;
                                    }
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                                case 2:
                                    reset1(10);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                                case 3:
                                    reset1(11);
                                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                                    Console.ReadKey();
                                    MenuPrincipal();
                                    break;
                            }
                            break;
                    }
                    break;
                case 2:
                    op = validaciones("¿Desea resetear los datos? 1- Si 2- No (Se eliminaran las estadisticas de venta y se reiniciaran las salas)", 1, 2);
                    if (op == 1)
                    {
                        reset2();
                    }
                    Console.WriteLine("Se han limpiado los datos, presione ENTER para continuar");
                    Console.ReadKey();
                    MenuPrincipal();
                    break;
            }

            Console.ReadKey();
        }

        static void reset1(int x)
        {
            for (int a = 0; a < asientos.GetLength(2); a++)
            {
                for (int i = 0; i < asientos.GetLength(1); i++)//llenado de asientos todos estan en false 
                {
                    for (int j = 0; j < asientos.GetLength(0); j++)
                    {
                        asientos[j, i, x] = false;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                datos[i, x] = 0;
            }
        }

        static void reset2()
        {
            for (int i = 0; i < datos.GetLength(0); i++)
            {
                for (int j = 0; j < datos.GetLength(1); j++)
                {
                    datos[i, j] = 0;
                }
            }
            for (int a = 0; a < asientos.GetLength(2); a++)
            {
                for (int i = 0; i < asientos.GetLength(1); i++)//llenado de asientos todos estan en false 
                {
                    for (int j = 0; j < asientos.GetLength(0); j++)
                    {
                        asientos[j, i, a] = false;
                    }
                }
            }
        }
        #endregion

        //Contraseña acceso opciones 2 y 3
        #region
        static void contraseña(int op)
        {
            string clave;
            int c = 0;
            Console.WriteLine("clave");
            clave = Console.ReadLine();
            while (clave != "****" && c < 5)
            {
                c += 1;
                Console.WriteLine("intentelo de nuevo");
                clave = Console.ReadLine();
                Console.Clear();
            }
            if (clave == "****")
            {
                if (op == 2)
                {
                    Console.Clear();
                    Console.WriteLine("*** MENU ESTADISTICAS *** \n\n* 1 * Estadisticas por funcion.\n* 2 * Total global de ingresos.");
                    switch (validaciones("Seleccione opcion: ", 1, 2))
                    {
                        case 1:
                            Console.Clear();
                            estadisticasMenu();
                            MenuPrincipal();
                            break;
                        case 2:
                            Console.Clear();
                            totalGlobal();
                            MenuPrincipal();
                            break;
                    }
                }
                else
                {
                    if (op == 3)
                    {
                        reset();
                    }
                }
            }
        }
        #endregion

    }
}