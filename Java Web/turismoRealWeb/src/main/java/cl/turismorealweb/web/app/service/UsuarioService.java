package cl.turismorealweb.web.app.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.turismorealweb.web.app.dao.UsuarioDao;
import cl.turismorealweb.web.app.entitie.Rol;
import cl.turismorealweb.web.app.entitie.Usuario;

@Service
public class UsuarioService {

	@Autowired
	private UsuarioDao usuarioDao;
	
	public List<Usuario> listarUsuarios() {
		return usuarioDao.listarUsuarios();
	}
	
	public Usuario listaUsuarioPorRutyRol(Integer rut, Integer rol) {
		return usuarioDao.listaUsuarioPorRutyRol(rut, rol);
	}
	
	public String crearUsuario(Usuario usuario) {
		return usuarioDao.crearUsuario(usuario);
	}
	
	public List<Rol> listarRoles() {
		return usuarioDao.listarRoles();
	}
	
	public Rol listaRolPorID(Integer rol) {
		return usuarioDao.listaRolPorID(rol);
	}
	
	public String actualizarUsuario(Usuario usuario) {
		return usuarioDao.actualizarUsuario(usuario);
	}
	
	public String cambiarClaveUsuario(Integer rut, Integer rol, String password) {
		return usuarioDao.cambiarClaveUsuario(rut, rol, password);
	}
}