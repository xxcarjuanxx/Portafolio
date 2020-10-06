package cl.turismorealweb.web.app.models;

public class ProvinciaDto {

	private Integer idProvincia;	
	private String nombreProvincia;
	private Integer idRegion;
	
	
	public ProvinciaDto() {
		
	}
	
	public ProvinciaDto(Integer idProvincia, String nombreProvincia, Integer idRegion) {
		super();
		this.idProvincia = idProvincia;
		this.nombreProvincia = nombreProvincia;
		this.idRegion = idRegion;
	}
	
	public Integer getIdProvincia() {
		return idProvincia;
	}
	public void setIdProvincia(Integer idProvincia) {
		this.idProvincia = idProvincia;
	}
	public String getNombreProvincia() {
		return nombreProvincia;
	}
	public void setNombreProvincia(String nombreProvincia) {
		this.nombreProvincia = nombreProvincia;
	}
	public Integer getIdRegion() {
		return idRegion;
	}
	public void setIdRegion(Integer idRegion) {
		this.idRegion = idRegion;
	}
	
	@Override
	public String toString() {
		return "ProvinciaDto [idProvincia=" + idProvincia + ", nombreProvincia=" + nombreProvincia + ", idRegion="
				+ idRegion + "]";
	}		
}
