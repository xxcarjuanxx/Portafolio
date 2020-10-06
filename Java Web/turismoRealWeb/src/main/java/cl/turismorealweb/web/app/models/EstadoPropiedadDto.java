package cl.turismorealweb.web.app.models;

public class EstadoPropiedadDto {

	private Integer idEstadoPropiedad;
	private String descripcionEstado;
	
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
	
	@Override
	public String toString() {
		return "EstadoPropiedadDto [idEstadoPropiedad=" + idEstadoPropiedad + ", descripcionEstado=" + descripcionEstado
				+ "]";
	}
}
