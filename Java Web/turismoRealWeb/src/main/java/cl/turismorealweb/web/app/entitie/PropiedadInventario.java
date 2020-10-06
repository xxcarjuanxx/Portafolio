package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

@Entity
@Table(name="PROPIEDAD_INVENTARIO")
public class PropiedadInventario implements Serializable{

	private static final long serialVersionUID = 1909353721828369359L;

	@Id
	@ManyToOne
	@JoinColumn(name = "PROPIEDAD_ID")
	private Propiedad propiedadInventario;
	
	@Id
	@ManyToOne
	@JoinColumn(name = "INVENTARIO_ID")
	private Inventario inventario;
	
	private Integer cantidad;
	
	@Column(name="FECHA_ASIGNACION")
	private Date fechaAsignacion;

	public Propiedad getPropiedadInventario() {
		return propiedadInventario;
	}

	public void setPropiedadInventario(Propiedad propiedadInventario) {
		this.propiedadInventario = propiedadInventario;
	}

	public Inventario getInventario() {
		return inventario;
	}

	public void setInventario(Inventario inventario) {
		this.inventario = inventario;
	}

	public Integer getCantidad() {
		return cantidad;
	}

	public void setCantidad(Integer cantidad) {
		this.cantidad = cantidad;
	}

	public Date getFechaAsignacion() {
		return fechaAsignacion;
	}

	public void setFechaAsignacion(Date fechaAsignacion) {
		this.fechaAsignacion = fechaAsignacion;
	}

	@Override
	public String toString() {
		return "PropiedadInventario [propiedadInventario=" + propiedadInventario + ", inventario=" + inventario
				+ ", cantidad=" + cantidad + ", fechaAsignacion=" + fechaAsignacion + "]";
	}	
}
