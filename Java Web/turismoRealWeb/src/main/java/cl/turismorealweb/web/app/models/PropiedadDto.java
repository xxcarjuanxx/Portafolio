package cl.turismorealweb.web.app.models;

public class PropiedadDto {

	private Integer idPropiedad;
	private String nombre;
	private String direccion;
	private String descripcionPropiedad;
	private Integer valorDia;
	private String orientacion;
	private String tamanio;
	private Integer piso;
	private Integer cantHuespedes;
	private Integer cantBanio;
	private Integer cantHabitaciones;
	private Integer anioEdificacion;
	private Integer comuna;
	private Integer estadoPropiedad;
	
	private Integer region;
	private Integer provincia;
	private String fotoPrincipal;
	
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
	public Integer getComuna() {
		return comuna;
	}
	public void setComuna(Integer comuna) {
		this.comuna = comuna;
	}
	public Integer getEstadoPropiedad() {
		return estadoPropiedad;
	}
	public void setEstadoPropiedad(Integer estadoPropiedad) {
		this.estadoPropiedad = estadoPropiedad;
	}
	public Integer getRegion() {
		return region;
	}
	public void setRegion(Integer region) {
		this.region = region;
	}
	public Integer getProvincia() {
		return provincia;
	}
	public void setProvincia(Integer provincia) {
		this.provincia = provincia;
	}
	public String getFotoPrincipal() {
		return fotoPrincipal;
	}
	public void setFotoPrincipal(String fotoPrincipal) {
		this.fotoPrincipal = fotoPrincipal;
	}
		
	@Override
	public String toString() {
		return "PropiedadDto [idPropiedad=" + idPropiedad + ", nombre=" + nombre + ", direccion=" + direccion
				+ ", descripcionPropiedad=" + descripcionPropiedad + ", valorDia=" + valorDia + ", orientacion="
				+ orientacion + ", tamanio=" + tamanio + ", piso=" + piso + ", cantHuespedes=" + cantHuespedes
				+ ", cantBanio=" + cantBanio + ", cantHabitaciones=" + cantHabitaciones + ", anioEdificacion="
				+ anioEdificacion + ", comuna=" + comuna + ", estadoPropiedad=" + estadoPropiedad + ", region=" + region
				+ ", provincia=" + provincia + ", fotoPrincipal=" + fotoPrincipal + "]";
	}
}