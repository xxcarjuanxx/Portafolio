package cl.turismorealweb.web.app.daoImpl;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityNotFoundException;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.ComunaDao;
import cl.turismorealweb.web.app.entitie.Comuna;

@Transactional
@Repository
public class ComunaDaoImpl implements ComunaDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Comuna> listarComunas() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_REGIONES.SP_LISTAR_COMUNAS", Comuna.class);
		procedureQuery.registerStoredProcedureParameter("CUR_COMUNAS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public Comuna listarComunaPorId(Integer idComuna) {
		Comuna comuna = new Comuna();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_REGIONES.SP_LISTAR_COMUNA_POR_ID", Comuna.class);
			procedureQuery.registerStoredProcedureParameter("PN_PROVINCIA_ID", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_COMUNAS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_PROVINCIA_ID", idComuna);
			procedureQuery.execute();
			comuna = (Comuna) procedureQuery.getSingleResult();
		}catch(EntityNotFoundException e){
			comuna = null;
		}
		return comuna;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Comuna> listarComunasPorIdProvincia(Integer idProvincia) {
		List<Comuna> listarComunas = new ArrayList<Comuna>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_REGIONES.SP_LISTAR_COMUNAS_POR_PROV", Comuna.class);
			procedureQuery.registerStoredProcedureParameter("PN_PROVINCIA_ID", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_COMUNAS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_PROVINCIA_ID", idProvincia);
			procedureQuery.execute();
			listarComunas = procedureQuery.getResultList();
		}catch(EntityNotFoundException e){
			listarComunas = null;
		}
		return listarComunas;
	}

}
