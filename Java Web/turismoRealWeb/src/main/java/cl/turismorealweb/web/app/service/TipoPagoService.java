package cl.turismorealweb.web.app.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.turismorealweb.web.app.daoImpl.TipoPagoDaoImpl;
import cl.turismorealweb.web.app.entitie.TipoPago;

@Service
public class TipoPagoService {

	@Autowired
	private TipoPagoDaoImpl tipoPagoDaoImpl;
	
	public List<TipoPago> listarTiposPagos(){
		return tipoPagoDaoImpl.listarTiposPagos();
	}
	
	public TipoPago listarTipoPagoPorId(int idTipoPago) {
		return tipoPagoDaoImpl.listarTipoPagoPorId(idTipoPago);	
	}
	
	public String crearTipoPago(TipoPago tipoPago) {
		return tipoPagoDaoImpl.crearTipoPago(tipoPago);
	}
	
	public String actualizarTipoPago(TipoPago tipoPago) {
		return tipoPagoDaoImpl.actualizarTipoPago(tipoPago);
	}
	
	public String eliminarTipoPago(Integer idTipoPago) {
		return tipoPagoDaoImpl.eliminarTipoPago(idTipoPago);
	}
}
