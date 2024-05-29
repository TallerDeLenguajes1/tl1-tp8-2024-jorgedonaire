// See https://aka.ms/new-console-template for more information
using System.Dynamic;
using Microsoft.VisualBasic;
using EspacioTareas;


Random aleatorio = new Random();
int cantidadTareas=0;
var tareasPendientes = new List<Tarea>();
var tareasRealizadas = new List<Tarea>();

bool repetirIngreso = false;
do
{
    Console.WriteLine("Ingrese la cantidad de tareas: ");
    string cantidadIngresada = Console.ReadLine();
    bool control = int.TryParse(cantidadIngresada,out int cantidadIngresadaConvertida);
    if (control)
    {
        cantidadTareas = cantidadIngresadaConvertida;
        for (int i = 0; i < cantidadTareas; i++)
        {
            Console.WriteLine("Ingrese la descripcion de la tarea: ");
            string descripcion = Console.ReadLine();
            var tarea = new Tarea(i, descripcion, aleatorio.Next(10,100)); //Puedo poner var o Tarea, antes del nombre, si se inicializa en la misma linea
            tareasPendientes.Add(tarea); //agrego la tarea creada a la lista de tareas pendientes    
        }
    }else
    {
        Console.WriteLine("ERROR. Ingrese un numero");
        repetirIngreso = true;
    }
} while (repetirIngreso);

//creo una tarea
//Tarea tarea = new Tarea(1, "Tarea 1", 10); //Puedo poner var o Tarea, antes del nombre, si se inicializa en la misma linea



//Forma de acceder a ver una tarea
/*
var tarea2 = tareasPendientes[0]; //pueddo acceder a una tarea por indice
*/
//2. Mover tareas pendientes a realizadas
//Debo mostrar la lista de tareas con sus id y despues preguntar cual tarea mover segun su id. Preguntar si desea mover otra tarea y repetir
int idABuscar;
Tarea tareaAMover = null;
repetirIngreso = false;
string moverOtra;
do
{
    Console.WriteLine("** LISTA DE TAREAS PENDIENTES **");
    for (int i = 0; i < tareasPendientes.Count; i++)
    {
        Console.WriteLine("ID: " + tareasPendientes[i].Id + "| Descripcion: " + tareasPendientes[i].Descripcion + " | Duracion: " + tareasPendientes[i].Duracion);
    }

    do
    {
        Console.WriteLine("Ingrese el ID de la tarea que desee mover:");
        string idIngresado = Console.ReadLine();
        bool control = int.TryParse(idIngresado,out int idIngresadoConvertido);
        if (control)
        {
            idABuscar = idIngresadoConvertido;
            for (int i = 0; i < tareasPendientes.Count; i++)
            {
                foreach (var tareaPendiente in tareasPendientes)
                {
                    if (tareaPendiente.Id == idABuscar)
                    {
                        tareaAMover = tareaPendiente;
                        tareasRealizadas.Add(tareaPendiente); //tambien funciona con estas 2 lineas dentro del if pero si solo buscamos 1 id porque el break termina.
                        tareasPendientes.Remove(tareaPendiente);
                        break;
                    }
                }

                // if (tareaAMover != null)
                // {
                //     tareasRealizadas.Add(tareaAMover);//Estas 2 lineas las usaria en vez de las de arriba si tendria que buscar mas de una coincidencia.
                //     tareasPendientes.Remove(tareaAMover);
                // }  
            }
        }else
        {
            Console.WriteLine("ERROR. Ingrese un numero");
            repetirIngreso = true;
        }
    } while (repetirIngreso);
    Console.WriteLine("Desea mover otra tarea? s - si | n - no:");
    moverOtra = Console.ReadLine();

} while (moverOtra == "s");

//Muestra las 2 listas
Console.WriteLine("** LISTA DE TAREAS PENDIENTES **");
    for (int i = 0; i < tareasPendientes.Count; i++)
    {
        Console.WriteLine("ID: " + tareasPendientes[i].Id + "| Descripcion: " + tareasPendientes[i].Descripcion + " | Duracion: " + tareasPendientes[i].Duracion);
    }
Console.WriteLine("");
Console.WriteLine("** LISTA DE TAREAS REALIZADAS **");
    for (int i = 0; i < tareasRealizadas.Count; i++)
    {
        Console.WriteLine("ID: " + tareasRealizadas[i].Id + "| Descripcion: " + tareasRealizadas[i].Descripcion + " | Duracion: " + tareasRealizadas[i].Duracion);
    }
//Interfaz para buscar tareas por palabras
Console.WriteLine("** BUSCAR TAREAS PENDIENTES **");
string descripcionBuscada;
Console.WriteLine("Ingrese la descripcion a buscar:");
descripcionBuscada = Console.ReadLine();

Console.WriteLine("Resultados:");
foreach (var tareaPendiente in tareasPendientes)
{
    if (tareaPendiente.Descripcion.Contains(descripcionBuscada))
    {
        Console.WriteLine("ID: " + tareaPendiente.Id + "| Descripcion: " + tareaPendiente.Descripcion + " | Duracion: " + tareaPendiente.Duracion);
    }
}

