package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;

@Entity
public class Region implements Serializable{

	private static final long serialVersionUID = -5132977617538299947L;
	
	@Column(name="ID_REGION")
	@Id
	@GeneratedValue
	private Integer idRegion;
	
	@Column(name="NOMBRE_REGION")
	private String nombreRegion;
	
	@Column(name="REGION_ORDINAL")
	private String codigoRegion;
	
	@OneToMany(mappedBy="region")
	private List<Provincia> provincia;

	public Integer getIdRegion() {
		return idRegion;
	}

	public void setIdRegion(Integer idRegion) {
		this.idRegion = idRegion;
	}

	public String getNombreRegion() {
		return nombreRegion;
	}

	public void setNombreRegion(String nombreRegion) {
		this.nombreRegion = nombreRegion;
	}

	public String getCodigoRegion() {
		return codigoRegion;
	}

	public void setCodigoRegion(String codigoRegion) {
		this.codigoRegion = codigoRegion;
	}

	public List<Provincia> getProvincia() {
		return provincia;
	}

	public void setProvincia(List<Provincia> provincia) {
		this.provincia = provincia;
	}

	@Override
	public String toString() {
		return "Region [idRegion=" + idRegion + ", nombreRegion=" + nombreRegion + ", codigoRegion=" + codigoRegion
				+ ", provincia=" + provincia + "]";
	}	
}
