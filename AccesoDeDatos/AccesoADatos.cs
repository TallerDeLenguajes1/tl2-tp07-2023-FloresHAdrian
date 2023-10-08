using System.Text.Json;

namespace espacioTarea;


public class AccesoADatos{

    private string ruta = "infoTareas.json";
    public List<Tarea> Obtener()
    {
        List<Tarea> listaTareas = new List<Tarea>();
        if (File.Exists(ruta))
        {
            string jsonString = File.ReadAllText(ruta);
            if (jsonString != "")
            {
                listaTareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
            }
            return listaTareas;
        }
        else
        {
            File.WriteAllText(ruta,"");
            return listaTareas;
        }
    }

    public void Guardar(List<Tarea> listaTareas)
    {
        string TareasAGuardar = JsonSerializer.Serialize(listaTareas);
        File.WriteAllText(ruta, TareasAGuardar);
    }

}