package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.EstadoPropiedad;

public interface EstadoPropiedadDao {

	public List<EstadoPropiedad> listarEstadosPropiedad();
	public EstadoPropiedad listarEstadoPropiedadPorId(int idEstadoPropiedad);
	public String crearEstadoPropiedad(EstadoPropiedad estadoPropiedad);
	public String actualizarEstadoPropiedad(EstadoPropiedad estadoPropiedad);
	public String eliminarEstadoPropiedad(Integer idEstadoPropiedad);
}
