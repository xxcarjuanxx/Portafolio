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

import cl.turismorealweb.web.app.dao.UsuarioDao;
import cl.turismorealweb.web.app.entitie.Reserva;
import cl.turismorealweb.web.app.entitie.Rol;
import cl.turismorealweb.web.app.entitie.Usuario;

@Transactional
@Repository
public class UsuarioDaoImpl implements UsuarioDao{

	@PersistenceContext
    private EntityManager entityManager;
	
	@SuppressWarnings("unchecked")
	@Override
	public List<Usuario> listarUsuarios() {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_USUARIO.SP_LISTAR_USUARIOS", Usuario.class);
		procedureQuery.registerStoredProcedureParameter("CUR_USUARIOS", void.class, ParameterMode.REF_CURSOR);
		procedureQuery.execute();
		return procedureQuery.getResultList();
	}

	@Override
	public Usuario listaUsuarioPorRutyRol(Integer rut, Integer rol) {
		Usuario usuario = null;
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_USUARIO.SP_LISTAR_USUARIO_RUT_ROL", Usuario.class);
			procedureQuery.registerStoredProcedureParameter("PN_RUT_USUARIO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("PN_ROL_USUARIO", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_USUARIOS", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_RUT_USUARIO", rut);
			procedureQuery.setParameter("PN_ROL_USUARIO", rol);
			procedureQuery.execute();
			return usuario = (Usuario) procedureQuery.getSingleResult();
		}catch(NoResultException e){
			return usuario;
		}
		catch(Exception e){
			return usuario;
		}
	}

	@Override
	public String crearUsuario(Usuario usuario) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_USUARIO.SP_CREAR_USUARIO", Usuario.class);
		procedureQuery.registerStoredProcedureParameter("PN_RUT_USUARIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DV_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_NOMBRE_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_APELLIDOS_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DIRECCION_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_TELEFONO_USUARIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_EMAIL_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_PASSWORD_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_ROL_USUARIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PN_RUT_USUARIO", usuario.getRut());
		procedureQuery.setParameter("PS_DV_USUARIO", usuario.getDv());
		procedureQuery.setParameter("PS_NOMBRE_USUARIO", usuario.getNombre());
		procedureQuery.setParameter("PS_APELLIDOS_USUARIO", usuario.getApellidos());
		procedureQuery.setParameter("PS_DIRECCION_USUARIO", usuario.getDireccion());
		procedureQuery.setParameter("PN_TELEFONO_USUARIO", usuario.getTelefono());
		procedureQuery.setParameter("PS_EMAIL_USUARIO", usuario.getEmail());
		procedureQuery.setParameter("PS_PASSWORD_USUARIO", usuario.getPassword());
		procedureQuery.setParameter("PN_ROL_USUARIO", usuario.getRol().getIdRol());
		procedureQuery.execute();		
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");		
		return resultado;
	}

	@SuppressWarnings("unchecked")
	@Override
	public List<Rol> listarRoles() {
		List<Rol> listarRoles = new ArrayList<Rol>();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_USUARIO.SP_LISTAR_ROLES", Rol.class);
			procedureQuery.registerStoredProcedureParameter("CUR_ROLES", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.execute();
			listarRoles = procedureQuery.getResultList();
		}catch (Exception e) {
			listarRoles = null;
		}
		return listarRoles;
	}

	@Override
	public Rol listaRolPorID(Integer rol) {
		Rol rolUsuaio = new Rol();
		try {
			StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_USUARIO.SP_LISTAR_ROL_POR_ID", Rol.class);
			procedureQuery.registerStoredProcedureParameter("PN_ID_ROL", Integer.class, ParameterMode.IN);
			procedureQuery.registerStoredProcedureParameter("CUR_ROLES", void.class, ParameterMode.REF_CURSOR);
			procedureQuery.setParameter("PN_ID_ROL", rol);
			procedureQuery.execute();
			rolUsuaio = (Rol) procedureQuery.getSingleResult();
		}catch(EntityNotFoundException e){
			rolUsuaio = null;
		}catch(Exception e){
			rolUsuaio = null;
		}
		return rolUsuaio;
	}

	@Override
	public String actualizarUsuario(Usuario usuario) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_USUARIO.SP_ACTUALIZAR_USUARIO", Usuario.class);
		procedureQuery.registerStoredProcedureParameter("PN_RUT_USUARIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_ROL_USUARIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DV_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_NOMBRE_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_APELLIDOS_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_DIRECCION_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_TELEFONO_USUARIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_EMAIL_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_PASSWORD_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_ESTADO_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PN_RUT_USUARIO", usuario.getRut());
		procedureQuery.setParameter("PN_ROL_USUARIO", usuario.getRol().getIdRol());
		procedureQuery.setParameter("PS_DV_USUARIO", usuario.getDv());
		procedureQuery.setParameter("PS_NOMBRE_USUARIO", usuario.getNombre());
		procedureQuery.setParameter("PS_APELLIDOS_USUARIO", usuario.getApellidos());
		procedureQuery.setParameter("PS_DIRECCION_USUARIO", usuario.getDireccion());
		procedureQuery.setParameter("PN_TELEFONO_USUARIO", usuario.getTelefono());
		procedureQuery.setParameter("PS_EMAIL_USUARIO", usuario.getEmail());
		procedureQuery.setParameter("PS_PASSWORD_USUARIO", usuario.getPassword());
		procedureQuery.setParameter("PS_ESTADO_USUARIO", usuario.getEstado());		
		procedureQuery.execute();		
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");		
		return resultado;
	}

	@Override
	public String cambiarClaveUsuario(Integer rut, Integer rol, String password) {
		StoredProcedureQuery procedureQuery =  entityManager.createStoredProcedureQuery("PKG_USUARIO.SP_RECUPERAR_PASS_USUARIO", Usuario.class);
		procedureQuery.registerStoredProcedureParameter("PN_RUT_USUARIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PN_ROL_USUARIO", Integer.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("PS_PASSWORD_USUARIO", String.class, ParameterMode.IN);
		procedureQuery.registerStoredProcedureParameter("S_RESULTADO", String.class, ParameterMode.OUT);
		
		procedureQuery.setParameter("PN_RUT_USUARIO", rut);
		procedureQuery.setParameter("PN_ROL_USUARIO", rol);
		procedureQuery.setParameter("PS_PASSWORD_USUARIO", password);
		procedureQuery.execute();		
		String resultado = (String) procedureQuery.getOutputParameterValue("S_RESULTADO");		
		return resultado;
	}

}
