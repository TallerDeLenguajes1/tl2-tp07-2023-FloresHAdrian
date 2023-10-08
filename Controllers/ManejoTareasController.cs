using Microsoft.AspNetCore.Mvc;

namespace espacioTarea.Controllers;

[ApiController]
[Route("[controller]")]
public class ManejoDeTareasController : ControllerBase
{
    private ManejoDeTareas manejoTareas;
    private readonly ILogger<ManejoDeTareasController> _logger;

    public ManejoDeTareasController(ILogger<ManejoDeTareasController> logger)
    {
        _logger = logger;
        var accesoTareas = new AccesoADatos();
        manejoTareas = new ManejoDeTareas(accesoTareas);
    }

    [HttpPost]
    [Route("AddTarea")]
    public ActionResult<bool> AddTarea(Tarea tarea){

        if(manejoTareas.AddTarea(tarea)) return Ok(true);
        else return BadRequest("ERROR. No se pudo crear la tarea");
    }

    [HttpGet]
    [Route("GetTarea")]
    public ActionResult<Tarea> GetTarea(int idTarea){
        return Ok(manejoTareas.GetTarea(idTarea));
    }

    [HttpGet]
    [Route("GetTareas")]
    public ActionResult<List<Tarea>> GetTareas(){
        return Ok(manejoTareas.GetTareas());
    }

    
    [HttpGet]
    [Route("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas(){
        return Ok(manejoTareas.GetTareasCompletadas());
    }

    [HttpDelete]
    [Route("DeleteTarea")]
    public ActionResult<bool> DeleteTarea(int idTarea){
        if(manejoTareas.DeleteTarea(idTarea))
             return Ok(true);
        else
             return BadRequest("error no se pudo elimnar la tarea");
    }
}
