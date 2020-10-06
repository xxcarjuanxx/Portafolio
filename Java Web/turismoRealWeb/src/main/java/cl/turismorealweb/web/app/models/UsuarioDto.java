package cl.turismorealweb.web.app.models;

import cl.turismorealweb.web.app.entitie.Rol;
import cl.turismorealweb.web.app.entitie.Usuario;

public class UsuarioDto {
	private String rut;
	private String dv;
	private String nombre;
	private String apellidos;
	private String direccion;
	private Integer telefono;
	private String email;
	private String password;
	private String estado;
	private RolDto rol;
	
	public UsuarioDto() {}
	
	public UsuarioDto(Usuario u) {
		this.rut = String.valueOf(u.getRut());
		this.dv = u.getDv();
		this.nombre = u.getNombre();
		this.apellidos = u.getApellidos();
		this.direccion = u.getDireccion();
		this.telefono = u.getTelefono();
		this.email = u.getEmail();
		this.password = u.getPassword();
		this.estado = u.getEstado();
		this.rol = new RolDto(new Rol());
	}
	public String getRut() {
		return rut;
	}
	public void setRut(String rut) {
		this.rut = rut;
	}
	public String getDv() {
		return dv;
	}
	public void setDv(String dv) {
		this.dv = dv;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public String getApellidos() {
		return apellidos;
	}
	public void setApellidos(String apellidos) {
		this.apellidos = apellidos;
	}
	public String getDireccion() {
		return direccion;
	}
	public void setDireccion(String direccion) {
		this.direccion = direccion;
	}
	public Integer getTelefono() {
		return telefono;
	}
	public void setTelefono(Integer telefono) {
		this.telefono = telefono;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public String getEstado() {
		return estado;
	}
	public void setEstado(String estado) {
		this.estado = estado;
	}
	public RolDto getRol() {
		return rol;
	}
	public void setRol(RolDto rol) {
		this.rol = rol;
	}
}