package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;

@Entity
public class Usuario implements Serializable {

	private static final long serialVersionUID = -6306032689245062606L;

	@Column(name = "RUT_USUARIO")
	@Id
	@GeneratedValue
	private Integer rut;

	@Column(name = "DV_USUARIO")
	private String dv;

	@Column(name = "NOMBRE_USUARIO")
	private String nombre;

	@Column(name = "APELLIDOS_USUARIO")
	private String apellidos;

	@Column(name = "DIRECCION_USUARIO")
	private String direccion;

	@Column(name = "TELEFONO_USUARIO")
	private Integer telefono;

	@Column(name = "EMAIL_USUARIO")
	private String email;

	@Column(name = "PASSWORD_USUARIO")
	private String password;

	@Column(name = "ESTADO")
	private String estado;

	// @Id
	@ManyToOne
	@JoinColumn(name = "ROL_USUARIO")
	private Rol rol;

	@OneToMany(mappedBy="usuario")
	private List<Reserva> reserva;
	
	public Integer getRut() {
		return rut;
	}

	public void setRut(Integer rut) {
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

	public Rol getRol() {
		return rol;
	}

	public void setRol(Rol rol) {
		this.rol = rol;
	}

	@Override
	public String toString() {
		return "Usuario [rut=" + rut + ", dv=" + dv + ", nombre=" + nombre + ", apellidos=" + apellidos + ", direccion="
				+ direccion + ", telefono=" + telefono + ", email=" + email + ", password=" + password + ", estado="
				+ estado + ", rol=" + rol + "]";
	}
}
