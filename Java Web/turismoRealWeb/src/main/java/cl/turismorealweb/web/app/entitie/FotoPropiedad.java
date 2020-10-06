package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.sql.Blob;
import java.util.Arrays;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.Lob;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

@Entity
@Table(name="FOTO_PROPIEDAD")
public class FotoPropiedad implements Serializable{

	private static final long serialVersionUID = -242033913497019845L;

	@Column(name="ID_FOTO_PROPIEDAD")
	@Id
	@GeneratedValue
	private Integer idFotoPropiedad;
	
	@Column(name="IMAGEN_PROPIEDAD")
	private String imagenPropiedad;
		
	@ManyToOne
	@JoinColumn(name = "PROPIEDAD_ID")
	private Propiedad popiedadFoto;

	public Integer getIdFotoPropiedad() {
		return idFotoPropiedad;
	}

	public void setIdFotoPropiedad(Integer idFotoPropiedad) {
		this.idFotoPropiedad = idFotoPropiedad;
	}

	public String getImagenPropiedad() {
		return imagenPropiedad;
	}

	public void setImagenPropiedad(String imagenPropiedad) {
		this.imagenPropiedad = imagenPropiedad;
	}

	public Propiedad getPopiedadFoto() {
		return popiedadFoto;
	}

	public void setPopiedadFoto(Propiedad popiedadFoto) {
		this.popiedadFoto = popiedadFoto;
	}

	@Override
	public String toString() {
		return "FotoPropiedad [idFotoPropiedad=" + idFotoPropiedad + ", imagenPropiedad=" + imagenPropiedad
				+ ", popiedadFoto=" + popiedadFoto + "]";
	}		
}
