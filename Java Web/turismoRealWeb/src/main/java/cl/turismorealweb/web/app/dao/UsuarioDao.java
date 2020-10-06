package cl.turismorealweb.web.app.dao;

import java.util.List;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.entitie.Rol;
import cl.turismorealweb.web.app.entitie.Usuario;

@Repository
public interface UsuarioDao {

	public List<Usuario> listarUsuarios();
	public Usuario listaUsuarioPorRutyRol(Integer rut, Integer rol);
	public String crearUsuario(Usuario usuario);
	public String actualizarUsuario(Usuario usuario);
	public String cambiarClaveUsuario(Integer rut, Integer rol, String password);
	public List<Rol> listarRoles();
	public Rol listaRolPorID(Integer rol);
}
