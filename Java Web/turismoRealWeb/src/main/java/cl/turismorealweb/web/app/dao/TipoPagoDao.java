package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.TipoPago;

public interface TipoPagoDao {

	public List<TipoPago> listarTiposPagos();
	public TipoPago listarTipoPagoPorId(int idTipoPago);
	public String crearTipoPago(TipoPago tipoPago);
	public String actualizarTipoPago(TipoPago tipoPago);
	public String eliminarTipoPago(Integer idTipoPago);
}
