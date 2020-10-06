package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;

@Entity
public class Inventario implements Serializable{

	private static final long serialVersionUID = -5323854998126903248L;
	
	@Column(name="ID_INVENTARIO")
	@Id
	@GeneratedValue
	private Integer idInventario;
	
	private String descripcion;
	
	private Integer valor;

	@OneToMany(mappedBy="inventario")
	private List<PropiedadInventario> propiedadInventario;

	public Integer getIdInventario() {
		return idInventario;
	}

	public void setIdInventario(Integer idInventario) {
		this.idInventario = idInventario;
	}

	public String getDescripcion() {
		return descripcion;
	}

	public void setDescripcion(String descripcion) {
		this.descripcion = descripcion;
	}

	public Integer getValor() {
		return valor;
	}

	public void setValor(Integer valor) {
		this.valor = valor;
	}

	public List<PropiedadInventario> getPropiedadInventario() {
		return propiedadInventario;
	}

	public void setPropiedadInventario(List<PropiedadInventario> propiedadInventario) {
		this.propiedadInventario = propiedadInventario;
	}

	@Override
	public String toString() {
		return "Inventario [idInventario=" + idInventario + ", descripcion=" + descripcion + ", valor=" + valor
				+ ", propiedadInventario=" + propiedadInventario + "]";
	}	
}
