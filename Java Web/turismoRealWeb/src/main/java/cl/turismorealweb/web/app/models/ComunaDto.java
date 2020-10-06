package cl.turismorealweb.web.app.models;

public class ComunaDto {

	private Integer idComuna;
	private String nombreComuna;
	private Integer provincia;
	
	public Integer getIdComuna() {
		return idComuna;
	}
	public void setIdComuna(Integer idComuna) {
		this.idComuna = idComuna;
	}
	public String getNombreComuna() {
		return nombreComuna;
	}
	public void setNombreComuna(String nombreComuna) {
		this.nombreComuna = nombreComuna;
	}
	public Integer getProvincia() {
		return provincia;
	}
	public void setProvincia(Integer provincia) {
		this.provincia = provincia;
	}
	
	@Override
	public String toString() {
		return "ComunaDto [idComuna=" + idComuna + ", nombreComuna=" + nombreComuna + ", provincia=" + provincia + "]";
	}
}
