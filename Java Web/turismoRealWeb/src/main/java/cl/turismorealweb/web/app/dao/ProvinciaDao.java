package cl.turismorealweb.web.app.dao;

import java.util.List;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.entitie.Provincia;

public interface ProvinciaDao {
	public List<Provincia> listarProvincias();
	public Provincia listarProvinciaPorId(Integer idProvincia);
	public List<Provincia> listarProvinciasPorIdRegion(Integer idRegion);
}
