package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity
@Table(name="ESTADO_PROPIEDAD")
public class EstadoPropiedad implements Serializable{

	private static final long serialVersionUID = 6546602235026774463L;
	
	@Column(name="ID_ESTADO_PROPIEDAD")
	@Id
	@GeneratedValue
	private Integer idEstadoPropiedad;
	
	@Column(name="DESCRIPCION_ESTADO")
	private String descripcionEstado;

	@OneToMany(mappedBy="estadoPropiedad")
	private List<Propiedad> propiedad;

	public Integer getIdEstadoPropiedad() {
		return idEstadoPropiedad;
	}

	public void setIdEstadoPropiedad(Integer idEstadoPropiedad) {
		this.idEstadoPropiedad = idEstadoPropiedad;
	}

	public String getDescripcionEstado() {
		return descripcionEstado;
	}

	public void setDescripcionEstado(String descripcionEstado) {
		this.descripcionEstado = descripcionEstado;
	}

	public List<Propiedad> getPropiedad() {
		return propiedad;
	}

	public void setPropiedad(List<Propiedad> propiedad) {
		this.propiedad = propiedad;
	}

	@Override
	public String toString() {
		return "EstadoPropiedad [idEstadoPropiedad=" + idEstadoPropiedad + ", descripcionEstado=" + descripcionEstado
				+ ", propiedad=" + propiedad + "]";
	}		
}
