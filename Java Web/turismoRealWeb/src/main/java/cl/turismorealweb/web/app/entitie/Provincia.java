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
public class Provincia implements Serializable{

	private static final long serialVersionUID = 2818589732496055154L;
	
	@Column(name="ID_PROVINCIA")
	@Id
	@GeneratedValue
	private Integer idProvincia;
	
	@Column(name="NOMBRE_PROVINCIA")
	private String nombreProvincia;

	@ManyToOne
	@JoinColumn(name = "REGION_ID")
	private Region region;
	
	@OneToMany(mappedBy="provincia")
	private List<Comuna> comuna;

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

	public Region getRegion() {
		return region;
	}

	public void setRegion(Region region) {
		this.region = region;
	}

	public List<Comuna> getComuna() {
		return comuna;
	}

	public void setComuna(List<Comuna> comuna) {
		this.comuna = comuna;
	}

	@Override
	public String toString() {
		return "Provincia [idProvincia=" + idProvincia + ", nombreProvincia=" + nombreProvincia + ", region=" + region
				+ ", comuna=" + comuna + "]";
	}	
}
