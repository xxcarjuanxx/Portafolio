package cl.turismorealweb.web.app.service;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.sql.Blob;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import org.hibernate.engine.jdbc.BlobProxy;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import cl.turismorealweb.web.app.dao.FotoPropiedadDao;
import cl.turismorealweb.web.app.dao.PropiedadDao;
import cl.turismorealweb.web.app.entitie.Comuna;
import cl.turismorealweb.web.app.entitie.EstadoPropiedad;
import cl.turismorealweb.web.app.entitie.FotoPropiedad;
import cl.turismorealweb.web.app.entitie.Propiedad;
import cl.turismorealweb.web.app.models.PropiedadDto;
import cl.turismorealweb.web.app.util.UsuarioUtils;

@Service
public class PropiedadService {

	@Autowired
	private PropiedadDao propiedadDao;
	
	@Autowired
	private FotoPropiedadDao fotoPropiedadDao;
	
	public List<Propiedad> listarPropiedades() {
		List<Propiedad> listarPropiedades = propiedadDao.listarPropiedades();
		
		for (Propiedad propiedad : listarPropiedades) {
			List<FotoPropiedad> listarFotoPropiedad = fotoPropiedadDao.listarFotoPropiedadPorIdPropiedad(propiedad.getIdPropiedad());
			
			/*for (FotoPropiedad fotoPropiedadpropiedad : listarFotoPropiedad) {

				Blob blob = fotoPropiedadpropiedad.getImagenPropiedad();				
				int blobLength;
				try {
					blobLength = (int) blob.length();
					byte[] encoded = blob.getBytes(1, blobLength);
					String encodedString = new String(encoded);
					fotoPropiedadpropiedad.setNombreImagen(encodedString);
				} catch (SQLException e) {
					e.printStackTrace();
				}
			}*/
			
			propiedad.setFotoPropiedad(listarFotoPropiedad);
		}
		
		return listarPropiedades;
	}
	
	public List<Propiedad> listarPropiedadesDos() {
		List<Propiedad> listarPropiedades = propiedadDao.listarPropiedades();
		
		/*for (Propiedad propiedad : listarPropiedades) {
			List<FotoPropiedad> listarFotoPropiedad = fotoPropiedadDao.listarFotoPropiedadPorIdPropiedad(propiedad.getIdPropiedad());
			propiedad.setFotoPropiedad(listarFotoPropiedad);
		}*/
		
		return listarPropiedades;
	}
	
	/*public Propiedad listarPropiedadPorIdDos(int idPropiedad) {
		return propiedadDao.listarPropiedadPorId(idPropiedad);
	}*/
	
	public List<PropiedadDto> listarPropiedadesDto() {
		List<Propiedad> listarPropiedades = propiedadDao.listarPropiedades();		
		List<PropiedadDto> listarPropiedadesDto = new ArrayList<PropiedadDto>();
		
		for (Propiedad propiedad : listarPropiedades) {
			PropiedadDto propiedadDto = new PropiedadDto();
			
			propiedadDto.setIdPropiedad(propiedad.getIdPropiedad());
			propiedadDto.setNombre(propiedad.getNombre());
			propiedadDto.setDireccion(propiedad.getDireccion());
			propiedadDto.setDescripcionPropiedad(propiedad.getDescripcionPropiedad());
			
			propiedadDto.setPiso(propiedad.getPiso());
			propiedadDto.setTamanio(propiedad.getTamanio());
			propiedadDto.setOrientacion(propiedad.getOrientacion());
			propiedadDto.setAnioEdificacion(propiedad.getAnioEdificacion());
			propiedadDto.setEstadoPropiedad(propiedad.getEstadoPropiedad().getIdEstadoPropiedad());
						
			propiedadDto.setCantHuespedes(propiedad.getCantHuespedes());
			propiedadDto.setCantHabitaciones(propiedad.getCantHabitaciones());
			propiedadDto.setCantBanio(propiedad.getCantBanio());
			propiedadDto.setValorDia(propiedad.getValorDia());
			propiedadDto.setComuna(propiedad.getComuna().getIdComuna());
			
			listarPropiedadesDto.add(propiedadDto);
		}
		
		return listarPropiedadesDto;
	}
	
	public Propiedad listarPropiedadPorId(int idPropiedad) {
		return propiedadDao.listarPropiedadPorId(idPropiedad);
	}
	
	public List<Propiedad> listarPropiedadPorComuna(int idComuna) {
		return propiedadDao.listarPropiedadPorComuna(idComuna);
	}
	
