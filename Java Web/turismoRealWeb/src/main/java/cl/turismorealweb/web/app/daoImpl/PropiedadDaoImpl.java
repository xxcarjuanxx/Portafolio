package cl.turismorealweb.web.app.daoImpl;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityNotFoundException;
import javax.persistence.NoResultException;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.PropiedadDao;
import cl.turismorealweb.web.app.entitie.Comuna;
import cl.turismorealweb.web.app.entitie.EstadoPropiedad;
import cl.turismorealweb.web.app.entitie.Propiedad;
import cl.turismorealweb.web.app.entitie.Usuario;

@Transactional
@Repository
public class PropiedadDaoImpl implements PropiedadDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Propiedad> listarPropiedades() {
		List<Propiedad> listarPropiedades = new ArrayList<Propiedad>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_LISTAR_PROPIEDADES", Propiedad.class);
			procedureQuery.registerStoredProcedureParameter("CUR_PROPIEDADES", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.execute();
			listarPropiedades = procedureQuery.getResultList();
		}catch(EntityNotFoundException e){
			listarPropiedades = null;
		}
		return listarPropiedades;
	}

	@Override
	public Propiedad listarPropiedadPorId(int idPropiedad) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_LISTAR_PROPIEDAD_POR_ID", Propiedad.class);
		procedureQuery.registerStoredProcedureParameter("PN_ID_PRPOIEDAD", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("CUR_PROPIEDADES", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.setParameter("PN_ID_PRPOIEDAD", idPropiedad);
		procedureQuery.execute();
		return (Propiedad) procedureQuery.getSingleResult();
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Propiedad> listarPropiedadPorComuna(int idComuna) {
		List<Propiedad> listarPropiedades = new ArrayList<Propiedad>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_LISTAR_PROPIEDADES_POR_COMU", Propiedad.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_COMUNA", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_PROPIEDADES", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_COMUNA", idComuna);
			procedureQuery.execute();
			listarPropiedades = procedureQuery.getResultList();
		}catch(EntityNotFoundException e){
			listarPropiedades = null;
		}
		return listarPropiedades;
	}
	
	@Override
	public String crearPropiedad(Propiedad propiedad) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_CREAR_PROPIEDAD", Usuario.class);
		procedureQuery.registerStoredProcedureParameter("PS_NOMBRE", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DIRECCION", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DESCRIPCION_PROPIEDAD", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_VALOR_DIA", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_ORIENTACION", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_TAMANIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_PISO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANT_HUESPEDES", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANT_BANIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANT_HABITACIONES", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_ANIO_EDIFICACION", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_COMUNA_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_ESTADO_PROPIEDAD_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_LATITUD", Double.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_LONGITUD", Double.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PS_NOMBRE", propiedad.getNombre());
		procedureQuery.setParameter("PS_DIRECCION", propiedad.getDireccion());
		procedureQuery.setParameter("PS_DESCRIPCION_PROPIEDAD", propiedad.getDescripcionPropiedad());
		procedureQuery.setParameter("PN_VALOR_DIA", propiedad.getValorDia());
		procedureQuery.setParameter("PS_ORIENTACION", propiedad.getOrientacion());
		procedureQuery.setParameter("PS_TAMANIO", propiedad.getTamanio());
		procedureQuery.setParameter("PN_PISO", propiedad.getPiso());
		procedureQuery.setParameter("PN_CANT_HUESPEDES", propiedad.getCantHuespedes());
		procedureQuery.setParameter("PN_CANT_BANIO", propiedad.getCantBanio());
		procedureQuery.setParameter("PN_CANT_HABITACIONES", propiedad.getCantHabitaciones());
		procedureQuery.setParameter("PN_ANIO_EDIFICACION", propiedad.getAnioEdificacion());
		procedureQuery.setParameter("PN_COMUNA_ID", propiedad.getComuna().getIdComuna());
		procedureQuery.setParameter("PN_ESTADO_PROPIEDAD_ID", propiedad.getEstadoPropiedad().getIdEstadoPropiedad());
		procedureQuery.setParameter("PN_LATITUD", propiedad.getLatitud());
		procedureQuery.setParameter("PN_LONGITUD", propiedad.getLongitud());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

	@Override
	public String actualizarPropiedad(Propiedad propiedad) {
		
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_CREAR_PROPIEDAD", Usuario.class);
		procedureQuery.registerStoredProcedureParameter("PN_ID_PROPIEDAD", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_NOMBRE", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DIRECCION", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DESCRIPCION_PROPIEDAD", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_VALOR_DIA", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_ORIENTACION", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_TAMANIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_PISO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANT_HUESPEDES", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANT_BANIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANT_HABITACIONES", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_ANIO_EDIFICACION", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_COMUNA_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_ESTADO_PROPIEDAD_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PN_ID_PROPIEDAD", propiedad.getIdPropiedad());
		procedureQuery.setParameter("PS_NOMBRE", propiedad.getNombre());
		procedureQuery.setParameter("PS_DIRECCION", propiedad.getDireccion());
		procedureQuery.setParameter("PS_DESCRIPCION_PROPIEDAD", propiedad.getDescripcionPropiedad());
		procedureQuery.setParameter("PN_VALOR_DIA", propiedad.getValorDia());
		procedureQuery.setParameter("PS_ORIENTACION", propiedad.getOrientacion());
		procedureQuery.setParameter("PS_TAMANIO", propiedad.getTamanio());
		procedureQuery.setParameter("PN_PISO", propiedad.getPiso());
		procedureQuery.setParameter("PN_CANT_HUESPEDES", propiedad.getCantHuespedes());
		procedureQuery.setParameter("PN_CANT_BANIO", propiedad.getCantBanio());
		procedureQuery.setParameter("PN_CANT_HABITACIONES", propiedad.getCantHabitaciones());
		procedureQuery.setParameter("PN_ANIO_EDIFICACION", propiedad.getAnioEdificacion());
		procedureQuery.setParameter("PN_COMUNA_ID", propiedad.getComuna());
		procedureQuery.setParameter("PN_ESTADO_PROPIEDAD_ID", propiedad.getEstadoPropiedad());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

	@Override
	public String eliminarPropiedad(Integer idPropiedad) {
		// TODO Auto-generated method stub
		return null;
	}
	
	@SuppressWarnings("unchecked")
	@Override
	public List<EstadoPropiedad> listarEstadosPropiedades() {
		List<EstadoPropiedad> listarEstadosPropiedades = new ArrayList<EstadoPropiedad>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_LISTAR_ESTADO_PROPIEDAD", EstadoPropiedad.class);
			procedureQuery.registerStoredProcedureParameter("CUR_ESTADOS_PROPIEDAD", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.execute();
			listarEstadosPropiedades = procedureQuery.getResultList();
		}catch(EntityNotFoundException e){
			listarEstadosPropiedades = null;
		}
		return listarEstadosPropiedades;
	}
	
	@Override
	public String listarEstadosPropiedadPorId(int idPropiedad) {
		String descripcion = "";
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_LISTAR_ESTADO_PROPIEDAD_ID", String.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_ESTADO_PROPIEDAD", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PS_DESCRIPCION_ESTADO", String.class, ParameterMode.OUT);
			procedureQuery.setParameter("PN_ID_ESTADO_PROPIEDAD", idPropiedad);
			procedureQuery.execute();
			return  (String) procedureQuery.getSingleResult();
		}catch(NoResultException e){
			return descripcion;
		}
		catch(Exception e){
			return descripcion;
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Propiedad> listarPropiedadPorFiltro(int idRegion, int idProvincia, String fechaDesde, String fechaHasta,
			int cantHuespedes, int valor) {
		List<Propiedad> listarPropiedades = new ArrayList<Propiedad>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_FILTRO_DEPARTAMENTOS", Propiedad.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_REGION", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_ID_PROVINCIA", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PS_FECHA_DESDE", String.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PS_FECHA_HASTA", String.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_CANT_HUESPEDES", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_VALOR", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_PROPIEDADES", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_REGION", idRegion);
			procedureQuery.setParameter("PN_ID_PROVINCIA", idProvincia);
			procedureQuery.setParameter("PS_FECHA_DESDE", fechaDesde);
			procedureQuery.setParameter("PS_FECHA_HASTA", fechaHasta);
			procedureQuery.setParameter("PN_CANT_HUESPEDES", cantHuespedes);
			procedureQuery.setParameter("PN_VALOR", valor);
			procedureQuery.execute();
			listarPropiedades = procedureQuery.getResultList();
		}catch(EntityNotFoundException e){
			listarPropiedades = null;
		}
		return listarPropiedades;
	}

}