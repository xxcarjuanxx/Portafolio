package cl.turismorealweb.web.app.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;

import cl.turismorealweb.web.app.daoImpl.ReservaDaoImpl;
import cl.turismorealweb.web.app.entitie.Reserva;
import cl.turismorealweb.web.app.enums.EstadoReserva;

public class ReservaService {

	@Autowired
	private ReservaDaoImpl reservaDaoImpl;
	
	public List<Reserva> listarReservas(){
		return reservaDaoImpl.listarReservas();
	}
	
	public Reserva listarReservaPorId(int idReserva){
		return reservaDaoImpl.listarReservaPorId(idReserva);
	}
	
	public List<Reserva> listarReservaPorRutUsuario(int rutUsuario){
		return reservaDaoImpl.listarReservaPorRutUsuario(rutUsuario);
	}
	
	public String crearReserva(Reserva reserva){
		EstadoReserva e = EstadoReserva.getAbreviatura("RESERVADO");
		reserva.setEstadoReserva(e.getDescripcionEstado());
		return reservaDaoImpl.crearReserva(reserva);
	}
	
	public String actualizarReserva(Reserva reserva){
		EstadoReserva e = EstadoReserva.getAbreviatura(reserva.getEstadoReserva());
		reserva.setEstadoReserva(e.getDescripcionEstado());
		return reservaDaoImpl.actualizarReserva(reserva);
	}
	
	public String cancelarReserva(Reserva reserva){
		EstadoReserva e = EstadoReserva.getAbreviatura("CANCELAR");
		reserva.setEstadoReserva(e.getDescripcionEstado());
		return reservaDaoImpl.actualizarReserva(reserva);
	}
}
