package cl.turismorealweb.web.app.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.turismorealweb.web.app.daoImpl.InventarioDaoImpl;
import cl.turismorealweb.web.app.entitie.Inventario;

@Service
public class InventarioService {

	@Autowired
	private InventarioDaoImpl inventarioDaoImpl;
	
	public List<Inventario> listarInventarios(){
		return inventarioDaoImpl.listarInventarios();
	}
	
	public Inventario listarInventarioPorId(int idInventario){
		return inventarioDaoImpl.listarInventarioPorId(idInventario);
	}
	
	public List<Inventario> listarInventarioPorPropiedad(int idPropiedad){
		return inventarioDaoImpl.listarInventarioPorPropiedad(idPropiedad);
	}
	
	public String crearInventario(Inventario inventario){
		return inventarioDaoImpl.crearInventario(inventario);
	}
	
	public String actualizarInventario(Inventario inventario){
		return inventarioDaoImpl.actualizarInventario(inventario);
	}
	
	public String eliminarInventario(Integer idInventario){
		return inventarioDaoImpl.eliminarInventario(idInventario);
	}
}
