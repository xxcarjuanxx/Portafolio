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
@Table(name="ESTADO_SERVICIO")
public class EstadoServicio implements Serializable{

	private static final long serialVersionUID = -8272155102421247155L;
	
	@Column(name="ID_ESTADO_SERVICIO")
	@Id
	@GeneratedValue
	private Integer idEstadoServicio;
	
	@Column(name="NOMBRE_ESTADO_SERVICIO")
	private String nombreEstadoServicio;
	
	@Column(name="DESCRIPCION_ESTADO_SERVICIO")
	private String descripcionEstadoServicio;
	
	@OneToMany(mappedBy="estadoServicio")
	private List<ServicioExtra> servicioExtra;

	public Integer getIdEstadoServicio() {
		return idEstadoServicio;
	}

	public void setIdEstadoServicio(Integer idEstadoServicio) {
		this.idEstadoServicio = idEstadoServicio;
	}

	public String getNombreEstadoServicio() {
		return nombreEstadoServicio;
	}

	public void setNombreEstadoServicio(String nombreEstadoServicio) {
		this.nombreEstadoServicio = nombreEstadoServicio;
	}

	public String getDescripcionEstadoServicio() {
		return descripcionEstadoServicio;
	}

	public void setDescripcionEstadoServicio(String descripcionEstadoServicio) {
		this.descripcionEstadoServicio = descripcionEstadoServicio;
	}

	public List<ServicioExtra> getServicioExtra() {
		return servicioExtra;
	}

	public void setServicioExtra(List<ServicioExtra> servicioExtra) {
		this.servicioExtra = servicioExtra;
	}

	@Override
	public String toString() {
		return "EstadoServicio [idEstadoServicio=" + idEstadoServicio + ", nombreEstadoServicio=" + nombreEstadoServicio
				+ ", descripcionEstadoServicio=" + descripcionEstadoServicio + ", servicioExtra=" + servicioExtra + "]";
	}
}
