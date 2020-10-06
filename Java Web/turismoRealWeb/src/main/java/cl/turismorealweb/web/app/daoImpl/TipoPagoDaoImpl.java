package cl.turismorealweb.web.app.daoImpl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.TipoPagoDao;
import cl.turismorealweb.web.app.entitie.ServicioExtra;
import cl.turismorealweb.web.app.entitie.TipoPago;

@Transactional
@Repository
public class TipoPagoDaoImpl implements TipoPagoDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<TipoPago> listarTiposPagos() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_TIPO_PAGO", TipoPago.class);
		procedureQuery.registerStoredProcedureParameter("CUR_TIPO_PAGO", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public TipoPago listarTipoPagoPorId(int idTipoPago) {
		TipoPago tipoPago = null;
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_TIPO_PAGO_POR_ID", TipoPago.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_TIPO_PAGO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_TIPO_PAGO", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_TIPO_PAGO", idTipoPago);
			procedureQuery.execute();
			return tipoPago = (TipoPago) procedureQuery.getSingleResult();
		}catch(NoResultException e){
			return tipoPago;
		}
		catch(Exception e){
			return tipoPago;
		}
	}

	@Override
	public String crearTipoPago(TipoPago tipoPago) {
		String resultado = "";
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_CREAR_TIPO_PAGO", TipoPago.class);
			procedureQuery.registerStoredProcedureParameter("PS_NOMBRE_TIPO_PAGO", String.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PS_ESTADO_TIPO_PAGO", String.class, ParameterMode.IN);	
			procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
			
			procedureQuery.setParameter("PS_NOMBRE_TIPO_PAGO", tipoPago.getNombreTipoPago());
			procedureQuery.setParameter("PS_ESTADO_TIPO_PAGO", tipoPago.getEstadoTipoPago());
			procedureQuery.execute();
			resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		}catch(Exception e) {
			resultado =  e.getMessage();
		}
		return resultado;
	}

	@Override
	public String actualizarTipoPago(TipoPago tipoPago) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String eliminarTipoPago(Integer idTipoPago) {
		// TODO Auto-generated method stub
		return null;
	}

}
