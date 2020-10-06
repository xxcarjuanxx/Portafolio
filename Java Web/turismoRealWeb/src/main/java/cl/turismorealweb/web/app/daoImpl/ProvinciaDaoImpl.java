package cl.turismorealweb.web.app.daoImpl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.ProvinciaDao;
import cl.turismorealweb.web.app.entitie.Provincia;

@Transactional
@Repository
public class ProvinciaDaoImpl implements ProvinciaDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Provincia> listarProvincias() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_REGIONES.SP_LISTAR_PROVINCIAS", Provincia.class);
		procedureQuery.registerStoredProcedureParameter("CUR_PROVINCIAS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public Provincia listarProvinciaPorId(Integer idProvincia) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_REGIONES.SP_LISTAR_REGION_POR_ID", Provincia.class);
		procedureQuery.registerStoredProcedureParameter("PN_ID_PROVINCIA", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("CUR_PROVINCIAS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.setParameter("PN_ID_PROVINCIA", idProvincia);
		procedureQuery.execute();
		return (Provincia) procedureQuery.getSingleResult();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Provincia> listarProvinciasPorIdRegion(Integer idRegion) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_REGIONES.SP_LISTAR_PROVINCIAS_POR_REGI", Provincia.class);
		procedureQuery.registerStoredProcedureParameter("PN_REGION_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("CUR_PROVINCIAS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.setParameter("PN_REGION_ID", idRegion);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

}
