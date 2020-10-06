package cl.turismorealweb.web.app.models;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;

@Component
public class DatosEmpresaDto {

	@Value("${application.controller.tituloEmpresa}")
	private String tituloEmpresa;
	
	@Value("${application.controller.emailEmpresa}")
	private String emailEmpresa;
	
	@Value("${application.controller.telefonolEmpresa}")
	private String telefonolEmpresa;
	
	@Value("${application.controller.direccionEmpresa}")
	private String direccionEmpresa;
	
	@Value("${application.controller.comunaEmpresa}")
	private String comunaEmpresa;
	
	@Value("${application.controller.regionEmpresa}")
	private String regionEmpresa;	
	
	public String getTituloEmpresa() {
		return tituloEmpresa;
	}
	public void setTituloEmpresa(String tituloEmpresa) {
		this.tituloEmpresa = tituloEmpresa;
	}
	public String getEmailEmpresa() {
		return emailEmpresa;
	}
	public void setEmailEmpresa(String emailEmpresa) {
		this.emailEmpresa = emailEmpresa;
	}
	public String getTelefonolEmpresa() {
		return telefonolEmpresa;
	}
	public void setTelefonolEmpresa(String telefonolEmpresa) {
		this.telefonolEmpresa = telefonolEmpresa;
	}
	public String getDireccionEmpresa() {
		return direccionEmpresa;
	}
	public void setDireccionEmpresa(String direccionEmpresa) {
		this.direccionEmpresa = direccionEmpresa;
	}
	public String getComunaEmpresa() {
		return comunaEmpresa;
	}
	public void setComunaEmpresa(String comunaEmpresa) {
		this.comunaEmpresa = comunaEmpresa;
	}
	public String getRegionEmpresa() {
		return regionEmpresa;
	}
	public void setRegionEmpresa(String regionEmpresa) {
		regionEmpresa = regionEmpresa;
	}
	
	@Override
	public String toString() {
		return "DatosEmpresaDto [tituloEmpresa=" + tituloEmpresa + ", emailEmpresa=" + emailEmpresa
				+ ", telefonolEmpresa=" + telefonolEmpresa + ", direccionEmpresa=" + direccionEmpresa
				+ ", comunaEmpresa=" + comunaEmpresa + ", regionEmpresa=" + regionEmpresa + "]";
	}		
}
