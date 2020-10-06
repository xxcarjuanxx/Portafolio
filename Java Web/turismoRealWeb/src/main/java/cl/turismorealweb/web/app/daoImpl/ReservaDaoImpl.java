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

import cl.turismorealweb.web.app.dao.ReservaDao;
import cl.turismorealweb.web.app.entitie.Reserva;

@Transactional
@Repository
public class ReservaDaoImpl implements ReservaDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Reserva> listarReservas() {
		List<Reserva> listarReservas = new ArrayList<Reserva>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_RESERVA.SP_LISTAR_RESERVAS", Reserva.class);
			procedureQuery.registerStoredProcedureParameter("CUR_RESERVAS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.execute();
			listarReservas = procedureQuery.getResultList();
		}catch(EntityNotFoundException e){
			listarReservas = null;
		}catch(Exception e){
			listarReservas = null;
		}
		return listarReservas;
	}

	@Override
	public Reserva listarReservaPorId(int idReserva) {
		Reserva reserva = new Reserva();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_RESERVA.SP_LISTAR_RESERVA_POR_ID", Reserva.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_RESERVA", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_RESERVAS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_RESERVA", idReserva);
			procedureQuery.execute();
			reserva = (Reserva) procedureQuery.getSingleResult();
		}catch(EntityNotFoundException e){
			reserva = null;
		}catch(Exception e){
			reserva = null;
		}
		return reserva;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Reserva> listarReservaPorRutUsuario(int rutUsuario) {
		List<Reserva> listarReservas = new ArrayList<Reserva>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_RESERVA.SP_LISTAR_RESERVAS_POR_USUARIO", Reserva.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_USUARIO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_RESERVAS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_USUARIO", rutUsuario);
			procedureQuery.execute();
			listarReservas = procedureQuery.getResultList();
		}catch(EntityNotFoundException e){
			listarReservas = null;
		}
		return listarReservas;
	}

	@Override
	public String crearReserva(Reserva reserva) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_RESERVA.SP_CREAR_RESERVA", Reserva.class);
		procedureQuery.registerStoredProcedureParameter("PN_CANTIDAD_PERSONAS", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANTIDAD_DIAS", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_FECHA_ENTRADA", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_FECHA_SALIDA", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_MONTO_ACTICIPO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_MONTO_A_PAGAR", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_MONTO_TOTAL", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_ESTADO_RESERVA", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_PROPIEDAD_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_TIPO_PAGO_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_USUARIO_RUT", Integer.class, ParameterMode.IN);		
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PN_CANTIDAD_PERSONAS", reserva.getCantidadPersonas());
		procedureQuery.setParameter("PN_CANTIDAD_DIAS", reserva.getCantidadDias());
		procedureQuery.setParameter("PS_FECHA_ENTRADA", reserva.getFechaEntrada());
		procedureQuery.setParameter("PS_FECHA_SALIDA", reserva.getFechaSalida());
		procedureQuery.setParameter("PN_MONTO_ACTICIPO", reserva.getMontoAnticipo());
		procedureQuery.setParameter("PN_MONTO_A_PAGAR", reserva.getMontoaPagar());
		procedureQuery.setParameter("PN_MONTO_TOTAL", reserva.getMontoTotal());
		procedureQuery.setParameter("PS_ESTADO_RESERVA", reserva.getEstadoReserva());
		procedureQuery.setParameter("PN_PROPIEDAD_ID", reserva.getPropiedad().getIdPropiedad());
		procedureQuery.setParameter("PN_TIPO_PAGO_ID", reserva.getTipoPago().getIdTipoPago());
		procedureQuery.setParameter("PN_USUARIO_RUT", reserva.getUsuario().getRut());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

	@Override
	public String actualizarReserva(Reserva reserva) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_RESERVA.SP_ACTUALIZAR_RESERVA", Reserva.class);
		procedureQuery.registerStoredProcedureParameter("PN_ID_RESERVA", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANTIDAD_PERSONAS", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_CANTIDAD_DIAS", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_FECHA_ENTRADA", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_FECHA_SALIDA", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_MONTO_ACTICIPO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_MONTO_A_PAGAR", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_MONTO_TOTAL", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_ESTADO_RESERVA", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_PROPIEDAD_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_TIPO_PAGO_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_USUARIO_RUT", Integer.class, ParameterMode.IN);		
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PN_ID_RESERVA", reserva.getIdReserva());
		procedureQuery.setParameter("PN_CANTIDAD_PERSONAS", reserva.getCantidadPersonas());
		procedureQuery.setParameter("PN_CANTIDAD_DIAS", reserva.getCantidadDias());
		procedureQuery.setParameter("PS_FECHA_ENTRADA", reserva.getFechaEntrada());
		procedureQuery.setParameter("PS_FECHA_SALIDA", reserva.getFechaSalida());
		procedureQuery.setParameter("PN_MONTO_ACTICIPO", reserva.getMontoAnticipo());
		procedureQuery.setParameter("PN_MONTO_A_PAGAR", reserva.getMontoaPagar());
		procedureQuery.setParameter("PN_MONTO_TOTAL", reserva.getMontoTotal());
		procedureQuery.setParameter("PS_ESTADO_RESERVA", reserva.getEstadoReserva());
		procedureQuery.setParameter("PN_PROPIEDAD_ID", reserva.getPropiedad().getIdPropiedad());
		procedureQuery.setParameter("PN_TIPO_PAGO_ID", reserva.getTipoPago().getIdTipoPago());
		procedureQuery.setParameter("PN_USUARIO_RUT", reserva.getUsuario().getRut());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

	@Override
	public String cancelarReserva(Reserva reserva) {
		// TODO Auto-generated method stub
		return null;
	}

}
