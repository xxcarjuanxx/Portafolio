package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.ServicioExtra;

public interface ServicioExtraDao {

	public List<ServicioExtra> listarServiciosExtras();
	public ServicioExtra listarServicioPorId(int idServicio);
	public List<ServicioExtra> listarServiciosExtraPorPropiedad(int idPropiedad);
	public String crearServicio(ServicioExtra servicioExtra);
	public String actualizarServicio(ServicioExtra servicioExtra);
	public String eliminarServicio(Integer idServicioExtra);
}
