package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity
@Table(name="TIPO_PAGO")
public class TipoPago implements Serializable{

	private static final long serialVersionUID = -6486028194263777159L;

	@Column(name="ID_TIPO_PAGO")
	@Id
	@GeneratedValue
	private Integer idTipoPago;
	
	@Column(name="NOMBRE_TIPO_PAGO")
	private String nombreTipoPago;
	
	@Column(name="ESTADO_TIPO_PAGO")
	private String estadoTipoPago;

	@OneToMany(mappedBy="tipoPago")
	private List<Reserva> reserva;
	
	public Integer getIdTipoPago() {
		return idTipoPago;
	}

	public void setIdTipoPago(Integer idTipoPago) {
		this.idTipoPago = idTipoPago;
	}

	public String getNombreTipoPago() {
		return nombreTipoPago;
	}

	public void setNombreTipoPago(String nombreTipoPago) {
		this.nombreTipoPago = nombreTipoPago;
	}

	public String getEstadoTipoPago() {
		return estadoTipoPago;
	}

	public void setEstadoTipoPago(String estadoTipoPago) {
		this.estadoTipoPago = estadoTipoPago;
	}

	public List<Reserva> getReserva() {
		return reserva;
	}

	public void setReserva(List<Reserva> reserva) {
		this.reserva = reserva;
	}

	@Override
	public String toString() {
		return "TipoPago [idTipoPago=" + idTipoPago + ", nombreTipoPago=" + nombreTipoPago + ", estadoTipoPago="
				+ estadoTipoPago + ", reserva=" + reserva + "]";
	}
}
