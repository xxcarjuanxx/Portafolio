package cl.turismorealweb.web.app.daoImpl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.RegionDao;
import cl.turismorealweb.web.app.entitie.Region;

@Transactional
@Repository
public class RegionDaoImpl implements RegionDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Region> listarRegiones() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_REGIONES.SP_LISTAR_REGIONES", Region.class);
		procedureQuery.registerStoredProcedureParameter("CUR_REGIONES", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public Region listarRegionPorId(Integer idRegion) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_REGIONES.SP_LISTAR_REGION_POR_ID", Region.class);
		procedureQuery.registerStoredProcedureParameter("PN_ID_REGION", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("CUR_REGIONES", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.setParameter("PN_ID_REGION", idRegion);
		procedureQuery.execute();
		return (Region) procedureQuery.getSingleResult();
	}

}
