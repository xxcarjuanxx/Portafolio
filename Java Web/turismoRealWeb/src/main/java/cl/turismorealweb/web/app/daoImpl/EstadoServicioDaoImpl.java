package cl.turismorealweb.web.app.daoImpl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.EstadoPropiedadDao;
import cl.turismorealweb.web.app.dao.EstadoServicioDao;
import cl.turismorealweb.web.app.entitie.EstadoPropiedad;
import cl.turismorealweb.web.app.entitie.EstadoServicio;
import cl.turismorealweb.web.app.entitie.ServicioExtra;
import cl.turismorealweb.web.app.entitie.TipoPago;

@Transactional
@Repository
public class EstadoServicioDaoImpl implements EstadoServicioDao, EstadoPropiedadDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<EstadoServicio> listarEstadoServicio() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_ESTAD_SERVI", EstadoServicio.class);
		procedureQuery.registerStoredProcedureParameter("CUR_ESTADO_SERVICIOS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public EstadoServicio listarEstadoServicioPorId(int idEstadoServicio) {
		EstadoServicio estadoServicio = null;
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_TIPO_PAGO_POR_ID", EstadoServicio.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_ESTADO_SERVICIO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_ESTADO_SERVICIOS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_ESTADO_SERVICIO", idEstadoServicio);
			procedureQuery.execute();
			return estadoServicio = (EstadoServicio) procedureQuery.getSingleResult();
		}catch(NoResultException e){
			return estadoServicio;
		}
		catch(Exception e){
			return estadoServicio;
		}
	}

	@Override
	public String crearEstadoServicio(EstadoServicio estadoServicio) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_CREAR_ESTAD_SERVI", EstadoServicio.class);
		procedureQuery.registerStoredProcedureParameter("PS_NOMBRE_ESTADO_SERVICIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DESCRIPCION_ESTADO_SERVI", String.class, ParameterMode.IN);	
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PS_NOMBRE_ESTADO_SERVICIO", estadoServicio.getNombreEstadoServicio());
		procedureQuery.setParameter("PS_DESCRIPCION_ESTADO_SERVI", estadoServicio.getDescripcionEstadoServicio());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

	@Override
	public String actualizarEstadoServicio(EstadoServicio estadoServicio) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String eliminarEstadoServicio(Integer idEstadoServicio) {
		// TODO Auto-generated method stub
		return null;
	}

	
	
	@SuppressWarnings("unchecked")
	@Override
	public List<EstadoPropiedad> listarEstadosPropiedad() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_ESTADOS_PROPIEDAD", EstadoPropiedad.class);
		procedureQuery.registerStoredProcedureParameter("CUR_ESTADOS_PROPIEDAD", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public EstadoPropiedad listarEstadoPropiedadPorId(int idEstadoPropiedad) {
		EstadoPropiedad estadoPropiedad = null;
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_ESTADO_PROP_POR_ID", EstadoPropiedad.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_ESTADO_PROPIEDAD", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_ESTADOS_PROPIEDAD", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_ESTADO_PROPIEDAD", idEstadoPropiedad);
			procedureQuery.execute();
			return estadoPropiedad = (EstadoPropiedad) procedureQuery.getSingleResult();
		}catch(NoResultException e){
			return estadoPropiedad;
		}
		catch(Exception e){
			return estadoPropiedad;
		}
	}

	@Override
	public String crearEstadoPropiedad(EstadoPropiedad estadoPropiedad) {
		String resultado = "";
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_CREAR_ESTADO_PROPIEDAD", EstadoPropiedad.class);
			procedureQuery.registerStoredProcedureParameter("PS_DESCRIPCION_ESTADO", String.class, ParameterMode.IN);	
			procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
			
			procedureQuery.setParameter("PS_DESCRIPCION_ESTADO", estadoPropiedad.getDescripcionEstado());
			procedureQuery.execute();
			resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		}catch(Exception e) {
			resultado =  e.getMessage();
		}
		return resultado;
	}

	@Override
	public String actualizarEstadoPropiedad(EstadoPropiedad estadoPropiedad) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String eliminarEstadoPropiedad(Integer idEstadoPropiedad) {
		// TODO Auto-generated method stub
		return null;
	}

}
