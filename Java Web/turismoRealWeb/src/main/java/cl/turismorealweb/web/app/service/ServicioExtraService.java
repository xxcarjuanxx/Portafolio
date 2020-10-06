package cl.turismorealweb.web.app.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.turismorealweb.web.app.daoImpl.EstadoServicioDaoImpl;
import cl.turismorealweb.web.app.daoImpl.ServicioExtraDaoImpl;
import cl.turismorealweb.web.app.entitie.EstadoPropiedad;
import cl.turismorealweb.web.app.entitie.EstadoServicio;
import cl.turismorealweb.web.app.entitie.Propiedad;
import cl.turismorealweb.web.app.entitie.ServicioExtra;

@Service
public class ServicioExtraService {

	@Autowired
	private ServicioExtraDaoImpl servicioExtraDaoImpl;
	
	@Autowired
	private EstadoServicioDaoImpl estadoServicioDaoImpl;
	
	public List<ServicioExtra> listarServiciosExtras(){
		return servicioExtraDaoImpl.listarServiciosExtras();
	}
	
	public ServicioExtra listarServicioPorId(int idServicio) {
		return servicioExtraDaoImpl.listarServicioPorId(idServicio);
	}
	
	public List<ServicioExtra> listarServiciosExtraPorPropiedad(int idPropiedad){
		return servicioExtraDaoImpl.listarServiciosExtraPorPropiedad(idPropiedad);
	}
	
	public String crearServicio(ServicioExtra servicioExtra, Integer idPropiedad, Integer idEstadoServicio) {
		
		Propiedad propiedad = new Propiedad();
		EstadoServicio estadoServicio = new EstadoServicio();			

		propiedad.setIdPropiedad(idPropiedad);
		estadoServicio.setIdEstadoServicio(idEstadoServicio);
		servicioExtra.setPropiedad(propiedad);
		servicioExtra.setEstadoServicio(estadoServicio);
		
		return servicioExtraDaoImpl.crearServicio(servicioExtra);
	}
	
	public String actualizarServicio(ServicioExtra servicioExtra) {
		return servicioExtraDaoImpl.actualizarServicio(servicioExtra);
	}
	
	public String eliminarServicio(Integer idServicioExtra) {
		return servicioExtraDaoImpl.eliminarServicio(idServicioExtra);
	}
	
	public List<EstadoServicio> listarEstadoServicio(){
		return estadoServicioDaoImpl.listarEstadoServicio();
	}
	
	public EstadoServicio listarEstadoServicioPorId(int idEstadoServicio) {
		return estadoServicioDaoImpl.listarEstadoServicioPorId(idEstadoServicio);
	}
	
	public String crearEstadoServicio(EstadoServicio estadoServicio) {
		return estadoServicioDaoImpl.crearEstadoServicio(estadoServicio);
	}
	
	public String actualizarEstadoServicio(EstadoServicio estadoServicio) {
		return estadoServicioDaoImpl.actualizarEstadoServicio(estadoServicio);
	}
	
	public String eliminarEstadoServicio(Integer idEstadoServicio) {
		return estadoServicioDaoImpl.eliminarEstadoServicio(idEstadoServicio);
	}	
	
	public List<EstadoPropiedad> listarEstadosPropiedad(){
		return estadoServicioDaoImpl.listarEstadosPropiedad();
	}
	
	public EstadoPropiedad listarEstadoPropiedadPorId(int idEstadoPropiedad) {
		return estadoServicioDaoImpl.listarEstadoPropiedadPorId(idEstadoPropiedad);
	}
	
	public String crearEstadoPropiedad(EstadoPropiedad estadoPropiedad) {
		return estadoServicioDaoImpl.crearEstadoPropiedad(estadoPropiedad);
	}
}
