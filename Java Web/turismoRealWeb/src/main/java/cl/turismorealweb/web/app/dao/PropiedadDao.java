package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.EstadoPropiedad;
import cl.turismorealweb.web.app.entitie.Propiedad;

public interface PropiedadDao {

	public List<Propiedad> listarPropiedades();
	public Propiedad listarPropiedadPorId(int idPropiedad);
	public List<Propiedad> listarPropiedadPorComuna(int idComuna);
	public String crearPropiedad(Propiedad propiedad);
	public String actualizarPropiedad(Propiedad propiedad);
	public String eliminarPropiedad(Integer idPropiedad);
	public List<EstadoPropiedad> listarEstadosPropiedades();
	public String listarEstadosPropiedadPorId(int idPropiedad);
	public List<Propiedad> listarPropiedadPorFiltro(int idRegion, int idProvincia, String fechaDesde
			                                      , String fechaHasta, int cantHuespedes, int valor);	
}
