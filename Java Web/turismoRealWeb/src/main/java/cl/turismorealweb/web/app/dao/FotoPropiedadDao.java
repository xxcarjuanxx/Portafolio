package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.FotoPropiedad;

public interface FotoPropiedadDao {

	public List<FotoPropiedad> listarFotoPropiedadPorIdPropiedad(int idPropiedad);
	public FotoPropiedad listarFotoPropiedadPorId(int idFotoPropiedad);
	public String crearFotoPropiedad(FotoPropiedad fotoPropiedad);
	public String actualizarFotoPropiedad(FotoPropiedad fotoPropiedad);
}
