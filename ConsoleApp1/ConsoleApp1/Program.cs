
using System;
using System.Collections.Generic;

List<string> nombres = new List<string>();
List<string> matriculas = new List<string>();
List<int> edades = new List<int>();

int opcion;

do
{
    Console.Clear();
    Console.WriteLine("SISTEMA DE ESTUDIANTES\n");
    Console.WriteLine("1 Registrar estudiante");
    Console.WriteLine("2 Listar estudiantes");
    Console.WriteLine("3 Buscar estudiante");
    Console.WriteLine("4 Actualizar estudiante");
    Console.WriteLine("5 Eliminar estudiante");
    Console.WriteLine("0 Salir\n");
    Console.Write("Seleccione una opcion: ");

    string entrada = Console.ReadLine() ?? "";

    if (!int.TryParse(entrada, out opcion))
    {
        Console.WriteLine();
        Console.WriteLine("Debe introducir un numero");
        Console.WriteLine("Presione una tecla para continuar");
        Console.ReadKey();

        opcion = -1;
        continue;
    }

    switch (opcion)
    {
        case 1:
            RegistrarEstudiante(nombres, matriculas, edades);
            break;

        case 2:
            ListarEstudiantes(nombres, matriculas, edades);
            break;

        case 3:
            BuscarEstudiante(nombres, matriculas, edades);
            break;

        case 4:
            ActualizarEstudiante(nombres, matriculas, edades);
            break;

        case 5:
            EliminarEstudiante(nombres, matriculas, edades);
            break;

        case 0:
            Console.WriteLine();
            Console.WriteLine("Gracias por utilizar el sistema");
            break;

        default:
            Console.WriteLine();
            Console.WriteLine("Opcion no valida");
            break;
    }

    if (opcion != 0)
    {
        Console.WriteLine();
        Console.WriteLine("Presione una tecla para volver al menu");
        Console.ReadKey();
    }

} while (opcion != 0);
