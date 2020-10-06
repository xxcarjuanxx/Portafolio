package cl.turismorealweb.web.app.daoImpl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.MultaDao;
import cl.turismorealweb.web.app.entitie.EstadoServicio;
import cl.turismorealweb.web.app.entitie.Multa;
import cl.turismorealweb.web.app.entitie.ServicioExtra;

@Transactional
@Repository
public class MultaDaoImpl implements MultaDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Multa> listarMultas() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_MULTAS", Multa.class);
		procedureQuery.registerStoredProcedureParameter("CUR_MULTAS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public Multa listarMultaPorId(int idMulta) {
		Multa multa = null;
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_MULTAS_POR_ID", Multa.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_MULTA", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_MULTAS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_MULTA", idMulta);
			procedureQuery.execute();
			return multa = (Multa) procedureQuery.getSingleResult();
		}catch(NoResultException e){
			return multa;
		}
		catch(Exception e){
			return multa;
		}
	}

	@Override
	public List<Multa> listarMultasPorPropiedad(int idPropiedad) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String crearMulta(Multa multa) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_CREAR_MULTA", EstadoServicio.class);
		procedureQuery.registerStoredProcedureParameter("PS_DESCRIPCION_MULTA", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_VALOR_MULTA", Integer.class, ParameterMode.IN);	
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PS_DESCRIPCION_MULTA", multa.getDescripcionMulta());
		procedureQuery.setParameter("PN_VALOR_MULTA", multa.getValorMulta());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

	@Override
	public String actualizarMulta(Multa multa) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String eliminarMulta(Integer idMulta) {
		// TODO Auto-generated method stub
		return null;
	}


}
