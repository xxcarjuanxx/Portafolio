package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

@Entity
public class Multa  implements Serializable{

	private static final long serialVersionUID = 3143385688311215255L;

	@Column(name="ID_MULTA")
	@Id
	@GeneratedValue
	private Integer idMulta;
	
	@Column(name="DESCRIPCION_MULTA")
	private String descripcionMulta;
	
	@Column(name="VALOR_MULTA")
	private Integer valorMulta;

	public Integer getIdMulta() {
		return idMulta;
	}

	public void setIdMulta(Integer idMulta) {
		this.idMulta = idMulta;
	}

	public String getDescripcionMulta() {
		return descripcionMulta;
	}

	public void setDescripcionMulta(String descripcionMulta) {
		this.descripcionMulta = descripcionMulta;
	}

	public Integer getValorMulta() {
		return valorMulta;
	}

	public void setValorMulta(Integer valorMulta) {
		this.valorMulta = valorMulta;
	}

	@Override
	public String toString() {
		return "Multa [idMulta=" + idMulta + ", descripcionMulta=" + descripcionMulta + ", valorMulta=" + valorMulta
				+ "]";
	}
}
