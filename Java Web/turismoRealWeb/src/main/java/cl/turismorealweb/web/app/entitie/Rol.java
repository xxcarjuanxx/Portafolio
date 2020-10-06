package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;

@Entity
public class Rol implements Serializable{

	private static final long serialVersionUID = 3389211535357104123L;

	@Column(name="ID_ROL")
	@Id
	@GeneratedValue
	private Integer idRol;
	
	@Column(name="DESCRIPCION_ROL")
	private String descripcionRol;

	@OneToMany(mappedBy="rol")
	private List<Usuario> usuario;
	
	public Integer getIdRol() {
		return idRol;
	}

	public void setIdRol(Integer idRol) {
		this.idRol = idRol;
	}

	public String getDescripcionRol() {
		return descripcionRol;
	}

	public void setDescripcionRol(String descripcionRol) {
		this.descripcionRol = descripcionRol;
	}
		
	public List<Usuario> getUsuario() {
		return usuario;
	}

	public void setUsuario(List<Usuario> usuario) {
		this.usuario = usuario;
	}

	@Override
	public String toString() {
		return "Rol [idRol=" + idRol + ", descripcionRol=" + descripcionRol + ", usuario=" + usuario + "]";
	}		
}
