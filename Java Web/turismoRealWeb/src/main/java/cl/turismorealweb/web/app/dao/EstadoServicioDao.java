package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.EstadoServicio;

public interface EstadoServicioDao {

	public List<EstadoServicio> listarEstadoServicio();
	public EstadoServicio listarEstadoServicioPorId(int idEstadoServicio);
	public String crearEstadoServicio(EstadoServicio estadoServicio);
	public String actualizarEstadoServicio(EstadoServicio estadoServicio);
	public String eliminarEstadoServicio(Integer idEstadoServicio);		
}
