package cl.turismorealweb.web.app.dao;

import java.util.List;

import cl.turismorealweb.web.app.entitie.Inventario;

public interface InventarioDao {

	public List<Inventario> listarInventarios();
	public Inventario listarInventarioPorId(int idInventario);
	public List<Inventario> listarInventarioPorPropiedad(int idPropiedad);
	public String crearInventario(Inventario inventario);
	public String actualizarInventario(Inventario inventario);
	public String eliminarInventario(Integer idInventario);
}
