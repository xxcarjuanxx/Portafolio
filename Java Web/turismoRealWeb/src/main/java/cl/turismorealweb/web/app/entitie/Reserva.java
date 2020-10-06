package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;
import java.util.Date;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;

@Entity
public class Reserva implements Serializable{

	private static final long serialVersionUID = 7797631876640687070L;

	@Column(name="ID_RESERVA")
	@Id
	@GeneratedValue
	private Integer idReserva;
	
	@Column(name="CANTIDAD_PERSONAS")
	private Integer cantidadPersonas;
	
	@Column(name="CANTIDAD_DIAS")
	private Integer cantidadDias;
	
	@Column(name="FECHA_RESERVA")
	private Date fechaReserva;
	
	@Column(name="FECHA_ENTRADA")
	private Date fechaEntrada;
	
	@Column(name="FECHA_SALIDA")
	private Date fechaSalida;
	
	@Column(name="MONTO_ACTICIPO")
	private Integer montoAnticipo;
	
	@Column(name="MONTO_A_PAGAR")
	private Integer montoaPagar;
	
	@Column(name="MONTO_TOTAL")
	private Integer montoTotal;
		
	@Column(name="ESTADO_RESERVA")
	private String estadoReserva;
	
	@ManyToOne
	@JoinColumn(name = "PROPIEDAD_ID")
	private Propiedad propiedad;
	
	@ManyToOne
	@JoinColumn(name = "TIPO_PAGO_ID")
	private TipoPago tipoPago;	
	
	@ManyToOne
	@JoinColumn(name = "USUARIO_RUT")
	private Usuario usuario;
	
	public Integer getIdReserva() {
		return idReserva;
	}

	public void setIdReserva(Integer idReserva) {
		this.idReserva = idReserva;
	}

	public Integer getCantidadPersonas() {
		return cantidadPersonas;
	}

	public void setCantidadPersonas(Integer cantidadPersonas) {
		this.cantidadPersonas = cantidadPersonas;
	}

	public Integer getCantidadDias() {
		return cantidadDias;
	}

	public void setCantidadDias(Integer cantidadDias) {
		this.cantidadDias = cantidadDias;
	}

	public Date getFechaReserva() {
		return fechaReserva;
	}

	public void setFechaReserva(Date fechaReserva) {
		this.fechaReserva = fechaReserva;
	}

	public Date getFechaEntrada() {
		return fechaEntrada;
	}

	public void setFechaEntrada(Date fechaEntrada) {
		this.fechaEntrada = fechaEntrada;
	}

	public Date getFechaSalida() {
		return fechaSalida;
	}

	public void setFechaSalida(Date fechaSalida) {
		this.fechaSalida = fechaSalida;
	}

	public Integer getMontoAnticipo() {
		return montoAnticipo;
	}

	public void setMontoAnticipo(Integer montoAnticipo) {
		this.montoAnticipo = montoAnticipo;
	}

	public Integer getMontoaPagar() {
		return montoaPagar;
	}

	public void setMontoaPagar(Integer montoaPagar) {
		this.montoaPagar = montoaPagar;
	}

	public Integer getMontoTotal() {
		return montoTotal;
	}

	public void setMontoTotal(Integer montoTotal) {
		this.montoTotal = montoTotal;
	}
		
	public String getEstadoReserva() {
		return estadoReserva;
	}

	public void setEstadoReserva(String estadoReserva) {
		this.estadoReserva = estadoReserva;
	}

	public Propiedad getPropiedad() {
		return propiedad;
	}

	public void setPropiedad(Propiedad propiedad) {
		this.propiedad = propiedad;
	}

	public TipoPago getTipoPago() {
		return tipoPago;
	}

	public void setTipoPago(TipoPago tipoPago) {
		this.tipoPago = tipoPago;
	}

	public Usuario getUsuario() {
		return usuario;
	}

	public void setUsuario(Usuario usuario) {
		this.usuario = usuario;
	}

	@Override
	public String toString() {
		return "Reserva [idReserva=" + idReserva + ", cantidadPersonas=" + cantidadPersonas + ", cantidadDias="
				+ cantidadDias + ", fechaReserva=" + fechaReserva + ", fechaEntrada=" + fechaEntrada + ", fechaSalida="
				+ fechaSalida + ", montoAnticipo=" + montoAnticipo + ", montoaPagar=" + montoaPagar + ", montoTotal="
				+ montoTotal + ", estadoReserva=" + estadoReserva + ", propiedad=" + propiedad + ", tipoPago="
				+ tipoPago + ", usuario=" + usuario + "]";
	}
}
