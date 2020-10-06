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
public class Comuna implements Serializable{

	private static final long serialVersionUID = 8065501391141497757L;
	
	@Column(name="ID_COMUNA")
	@Id
	@GeneratedValue
	private Integer idComuna;
	
	@Column(name="NOMBRE_COMUNA")
	private String nombreComuna;

	@ManyToOne
	@JoinColumn(name = "PROVINCIA_ID")
	private Provincia provincia;

	@OneToMany(mappedBy="comuna")/*El dueño de la relacion*/
	private List<Propiedad> propiedad;
		
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

	public Provincia getProvincia() {
		return provincia;
	}

	public void setProvincia(Provincia provincia) {
		this.provincia = provincia;
	}

	public List<Propiedad> getPropiedad() {
		return propiedad;
	}

	public void setPropiedad(List<Propiedad> propiedad) {
		this.propiedad = propiedad;
	}

	@Override
	public String toString() {
		return "Comuna [idComuna=" + idComuna + ", nombreComuna=" + nombreComuna + ", provincia=" + provincia
				+ ", propiedad=" + propiedad + "]";
	}
}
