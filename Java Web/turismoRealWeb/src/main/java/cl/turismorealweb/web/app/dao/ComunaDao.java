package cl.turismorealweb.web.app.dao;

import java.util.List;

import org.springframework.stereotype.Repository;
import cl.turismorealweb.web.app.entitie.Comuna;

@Repository
public interface ComunaDao {

	public List<Comuna> listarComunas();
	public Comuna listarComunaPorId(Integer idComuna);
	public List<Comuna> listarComunasPorIdProvincia(Integer idProvincia);
}
