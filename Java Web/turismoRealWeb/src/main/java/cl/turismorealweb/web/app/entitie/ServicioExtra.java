package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

@Entity
@Table(name="SERVICIO_EXTRA")
public class ServicioExtra implements Serializable{

	private static final long serialVersionUID = 6349476915488500603L;
	
	@Column(name="ID_SERVICIO")
	@Id
	@GeneratedValue
	private Integer idServicioExtra;
	
	@Column(name="DESCRIPCION_SERVICIO")
	private String descripcionServicio;

	@Column(name="VALOR_SERVICIO")
	private Integer valorServicio;
	
	@Column(name="CANTIDAD_PERSONAS")
	private Integer cantidadPersonas;
	
	@Column(name="VALOR_TOTAL_SERVICIO")
	private Integer valorTotalServicio;
	
	@ManyToOne
	@JoinColumn(name = "ESTADO_SERVICIO_ID")
	private EstadoServicio estadoServicio;
	
	@ManyToOne
	@JoinColumn(name = "PROPIEDAD_ID")
	private Propiedad propiedad;

	public Integer getIdServicioExtra() {
		return idServicioExtra;
	}

	public void setIdServicioExtra(Integer idServicioExtra) {
		this.idServicioExtra = idServicioExtra;
	}

	public String getDescripcionServicio() {
		return descripcionServicio;
	}

	public void setDescripcionServicio(String descripcionServicio) {
		this.descripcionServicio = descripcionServicio;
	}

	public Integer getValorServicio() {
		return valorServicio;
	}

	public void setValorServicio(Integer valorServicio) {
		this.valorServicio = valorServicio;
	}

	public Integer getCantidadPersonas() {
		return cantidadPersonas;
	}

	public void setCantidadPersonas(Integer cantidadPersonas) {
		this.cantidadPersonas = cantidadPersonas;
	}

	public Integer getValorTotalServicio() {
		return valorTotalServicio;
	}

	public void setValorTotalServicio(Integer valorTotalServicio) {
		this.valorTotalServicio = valorTotalServicio;
	}

	public EstadoServicio getEstadoServicio() {
		return estadoServicio;
	}

	public void setEstadoServicio(EstadoServicio estadoServicio) {
		this.estadoServicio = estadoServicio;
	}

	public Propiedad getPropiedad() {
		return propiedad;
	}

	public void setPropiedad(Propiedad propiedad) {
		this.propiedad = propiedad;
	}

	@Override
	public String toString() {
		return "ServicioExtra [idServicioExtra=" + idServicioExtra + ", descripcionServicio=" + descripcionServicio
				+ ", valorServicio=" + valorServicio + ", cantidadPersonas=" + cantidadPersonas
				+ ", valorTotalServicio=" + valorTotalServicio + ", estadoServicio=" + estadoServicio + ", propiedad="
				+ propiedad + "]";
	}
}
