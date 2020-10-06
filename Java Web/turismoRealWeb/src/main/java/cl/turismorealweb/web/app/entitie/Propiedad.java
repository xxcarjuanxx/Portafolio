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
public class Propiedad implements Serializable{

	private static final long serialVersionUID = -3645055709505707855L;

	@Column(name="ID_PROPIEDAD")
	@Id
	@GeneratedValue
	private Integer idPropiedad;
	
	private String nombre;
	
	private String direccion;
	
	@Column(name="DESCRIPCION_PROPIEDAD")
	private String descripcionPropiedad;
	
	@Column(name="VALOR_DIA")
	private Integer valorDia;
	
	private String orientacion;
	
	private String tamanio;
	
	private double latitud;
	
	private double longitud;
	
	private Integer piso;
	
	@Column(name="CANT_HUESPEDES")
	private Integer cantHuespedes;
	
	@Column(name="CANT_BANIO")
	private Integer cantBanio;
	
	@Column(name="CANT_HABITACIONES")
	private Integer cantHabitaciones;
	
	@Column(name="ANIO_EDIFICACION")
	private Integer anioEdificacion;
	
	@ManyToOne
	@JoinColumn(name = "COMUNA_ID")/*Forein key*/
	private Comuna comuna;
	
	@ManyToOne
	@JoinColumn(name = "ESTADO_PROPIEDAD_ID")
	private EstadoPropiedad estadoPropiedad;
		
	@OneToMany(mappedBy="propiedadInventario")
	private List<PropiedadInventario> propiedadInventario;
	
	@OneToMany(mappedBy="popiedadFoto")
	private List<FotoPropiedad> fotoPropiedad;
	
	@OneToMany(mappedBy="propiedad")
	private List<ServicioExtra> servicioExtra;
	
	@OneToMany(mappedBy="propiedad")
	private List<Reserva> reserva;

	public Integer getIdPropiedad() {
		return idPropiedad;
	}

	public void setIdPropiedad(Integer idPropiedad) {
		this.idPropiedad = idPropiedad;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public String getDireccion() {
		return direccion;
	}

	public void setDireccion(String direccion) {
		this.direccion = direccion;
	}

	public String getDescripcionPropiedad() {
		return descripcionPropiedad;
	}

	public void setDescripcionPropiedad(String descripcionPropiedad) {
		this.descripcionPropiedad = descripcionPropiedad;
	}

	public Integer getValorDia() {
		return valorDia;
	}

	public void setValorDia(Integer valorDia) {
		this.valorDia = valorDia;
	}

	public String getOrientacion() {
		return orientacion;
	}

	public void setOrientacion(String orientacion) {
		this.orientacion = orientacion;
	}

	public String getTamanio() {
		return tamanio;
	}

	public void setTamanio(String tamanio) {
		this.tamanio = tamanio;
	}

	public Integer getPiso() {
		return piso;
	}

	public void setPiso(Integer piso) {
		this.piso = piso;
	}
	
	public double getLatitud() {
		return latitud;
	}

	public void setLatitud(double latitud) {
		this.latitud = latitud;
	}

	public double getLongitud() {
		return longitud;
	}

	public void setLongitud(double longitud) {
		this.longitud = longitud;
	}

	public Integer getCantHuespedes() {
		return cantHuespedes;
	}

	public void setCantHuespedes(Integer cantHuespedes) {
		this.cantHuespedes = cantHuespedes;
	}

	public Integer getCantBanio() {
		return cantBanio;
	}

	public void setCantBanio(Integer cantBanio) {
		this.cantBanio = cantBanio;
	}

	public Integer getCantHabitaciones() {
		return cantHabitaciones;
	}

	public void setCantHabitaciones(Integer cantHabitaciones) {
		this.cantHabitaciones = cantHabitaciones;
	}

	public Integer getAnioEdificacion() {
		return anioEdificacion;
	}

	public void setAnioEdificacion(Integer anioEdificacion) {
		this.anioEdificacion = anioEdificacion;
	}

	public Comuna getComuna() {
		return comuna;
	}

	public void setComuna(Comuna comuna) {
		this.comuna = comuna;
	}

	public EstadoPropiedad getEstadoPropiedad() {
		return estadoPropiedad;
	}

	public void setEstadoPropiedad(EstadoPropiedad estadoPropiedad) {
		this.estadoPropiedad = estadoPropiedad;
	}

	public List<PropiedadInventario> getPropiedadInventario() {
		return propiedadInventario;
	}

	public void setPropiedadInventario(List<PropiedadInventario> propiedadInventario) {
		this.propiedadInventario = propiedadInventario;
	}

	public List<FotoPropiedad> getFotoPropiedad() {
		return fotoPropiedad;
	}

	public void setFotoPropiedad(List<FotoPropiedad> fotoPropiedad) {
		this.fotoPropiedad = fotoPropiedad;
	}
	
	public List<ServicioExtra> getServicioExtra() {
		return servicioExtra;
	}

	public void setServicioExtra(List<ServicioExtra> servicioExtra) {
		this.servicioExtra = servicioExtra;
	}
	
	public List<Reserva> getReserva() {
		return reserva;
	}

	public void setReserva(List<Reserva> reserva) {
		this.reserva = reserva;
	}

	@Override
	public String toString() {
		return "Propiedad [idPropiedad=" + idPropiedad + ", nombre=" + nombre + ", direccion=" + direccion
				+ ", descripcionPropiedad=" + descripcionPropiedad + ", valorDia=" + valorDia + ", orientacion="
				+ orientacion + ", tamanio=" + tamanio + ", latitud=" + latitud + ", longitud=" + longitud + ", piso="
				+ piso + ", cantHuespedes=" + cantHuespedes + ", cantBanio=" + cantBanio + ", cantHabitaciones="
				+ cantHabitaciones + ", anioEdificacion=" + anioEdificacion + ", comuna=" + comuna
				+ ", estadoPropiedad=" + estadoPropiedad + ", propiedadInventario=" + propiedadInventario
				+ ", fotoPropiedad=" + fotoPropiedad + ", servicioExtra=" + servicioExtra + ", reserva=" + reserva
				+ "]";
	}		
}
