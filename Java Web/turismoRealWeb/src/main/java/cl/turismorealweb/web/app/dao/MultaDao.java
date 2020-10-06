package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.Multa;
import cl.turismorealweb.web.app.entitie.ServicioExtra;

public interface MultaDao {

	public List<Multa> listarMultas();
	public Multa listarMultaPorId(int idMulta);
	public List<Multa> listarMultasPorPropiedad(int idPropiedad);
	public String crearMulta(Multa multa);
	public String actualizarMulta(Multa multa);
	public String eliminarMulta(Integer idMulta);
}
