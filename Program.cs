
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

List<string> matriculasMaterias = new List<string>();
List<string> nombresMaterias = new List<string>();
List<List<double>> notasMaterias = new List<List<double>>();
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
    Console.WriteLine("7. Mostrar estadisticas");

    int opcionMenu = LeerEntero("Seleccione una opcion: ", 1, 7);

    switch (opcionMenu)
    {
case 1:
    CrearEstudiante(
        matriculas,
        nombres,
        apellidos,
        edades,
        sexos,
        fechasNacimiento,
        cursos);
    break;


        case 2:
            VerEstudiantes(
                matriculas, nombres, apellidos, edades,
                sexos, fechasNacimiento, cursos);
            break;

        case 3:
            GestionarMateriasNotas(
                matriculas,
                nombres,
                apellidos,
                matriculasMaterias,
                nombresMaterias,
                notasMaterias);
            break;


        case 4:
            EliminarEstudiante(
                matriculas,
                nombres,
                apellidos,
                edades,
                sexos,
                fechasNacimiento,
                cursos,
                matriculasMaterias,
                nombresMaterias,
                notasMaterias);
            break;


        case 5:
            MostrarReportes(
                matriculas,
                nombres,
                apellidos,
                edades,
                sexos,
                cursos,
                matriculasMaterias,
                nombresMaterias,
                notasMaterias);
            break;

        case 6:
            salir = true;
            Console.WriteLine("Sistema finalizado");
            break;

        case 7:
            MostrarEstadisticas(
                matriculas,
                nombres,
                apellidos,
                edades,
                cursos,
                matriculasMaterias,
                notasMaterias);
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


static void EliminarEstudiante(
    List<string> matriculas,
    List<string> nombres,
    List<string> apellidos,
    List<int> edades,
    List<char> sexos,
    List<DateTime> fechasNacimiento,
    List<string> cursos,
    List<string> matriculasMaterias,
    List<string> nombresMaterias,
    List<List<double>> notasMaterias)
{

    Console.Clear();
    Console.WriteLine("ELIMINAR ESTUDIANTE");
    Console.WriteLine("Escriba VOLVER para regresar al menu principal");

    string matricula = LeerTexto("Matricula del estudiante: ");

    if (matricula.Equals("VOLVER", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }

    int indice = matriculas.IndexOf(matricula);

    if (indice == -1)
    {
        Console.WriteLine("No existe un estudiante con esa matricula");
        Pausar();
        return;
    }

    Console.WriteLine($"Estudiante: {nombres[indice]} {apellidos[indice]}");
    Console.Write("Desea eliminar este estudiante (S/N): ");

    string? respuesta = Console.ReadLine();


    if (respuesta != null &&
        respuesta.Trim().Equals("S", StringComparison.OrdinalIgnoreCase))
    {
        for (int i = matriculasMaterias.Count - 1; i >= 0; i--)
        {
            if (matriculasMaterias[i] == matricula)
            {
                matriculasMaterias.RemoveAt(i);
                nombresMaterias.RemoveAt(i);
                notasMaterias.RemoveAt(i);
            }
        }

        matriculas.RemoveAt(indice);
        nombres.RemoveAt(indice);
        apellidos.RemoveAt(indice);
        edades.RemoveAt(indice);
        sexos.RemoveAt(indice);
        fechasNacimiento.RemoveAt(indice);
        cursos.RemoveAt(indice);

        Console.WriteLine("Estudiante y sus materias eliminados correctamente");
    }

    else
    {
        Console.WriteLine("Se cancelo la eliminacion");
    }

    Pausar();
}


static void GestionarMateriasNotas(
    List<string> matriculas,
    List<string> nombres,
    List<string> apellidos,
    List<string> matriculasMaterias,
    List<string> nombresMaterias,
    List<List<double>> notasMaterias)
{
    bool volver = false;

    while (!volver)
    {
        Console.Clear();
        Console.WriteLine("GESTION DE MATERIAS Y NOTAS");
        Console.WriteLine("1. Registrar materia y notas");
        Console.WriteLine("2. Consultar materias y notas");
        Console.WriteLine("0. Volver al menu principal");

        int opcion = LeerEntero("Seleccione una opcion: ", 0, 2);

        switch (opcion)
        {

            case 1:
                RegistrarMateriaNotas(
                    matriculas,
                    nombres,
                    apellidos,
                    matriculasMaterias,
                    nombresMaterias,
                    notasMaterias);
                break;



            case 2:
                ConsultarMateriasNotas(
                    matriculas,
                    nombres,
                    apellidos,
                    matriculasMaterias,
                    nombresMaterias,
                    notasMaterias);
                break;


            case 0:
                volver = true;
                break;
        }
    }
}



static void RegistrarMateriaNotas(
    List<string> matriculas,
    List<string> nombres,
    List<string> apellidos,
    List<string> matriculasMaterias,
    List<string> nombresMaterias,
    List<List<double>> notasMaterias)
{
    Console.Clear();
    Console.WriteLine("REGISTRAR MATERIA Y NOTAS");

    if (matriculas.Count == 0)
    {
        Console.WriteLine("No hay estudiantes registrados");
        Pausar();
        return;
    }

    string matricula = LeerTexto(
        "Matricula del estudiante o VOLVER para regresar: ");

    if (matricula.Equals("VOLVER", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }

    int indiceEstudiante = matriculas.IndexOf(matricula);

    if (indiceEstudiante == -1)
    {
        Console.WriteLine("No existe un estudiante con esa matricula");
        Pausar();
        return;
    }

    Console.WriteLine(
        $"Estudiante: {nombres[indiceEstudiante]} {apellidos[indiceEstudiante]}");

    string nombreMateria = LeerTexto("Nombre de la materia: ");

    List<double> notas = new List<double>();

    int cantidadNotas = LeerEntero(
        "Cuantas notas desea registrar: ", 1, 20);

    for (int i = 0; i < cantidadNotas; i++)
    {
        double nota;

        while (true)
        {
            Console.Write($"Digite la nota {i + 1} entre 0 y 100: ");
            string? entrada = Console.ReadLine();

            if (double.TryParse(
                    entrada,
                    NumberStyles.Float,
                    CultureInfo.InvariantCulture,
                    out nota) &&
                nota >= 0 && nota <= 100)
            {
                break;
            }

            if (double.TryParse(
                    entrada,
                    NumberStyles.Float,
                    CultureInfo.CurrentCulture,
                    out nota) &&
                nota >= 0 && nota <= 100)
            {
                break;
            }

            Console.WriteLine("La nota debe estar entre 0 y 100");
        }

        notas.Add(nota);
    }

    matriculasMaterias.Add(matricula);
    nombresMaterias.Add(nombreMateria);
    notasMaterias.Add(notas);

    double promedio = notas.Average();

    Console.WriteLine();
    Console.WriteLine("Materia y notas registradas correctamente");
    Console.WriteLine($"Materia: {nombreMateria}");
    Console.WriteLine($"Cantidad de notas: {notas.Count}");
    Console.WriteLine($"Promedio: {promedio:F2}");

    Pausar();
}

static void ConsultarMateriasNotas(
    List<string> matriculas,
    List<string> nombres,
    List<string> apellidos,
    List<string> matriculasMaterias,
    List<string> nombresMaterias,
    List<List<double>> notasMaterias)
{
    Console.Clear();
    Console.WriteLine("CONSULTAR MATERIAS Y NOTAS");

    if (matriculasMaterias.Count == 0)
    {
        Console.WriteLine("No hay materias registradas");
        Pausar();
        return;
    }

    string matricula = LeerTexto(
        "Matricula del estudiante o VOLVER para regresar: ");

    if (matricula.Equals("VOLVER", StringComparison.OrdinalIgnoreCase))
    {
        return;
    }

    int indiceEstudiante = matriculas.IndexOf(matricula);

    if (indiceEstudiante == -1)
    {
        Console.WriteLine("No existe un estudiante con esa matricula");
        Pausar();
        return;
    }

    Console.WriteLine();
    Console.WriteLine(
        $"Estudiante: {nombres[indiceEstudiante]} {apellidos[indiceEstudiante]}");
    Console.WriteLine($"Matricula: {matricula}");

    bool tieneMaterias = false;

    for (int i = 0; i < matriculasMaterias.Count; i++)
    {
        if (matriculasMaterias[i] == matricula)
        {
            tieneMaterias = true;

            Console.WriteLine();
            Console.WriteLine($"Materia: {nombresMaterias[i]}");

            if (notasMaterias[i].Count > 0)
            {
                Console.WriteLine(
                    $"Notas: {string.Join(", ", notasMaterias[i])}");

                double promedio = notasMaterias[i].Average();

                Console.WriteLine($"Promedio: {promedio:F2}");
            }
            else
            {
                Console.WriteLine("Esta materia no tiene notas registradas");
            }
        }
    }

    if (!tieneMaterias)
    {
        Console.WriteLine("Este estudiante no tiene materias registradas");
    }

    Pausar();
}


static void MostrarReportes(
    List<string> matriculas,
    List<string> nombres,
    List<string> apellidos,
    List<int> edades,
    List<char> sexos,
    List<string> cursos,
    List<string> matriculasMaterias,
    List<string> nombresMaterias,
    List<List<double>> notasMaterias)
{
    bool volver = false;

    while (!volver)
    {
        Console.Clear();
        Console.WriteLine("MENU DE REPORTES");
        Console.WriteLine("1. Reporte general de estudiantes");
        Console.WriteLine("2. Reporte de estudiantes por curso");
        Console.WriteLine("3. Reporte por sexo");
        Console.WriteLine("4. Reporte de promedios academicos");
        Console.WriteLine("0. Volver al menu principal");

        int opcion = LeerEntero(
            "Seleccione una opcion: ", 0, 4);

        switch (opcion)
        {

            case 1:
                Console.Clear();
                Console.WriteLine("REPORTE GENERAL DEL SISTEMA");
                Console.WriteLine();

                int totalMasculinoGeneral = 0;
                int totalFemeninoGeneral = 0;
                List<string> cursosGenerales = new List<string>();

                for (int i = 0; i < sexos.Count; i++)
                {
                    if (sexos[i] == 'M')
                    {
                        totalMasculinoGeneral++;
                    }
                    else if (sexos[i] == 'F')
                    {
                        totalFemeninoGeneral++;
                    }

                    if (!cursosGenerales.Contains(cursos[i]))
                    {
                        cursosGenerales.Add(cursos[i]);
                    }
                }

                Console.WriteLine($"Total de estudiantes: {matriculas.Count}");
                Console.WriteLine($"Estudiantes masculinos: {totalMasculinoGeneral}");
                Console.WriteLine($"Estudiantes femeninos: {totalFemeninoGeneral}");
                Console.WriteLine($"Total de cursos diferentes: {cursosGenerales.Count}");
                Console.WriteLine($"Total de materias registradas: {nombresMaterias.Count}");

                Pausar();
                break;



            case 2:
                Console.Clear();
                Console.WriteLine("REPORTE DE ESTUDIANTES POR CURSO");
                Console.WriteLine();

                if (matriculas.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados");
                }
                else
                {
                    List<string> cursosUnicos = new List<string>();

                    for (int i = 0; i < cursos.Count; i++)
                    {
                        if (!cursosUnicos.Contains(cursos[i]))
                        {
                            cursosUnicos.Add(cursos[i]);
                        }
                    }

                    foreach (string curso in cursosUnicos)
                    {
                        int cantidad = 0;

                        Console.WriteLine("------------------------------");
                        Console.WriteLine($"Curso: {curso}");

                        for (int i = 0; i < cursos.Count; i++)
                        {
                            if (cursos[i] == curso)
                            {
                                cantidad++;
                            }
                        }

                        Console.WriteLine($"Cantidad de estudiantes: {cantidad}");
                        Console.WriteLine("Estudiantes:");

                        for (int i = 0; i < cursos.Count; i++)
                        {
                            if (cursos[i] == curso)
                            {
                                Console.WriteLine(
                                    $"{matriculas[i]} {nombres[i]} {apellidos[i]}");
                            }
                        }
                    }
                }

                Pausar();
                break;


            case 3:
                Console.WriteLine();
                Console.WriteLine("Reporte de estudiantes por sexo");

                int totalMasculino = 0;
                int totalFemenino = 0;

                for (int i = 0; i < sexos.Count; i++)
                {
                    if (sexos[i] == 'M')
                    {
                        totalMasculino++;
                    }
                    else if (sexos[i] == 'F')
                    {
                        totalFemenino++;
                    }
                }

                Console.WriteLine(
                    $"Estudiantes masculinos: {totalMasculino}");
                Console.WriteLine(
                    $"Estudiantes femeninos: {totalFemenino}");

                Pausar();
                break;


            case 4:
                Console.Clear();
                Console.WriteLine("REPORTE DE PROMEDIOS ACADEMICOS");
                Console.WriteLine();

                if (matriculas.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados");
                }
                else
                {
                    for (int i = 0; i < matriculas.Count; i++)
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine(
                            $"Estudiante: {nombres[i]} {apellidos[i]}");
                        Console.WriteLine($"Matricula: {matriculas[i]}");

                        bool tieneMaterias = false;

                        for (int j = 0; j < matriculasMaterias.Count; j++)
                        {
                            if (matriculasMaterias[j] == matriculas[i])
                            {
                                tieneMaterias = true;

                                Console.WriteLine(
                                    $"Materia: {nombresMaterias[j]}");

                                if (notasMaterias[j].Count > 0)
                                {
                                    double promedio = notasMaterias[j].Average();

                                    Console.WriteLine($"Promedio: {promedio:F2}");

                                    if (promedio >= 70)
                                    {
                                        Console.WriteLine("Estado: Aprobado");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Estado: Reprobado");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No hay notas registradas");
                                }
                            }
                        }

                        if (!tieneMaterias)
                        {
                            Console.WriteLine("No tiene materias registradas");
                        }
                    }
                }

                Pausar();
                break;


            case 0:
                volver = true;
                break;
        }
    }
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
static void MostrarEstadisticas(
    List<string> matriculas,
    List<string> nombres,
    List<string> apellidos,
    List<int> edades,
    List<string> cursos,
    List<string> matriculasMaterias,
    List<List<double>> notasMaterias)
{
    bool volver = false;

    while (!volver)
    {
        Console.Clear();
        Console.WriteLine("MENU DE ESTADISTICAS");
        Console.WriteLine("1. Cantidad total de estudiantes");
        Console.WriteLine("2. Edad promedio");
        Console.WriteLine("3. Estudiante de mayor y menor edad");
        Console.WriteLine("4. Curso con mas estudiantes");
        Console.WriteLine("5. Promedio academico general");
        Console.WriteLine("0. Volver al menu principal");

        int opcion = LeerEntero("Seleccione una opcion: ", 0, 5);

        switch (opcion)
        {
            case 1:
                Console.WriteLine(
                    $"Total de estudiantes: {matriculas.Count}");
                Pausar();
                break;

            case 2:
                if (edades.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados");
                }
                else
                {
                    double edadPromedio = edades.Average();
                    Console.WriteLine($"Edad promedio: {edadPromedio:F2}");
                }

                Pausar();
                break;

            case 3:
                if (edades.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados");
                }
                else
                {
                    int edadMayor = edades.Max();
                    int edadMenor = edades.Min();

                    Console.WriteLine("Estudiantes de mayor edad:");

                    for (int i = 0; i < edades.Count; i++)
                    {
                        if (edades[i] == edadMayor)
                        {
                            Console.WriteLine(
                                $"{nombres[i]} {apellidos[i]} - {edades[i]} años");
                        }
                    }

                    Console.WriteLine("Estudiantes de menor edad:");

                    for (int i = 0; i < edades.Count; i++)
                    {
                        if (edades[i] == edadMenor)
                        {
                            Console.WriteLine(
                                $"{nombres[i]} {apellidos[i]} - {edades[i]} años");
                        }
                    }
                }

                Pausar();
                break;

            case 4:
                if (cursos.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados");
                }
                else
                {
                    string cursoMayor = cursos[0];
                    int cantidadMayor = 0;

                    foreach (string curso in cursos)
                    {
                        int cantidad = 0;

                        for (int i = 0; i < cursos.Count; i++)
                        {
                            if (cursos[i] == curso)
                            {
                                cantidad++;
                            }
                        }

                        if (cantidad > cantidadMayor)
                        {
                            cantidadMayor = cantidad;
                            cursoMayor = curso;
                        }
                    }

                    Console.WriteLine($"Curso con mas estudiantes: {cursoMayor}");
                    Console.WriteLine($"Cantidad de estudiantes: {cantidadMayor}");
                }

                Pausar();
                break;

            case 5:
                double sumaPromedios = 0;
                int materiasConNotas = 0;

                for (int i = 0; i < notasMaterias.Count; i++)
                {
                    if (notasMaterias[i].Count > 0)
                    {
                        sumaPromedios += notasMaterias[i].Average();
                        materiasConNotas++;
                    }
                }

                if (materiasConNotas == 0)
                {
                    Console.WriteLine("No hay notas registradas");
                }
                else
                {
                    double promedioGeneral = sumaPromedios / materiasConNotas;

                    Console.WriteLine(
                        $"Promedio academico general: {promedioGeneral:F2}");
                }

                Pausar();
                break;

            case 0:
                volver = true;
                break;
        }
    }
}