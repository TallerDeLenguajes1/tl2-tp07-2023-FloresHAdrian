namespace espacioTarea;

public class ManejoDeTareas
{

    private AccesoADatos accesoTareas;

    public ManejoDeTareas(AccesoADatos accesoTareas){
        this.accesoTareas = accesoTareas;
    }

    public bool AddTarea(Tarea tarea)
    {
        var resultado = false;
        if (tarea != null)
        {
            var tareas = accesoTareas.Obtener();
            tareas.Add(tarea);
            tarea.Id = tareas.Count(); //Revisar porque sib borro tarea probablemente se repita id al agregar
            accesoTareas.Guardar(tareas);
            resultado = true;
        }
        return resultado;
    }

    public Tarea GetTarea(int id)
    {
        var tareas = accesoTareas.Obtener();
        return tareas.FirstOrDefault(t => t.Id == id);
    }

    public List<Tarea> GetTareas(){
        return accesoTareas.Obtener();
    }

    public List<Tarea> GetTareasCompletadas(){
        var tareas = accesoTareas.Obtener();
        return tareas.FindAll(t=> t.Estado == Estado.Completada);
    }

    public bool UpdateTarea(Tarea tareaActulizada){
        var resultado = false;
        var listaTareas = accesoTareas.Obtener();
        var tarea = listaTareas.FirstOrDefault( t => t.Id == tareaActulizada.Id);
        if (tareaActulizada != null && tarea !=null)
        {
            tarea.Estado = tareaActulizada.Estado;
            tarea.Descripcion = tareaActulizada.Descripcion;
            tarea.Titulo = tareaActulizada.Titulo;
            accesoTareas.Guardar(listaTareas);
            resultado = true;
        }
        return resultado;
    }

    public bool DeleteTarea(int idTarea){
        var resultado = false;
        var listaTareas = accesoTareas.Obtener();
        var tarea = listaTareas.FirstOrDefault( t => t.Id == idTarea);
        if ( tarea !=null)
        {
            listaTareas.Remove(tarea);
            accesoTareas.Guardar(listaTareas);
            resultado = true;
        }
        return resultado;
    }
}