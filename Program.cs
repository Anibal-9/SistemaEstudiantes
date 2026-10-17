
using System;
using System.Collections.Generic;
using System.Globalization;

List<string> matriculas = new List<string>();
List<string> nombres = new List<string>();
List<string> apellidos = new List<string>();
List<int> edades = new List<int>();
List<char> sexos = new List<char>();
List<DateTime> fechasNacimiento = new List<DateTime>();
List<string> cursos = new List<string>();

bool salir = false;

while (!salir)
{
    Console.Clear();
    Console.WriteLine("SISTEMA DE REGISTRO ESTUDIANTIL");
    Console.WriteLine("1. Registrar estudiante");
    Console.WriteLine("2. Ver estudiantes");
    Console.WriteLine("3. Registrar materias y notas");
    Console.WriteLine("4. Eliminar estudiante");
    Console.WriteLine("5. Mostrar reportes");
    Console.WriteLine("6. Salir");

    int opcionMenu = LeerEntero("Seleccione una opcion: ", 1, 6);

    switch (opcionMenu)
    {
        case 1:
            CrearEstudiante(
                matriculas, nombres, apellidos, edades,
                sexos, fechasNacimiento, cursos);
            break;

        case 2:
            VerEstudiantes(
                matriculas, nombres, apellidos, edades,
                sexos, fechasNacimiento, cursos);
            break;

        case 3:
            Console.WriteLine("Esta opcion se completara en la rama materias-notas");
            Pausar();
            break;

        case 4:
            Console.WriteLine("Esta opcion se completara en la rama registro-consultas");
            Pausar();
            break;

        case 5:
            Console.WriteLine("Esta opcion se completara en la rama reportes-estudiantes");
            Pausar();
            break;

        case 6:
            salir = true;
            Console.WriteLine("Sistema finalizado");
            break;
    }
}

static void CrearEstudiante(
    List<string> matriculas,
    List<string> nombres,
    List<string> apellidos,
    List<int> edades,
    List<char> sexos,
    List<DateTime> fechasNacimiento,
    List<string> cursos)
{
    Console.Clear();
    Console.WriteLine("REGISTRO DE ESTUDIANTE");
    Console.WriteLine("Escriba VOLVER en la matricula para regresar al menu");

    string matricula = LeerTexto("Matricula: ");

    if (matricula.Equals("VOLVER", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }

    if (matriculas.Contains(matricula))
    {
        Console.WriteLine("Esa matricula ya esta registrada");
        Pausar();
        return;
    }

    string nombre = LeerTexto("Nombre: ");
    string apellido = LeerTexto("Apellido: ");
    int edad = LeerEntero("Edad: ", 1, 120);
    char sexo = LeerSexo();
    DateTime fechaNacimiento = LeerFecha("Fecha de nacimiento (dd/MM/yyyy): ");
    string curso = LeerTexto("Curso: ");

    matriculas.Add(matricula);
    nombres.Add(nombre);
    apellidos.Add(apellido);
    edades.Add(edad);
    sexos.Add(sexo);
    fechasNacimiento.Add(fechaNacimiento);
    cursos.Add(curso);

    Console.WriteLine("Estudiante registrado correctamente");
    Pausar();
}

static void VerEstudiantes(
    List<string> matriculas,
    List<string> nombres,
    List<string> apellidos,
    List<int> edades,
    List<char> sexos,
    List<DateTime> fechasNacimiento,
    List<string> cursos)
{
    Console.Clear();
    Console.WriteLine("LISTA DE ESTUDIANTES");

    if (matriculas.Count == 0)
    {
        Console.WriteLine("No hay estudiantes registrados");
    }
    else
    {
        for (int i = 0; i < matriculas.Count; i++)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Matricula: {matriculas[i]}");
            Console.WriteLine($"Nombre: {nombres[i]} {apellidos[i]}");
            Console.WriteLine($"Edad: {edades[i]}");
            Console.WriteLine($"Sexo: {sexos[i]}");
            Console.WriteLine($"Fecha de nacimiento: {fechasNacimiento[i]:dd/MM/yyyy}");
            Console.WriteLine($"Curso: {cursos[i]}");
        }
    }

    Pausar();
}

static string LeerTexto(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? texto = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(texto))
        {
            return texto.Trim();
        }

        Console.WriteLine("El campo no puede estar vacio");
    }
}

static int LeerEntero(string mensaje, int minimo, int maximo)
{
    while (true)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int numero) &&
            numero >= minimo && numero <= maximo)
        {
            return numero;
        }

        Console.WriteLine($"Digite un numero entero entre {minimo} y {maximo}");
    }
}

static char LeerSexo()
{
    while (true)
    {
        Console.Write("Sexo (M/F): ");
        string? entrada = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(entrada))
        {
            string valor = entrada.Trim().ToUpperInvariant();

            if (valor == "M" || valor == "F")
            {
                return valor[0];
            }
        }

        Console.WriteLine("Solo se permite M o F");
    }
}

static DateTime LeerFecha(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();

        if (DateTime.TryParseExact(
            entrada,
            "dd/MM/yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out DateTime fecha) &&
            fecha.Date <= DateTime.Today)
        {
            return fecha;
        }

        Console.WriteLine("Fecha invalida Use dd/MM/yyyy y no escriba una fecha futura");
    }
}

static void Pausar()
{
    Console.WriteLine();
    Console.WriteLine("Presione una tecla para volver al menu principal");
    Console.ReadKey(true);
}
