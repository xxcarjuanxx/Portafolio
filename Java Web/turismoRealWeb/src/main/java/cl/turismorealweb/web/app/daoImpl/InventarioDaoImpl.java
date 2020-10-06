package cl.turismorealweb.web.app.daoImpl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.NoResultException;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.InventarioDao;
import cl.turismorealweb.web.app.entitie.Inventario;
import cl.turismorealweb.web.app.entitie.ServicioExtra;

@Transactional
@Repository
public class InventarioDaoImpl implements InventarioDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Inventario> listarInventarios() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_INVENTARIOS", Inventario.class);
		procedureQuery.registerStoredProcedureParameter("CUR_INVENTARIOS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public Inventario listarInventarioPorId(int idInventario) {
		Inventario tipoPago = null;
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_INVENTARIO_POR_ID", Inventario.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_INVENTARIO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_INVENTARIOS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_INVENTARIO", idInventario);
			procedureQuery.execute();
			return tipoPago = (Inventario) procedureQuery.getSingleResult();
		}catch(NoResultException e){
			return tipoPago;
		}
		catch(Exception e){
			return tipoPago;
		}
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Inventario> listarInventarioPorPropiedad(int idPropiedad) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_LISTAR_INVENTARIO_POR_DEPTO", Inventario.class);
		procedureQuery.registerStoredProcedureParameter("PN_ID_PROPIEDAD", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("CUR_INVENTARIOS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.setParameter("PN_ID_PROPIEDAD", idPropiedad);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public String crearInventario(Inventario inventario) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_SERVICIOS_EXTRA.SP_CREAR_INVENTARIO", ServicioExtra.class);
		procedureQuery.registerStoredProcedureParameter("PS_DESCRIPCION", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_VALOR", Integer.class, ParameterMode.IN);	
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PS_DESCRIPCION", inventario.getDescripcion());
		procedureQuery.setParameter("PN_VALOR", inventario.getValor());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

	@Override
	public String actualizarInventario(Inventario inventario) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String eliminarInventario(Integer idInventario) {
		// TODO Auto-generated method stub
		return null;
	}

}
