package cl.turismorealweb.web.app.daoImpl;

import java.sql.Blob;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityNotFoundException;
import javax.persistence.ParameterMode;
import javax.persistence.PersistenceContext;
import javax.persistence.StoredProcedureQuery;
import javax.transaction.Transactional;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.dao.FotoPropiedadDao;
import cl.turismorealweb.web.app.entitie.FotoPropiedad;
import cl.turismorealweb.web.app.entitie.Propiedad;
import cl.turismorealweb.web.app.entitie.Usuario;

@Transactional
@Repository
public class FotoPropiedadDaoImpl implements FotoPropiedadDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<FotoPropiedad> listarFotoPropiedadPorIdPropiedad(int idPropiedad) {
		List<FotoPropiedad> listarFotosPropiedad = new ArrayList<FotoPropiedad>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_LISTAR_FOTO_POR_PROPIEDAD", FotoPropiedad.class);
			procedureQuery.registerStoredProcedureParameter("PN_PROPIEDAD_ID", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_FOTOS_PROPIEDAD", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_PROPIEDAD_ID", idPropiedad);
			procedureQuery.execute();
			listarFotosPropiedad = procedureQuery.getResultList();
		}catch(EntityNotFoundException e){
			listarFotosPropiedad = null;
		}
		return listarFotosPropiedad;
	}

	@Override
	public FotoPropiedad listarFotoPropiedadPorId(int idFotoPropiedad) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_LISTAR_FOTO_POR_ID", FotoPropiedad.class);
		procedureQuery.registerStoredProcedureParameter("PN_ID_FOTO_PROPIEDAD", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("CUR_FOTOS_PROPIEDAD", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.setParameter("PN_ID_FOTO_PROPIEDAD", idFotoPropiedad);
		procedureQuery.execute();
		return (FotoPropiedad) procedureQuery.getSingleResult();
	}

	@Override
	public String crearFotoPropiedad(FotoPropiedad fotoPropiedad) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_CREAR_FOTO_PROPIEDAD", FotoPropiedad.class);
		//procedureQuery.registerStoredProcedureParameter("PS_NOMBRE_IMAGEN", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_IMAGEN_PROPIEDAD", String.class, ParameterMode.IN);			
		procedureQuery.registerStoredProcedureParameter("PN_PROPIEDAD_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		//procedureQuery.setParameter("PS_NOMBRE_IMAGEN", fotoPropiedad.getNombreImagen());
		procedureQuery.setParameter("PS_IMAGEN_PROPIEDAD", fotoPropiedad.getImagenPropiedad());
		procedureQuery.setParameter("PN_PROPIEDAD_ID", fotoPropiedad.getPopiedadFoto().getIdPropiedad());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

	@Override
	public String actualizarFotoPropiedad(FotoPropiedad fotoPropiedad) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_PROPIEDAD.SP_ACTUALIZAR_FOTO_PROPIEDAD", Usuario.class);
		procedureQuery.registerStoredProcedureParameter("PN_ID_FOTO_PROPIEDAD", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_IMAGEN_PROPIEDAD", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_PROPIEDAD_ID", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		procedureQuery.setParameter("PN_ID_FOTO_PROPIEDAD", fotoPropiedad.getIdFotoPropiedad());
		procedureQuery.setParameter("PS_IMAGEN_PROPIEDAD", fotoPropiedad.getImagenPropiedad());
		procedureQuery.setParameter("PN_PROPIEDAD_ID", fotoPropiedad.getPopiedadFoto());
		procedureQuery.execute();
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");
		return resultado;
	}

}
