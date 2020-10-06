package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.Reserva;

public interface ReservaDao {

	public List<Reserva> listarReservas();
	public Reserva listarReservaPorId(int idReserva);
	public List<Reserva> listarReservaPorRutUsuario(int rutUsuario);
	public String crearReserva(Reserva reserva);
	public String actualizarReserva(Reserva reserva);
	public String cancelarReserva(Reserva reserva);	
}