	public String crearPropiedad(PropiedadDto propiedad, MultipartFile[] imagenPropiedad) {

		String idPropiedad = "0";
		String salida = "";
		Propiedad p = new Propiedad();
		
		//Path directorio = Paths.get("src//main//resources//static//files");
		//Path directorio = Paths.get("C://Mis Proyectos//turismoRealWeb_fotos");
		String rootPath = "C://Mis Proyectos//turismoRealWeb_fotos";
		
		try {
			p.setNombre(propiedad.getNombre());
			p.setDireccion(propiedad.getDireccion());
			p.setDescripcionPropiedad(propiedad.getDescripcionPropiedad());
			p.setValorDia(propiedad.getValorDia());
			p.setOrientacion(propiedad.getOrientacion());
			p.setTamanio(propiedad.getTamanio());
			p.setPiso(propiedad.getPiso());
			p.setCantHuespedes(propiedad.getCantHuespedes());
			p.setCantBanio(propiedad.getCantBanio());
			p.setCantHabitaciones(propiedad.getCantHabitaciones());
			p.setAnioEdificacion(propiedad.getAnioEdificacion());

			Comuna comuna = new Comuna();
			comuna.setIdComuna(propiedad.getComuna());
			p.setComuna(comuna);
			
			EstadoPropiedad estado = new EstadoPropiedad();
			estado.setIdEstadoPropiedad(propiedad.getEstadoPropiedad());
			p.setEstadoPropiedad(estado);
			
			idPropiedad = propiedadDao.crearPropiedad(p);
			
			try {
				/*Si es numerico se ingreso correctamente el registro y retorno el numero de la sequencia que inserto*/
				if(UsuarioUtils.esNumerico(idPropiedad)) {				
					p.setIdPropiedad(Integer.parseInt(idPropiedad));
					
					for (MultipartFile file : imagenPropiedad) {
						FotoPropiedad fotoPropiedad = new FotoPropiedad();
						byte[] imgBytes = file.getBytes();
						Path rutaCompleta = Paths.get(rootPath + "//" + file.getOriginalFilename());
						Files.write(rutaCompleta, imgBytes);
						fotoPropiedad.setImagenPropiedad(file.getOriginalFilename());
						
						//fotoPropiedad.setImagenPropiedad(BlobProxy.generateProxy(file.getBytes()));
						//fotoPropiedad.setNombreImagen(file.getOriginalFilename());
						fotoPropiedad.setPopiedadFoto(p);

						salida = fotoPropiedadDao.crearFotoPropiedad(fotoPropiedad);
					}
				}else {
					salida = /*"Error al intentar crear la propiedad, " +*/ idPropiedad;
				}
							
			}catch (IOException e) {
				salida = "Error al intentar agregar la foto a la propiedad";
			}catch (Exception e) {
				salida = "Error al intentar agregar la foto a la propiedad";
			}
			
		}catch (Exception e) {
			salida = idPropiedad;
		}		
		
		return salida;
	}
	
	public String actualizarPropiedad(Propiedad propiedad) {
		return propiedadDao.actualizarPropiedad(propiedad);
	}
	
	public List<FotoPropiedad> listarFotoPropiedadPorIdPropiedad(int idPropiedad) {
		return fotoPropiedadDao.listarFotoPropiedadPorIdPropiedad(idPropiedad);
	}
	
	public FotoPropiedad listarFotoPropiedadPorId(int idFotoPropiedad) {
		return fotoPropiedadDao.listarFotoPropiedadPorId(idFotoPropiedad);
	}
	
	public String crearFotoPropiedad(FotoPropiedad fotoPropiedad) {
		return fotoPropiedadDao.crearFotoPropiedad(fotoPropiedad);
	}
	
	public String actualizarFotoPropiedad(FotoPropiedad fotoPropiedad) {
		return fotoPropiedadDao.actualizarFotoPropiedad(fotoPropiedad);
	}
	
	public List<EstadoPropiedad> listarEstadosPropiedades() {
		return propiedadDao.listarEstadosPropiedades();
	}
	
	public String listarEstadosPropiedadPorId(int idPropiedad) {
		return propiedadDao.listarEstadosPropiedadPorId(idPropiedad);
	}
	
	public List<Propiedad> listarPropiedadPorFiltro(int idRegion, int idProvincia, String fechaDesde, String fechaHasta,
			int cantHuespedes, int valor) {
		return propiedadDao.listarPropiedadPorFiltro(idRegion, idProvincia, fechaDesde, fechaHasta, cantHuespedes, valor);
	}
}
