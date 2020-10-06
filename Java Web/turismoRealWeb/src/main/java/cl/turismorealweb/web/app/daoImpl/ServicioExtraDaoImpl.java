package cl.turismorealweb.web.app.daoImpl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.ServicioExtraDao;
import cl.turismorealweb.web.app.entitie.ServicioExtra;

@Transactional
@Repository
public class ServicioExtraDaoImpl implements ServicioExtraDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<ServicioExtra> listarServiciosExtras() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_SERVI_EXTRAS", ServicioExtra.class);
		procedureQuery.registerStoredProcedureParameter("CUR_SERVI_EXTRA", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public ServicioExtra listarServicioPorId(int idServicio) {
		ServicioExtra tipoPago = null;
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_SERVI_EXTRA_POR_ID", ServicioExtra.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_SERVICIO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_SERVI_EXTRA", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_SERVICIO", idServicio);
			procedureQuery.execute();
			return tipoPago = (ServicioExtra) procedureQuery.getSingleResult();
		}catch(NoResultException e){
			return tipoPago;
		}
		catch(Exception e){
			return tipoPago;
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<ServicioExtra> listarServiciosExtraPorPropiedad(int idPropiedad) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_SERVI_EXTRA_POR_DEP", ServicioExtra.class);
		procedureQuery.registerStoredProcedureParameter("PN_PROPIEDAD_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("CUR_SERVI_EXTRA", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.setParameter("PN_PROPIEDAD_ID", idPropiedad);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public String crearServicio(ServicioExtra servicioExtra) {
		String resultado = "";
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_CREAR_SERVI_EXTRA", ServicioExtra.class);
			procedureQuery.registerStoredProcedureParameter("PS_DESCRIPCION_SERVICIO", String.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_VALOR_SERVICIO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_CANTIDAD_PERSONAS", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_VALOR_TOTAL_SERVICIO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_ESTADO_SERVICIO_ID", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_PROPIEDAD_ID", Integer.class, ParameterMode.IN);	
			procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
			
			procedureQuery.setParameter("PS_DESCRIPCION_SERVICIO", servicioExtra.getDescripcionServicio());
			procedureQuery.setParameter("PN_VALOR_SERVICIO", servicioExtra.getValorServicio());
			procedureQuery.setParameter("PN_CANTIDAD_PERSONAS", servicioExtra.getCantidadPersonas());
			procedureQuery.setParameter("PN_VALOR_TOTAL_SERVICIO", servicioExtra.getValorTotalServicio());
			procedureQuery.setParameter("PN_ESTADO_SERVICIO_ID", servicioExtra.getEstadoServicio().getIdEstadoServicio());
			procedureQuery.setParameter("PN_PROPIEDAD_ID", servicioExtra.getPropiedad().getIdPropiedad());
			procedureQuery.execute();
			resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		}catch(Exception e) {
			resultado =  e.getMessage();
		}
		return resultado;
	}

	@Override
	public String actualizarServicio(ServicioExtra servicioExtra) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String eliminarServicio(Integer idServicioExtra) {
		// TODO Auto-generated method stub
		return null;
	}

}
