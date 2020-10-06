package cl.turismorealweb.web.app.enums;

public enum EstadoReserva {

	PAGADO("PAG"),
	RESERVADO("RES"),
	CANCELAR("CAN"),
	OTRO("OTRO");
	
	String descripcionEstado;
	
	public String getDescripcionEstado() {
		return descripcionEstado;
	}
	
	private EstadoReserva(String descripcionEstado) {
		this.descripcionEstado = descripcionEstado;
	}
	
	public static EstadoReserva getAbreviatura(String name){		
		if(name == null) {
			return EstadoReserva.OTRO;
		}
		try {
			return EstadoReserva.valueOf(EstadoReserva.class, name);
		} catch (Exception e) {
			return EstadoReserva.OTRO;
		}
	}
}
