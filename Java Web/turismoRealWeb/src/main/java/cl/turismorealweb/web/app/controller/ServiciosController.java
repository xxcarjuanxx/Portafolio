package cl.turismorealweb.web.app.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;

import cl.turismorealweb.web.app.entitie.Comuna;
import cl.turismorealweb.web.app.entitie.EstadoPropiedad;
import cl.turismorealweb.web.app.entitie.EstadoServicio;
import cl.turismorealweb.web.app.entitie.Inventario;
import cl.turismorealweb.web.app.entitie.Multa;
import cl.turismorealweb.web.app.entitie.Propiedad;
import cl.turismorealweb.web.app.entitie.Provincia;
import cl.turismorealweb.web.app.entitie.Region;
import cl.turismorealweb.web.app.entitie.ServicioExtra;
import cl.turismorealweb.web.app.entitie.TipoPago;
import cl.turismorealweb.web.app.models.ComunaDto;
import cl.turismorealweb.web.app.models.PropiedadDto;
import cl.turismorealweb.web.app.models.ProvinciaDto;
import cl.turismorealweb.web.app.service.ComunaService;
import cl.turismorealweb.web.app.service.InventarioService;
import cl.turismorealweb.web.app.service.MultaService;
import cl.turismorealweb.web.app.service.PropiedadService;
import cl.turismorealweb.web.app.service.ServicioExtraService;
import cl.turismorealweb.web.app.service.TipoPagoService;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;

@Controller
@RequestMapping("/servicios")
public class ServiciosController {

	@Autowired
	ComunaService comunaService;
	
	@Autowired
	private PropiedadService propiedadService;
	
	@Autowired
	private TipoPagoService tipoPagoService;
	
	@Autowired
	private InventarioService inventarioService;
	
	@Autowired
	private ServicioExtraService servicioExtraService;
	
	@Autowired
	private MultaService multaService;
	
	@GetMapping("/agregarPropiedades")
	public String agregarPropiedades(Model model) {		
		model.addAttribute("propiedad",new Propiedad());
		return "agregar_departamento";
	}
	
	@GetMapping("/agregar_servicio")
	public String agregar_servicio(Model model) {	
		model.addAttribute("propiedad",new Propiedad());
		model.addAttribute("servicioExtra",new ServicioExtra());
		model.addAttribute("inventario",new Inventario());
		model.addAttribute("tipoPago",new TipoPago());
		model.addAttribute("estadoPropiedad",new EstadoPropiedad());
		model.addAttribute("estadoServExtra",new EstadoServicio());
		
		return "agregar_servicio";
	}
	
	@GetMapping("/listarServicios")
	public String listarServicios(Model model) {	
		model.addAttribute("propiedad",new Propiedad());
		model.addAttribute("servicioExtra",new ServicioExtra());
		model.addAttribute("inventario",new Inventario());
		model.addAttribute("tipoPago",new TipoPago());
		model.addAttribute("estadoPropiedad",new EstadoPropiedad());
		model.addAttribute("estadoServExtra",new EstadoServicio());
		
		return "listar_servicios";
	}	
	
	@GetMapping("/verPropiedades")
	public String verPropiedades(Model model) {
		return "listarPropiedades";
	}
	
	@GetMapping(value="/buscarProvincias")
	@ResponseBody
	public List<ProvinciaDto> buscarProvinciaPorIdRegion(@RequestParam("idRegion") int idRegion){
		List<Provincia> listarProvincias = comunaService.listarProvinciasPorIdRegion(idRegion);
		List<ProvinciaDto> listarProvincia = new ArrayList<>();
		for (Provincia provincia : listarProvincias) {
			ProvinciaDto provinciaDto = new ProvinciaDto();
			provinciaDto.setIdProvincia(provincia.getIdProvincia());
			provinciaDto.setNombreProvincia(provincia.getNombreProvincia());
			provinciaDto.setIdRegion(provincia.getRegion().getIdRegion());
			listarProvincia.add(provinciaDto);
		}		
		return listarProvincia;
	}
	
	@GetMapping(value="/buscarComunas")
	@ResponseBody
	public List<ComunaDto> buscarComunaPorIdProvincia(@RequestParam("idProvincia") int idProvincia){
		List<Comuna> listarComuna = comunaService.listarComunasPorIdProvincia(idProvincia);
		List<ComunaDto> listarComunas = new ArrayList<>();
		for (Comuna comuna : listarComuna) {
			ComunaDto comunaDto = new ComunaDto();
			comunaDto.setIdComuna(comuna.getIdComuna());
			comunaDto.setNombreComuna(comuna.getNombreComuna());
			comunaDto.setProvincia(idProvincia);
			listarComunas.add(comunaDto);
		}	
		return listarComunas;
	}
	
	@PostMapping("/crearPropiedad")
	public String crearPropiedad(@ModelAttribute PropiedadDto propiedad
								,@ModelAttribute MultipartFile[] imagenPropiedad
								//,@RequestParam("imagenPropiedad")  MultipartFile[] imagenPropiedad
			                    ,Model model) {
		try{
			if (imagenPropiedad.length>0) {
				try {					
					if(imagenPropiedad.length>7){
						model.addAttribute("error", "Maximo 7 fotos por departamento");
						model.addAttribute("propiedad", propiedad);
						model.addAttribute("idEstado", propiedad.getEstadoPropiedad());
						model.addAttribute("idComuna", propiedad.getComuna());
						return "agregar_departamento";
					}
					
					
					/*Path directorio = Paths.get("src//main//resources//static//files");
					String rootPath = directorio.toFile().getAbsolutePath();					
					for (int i = 0; i < imagenPropiedad.length; i++) {
						byte[] imgBytes = imagenPropiedad[i].getBytes();
						Path rutaCompleta = Paths.get(rootPath + "//" + imagenPropiedad[i].getOriginalFilename());
						Files.write(rutaCompleta, imgBytes);
					}*/
					
					
					String salida = propiedadService.crearPropiedad(propiedad, imagenPropiedad);
					
					if(salida.toUpperCase().contains("ERROR")) {
						model.addAttribute("error", salida);
						model.addAttribute("propiedad", propiedad);
						return "agregar_departamento";
					}else {
						model.addAttribute("success", "Departamento agregado correctamente");
						model.addAttribute("propiedad", propiedad);
						return "agregar_departamento";
					}
				}catch (Exception e) {
					return "agregar_departamento";
				}
			}else{
				model.addAttribute("error", "Error al cargar archivo: " + propiedad.getNombre() + " , el archivo esta vacio");
				model.addAttribute("propiedad", propiedad);
				return "agregar_departamento";
			}
		}catch(Exception e){
			System.err.println("Error al intentar guardar Galeria, ERROR:"+ e.getMessage());
		}
		
		model.addAttribute("propiedad",new Propiedad());
		return "agregar_departamento";
	}
			
	@PostMapping("/crearServicioExtra")
	public String crearServicioExtra(@ModelAttribute ServicioExtra servicioExtra
			,@RequestParam("idPropiedad") int idPropiedad
			,@RequestParam("idEstadoServicio") int idEstadoServicio
			, Model model) {
		try {
			String resultado = servicioExtraService.crearServicio(servicioExtra, idPropiedad, idEstadoServicio);
			if(resultado.toUpperCase().contains("ERROR")) {
				model.addAttribute("error", resultado);
				model.addAttribute("servicioExtra", servicioExtra);
				listarServicios(model);
			}else {
				model.addAttribute("success", "Servicio extra agregado correctamente");
				model.addAttribute("servicioExtra", new ServicioExtra());
				listarServicios(model);
			}
		}catch(Exception e){
			
		}
		return "agregar_servicio";
	}
	
	@PostMapping("/crearInventario")
	public String crearInventario(@ModelAttribute Inventario inventario, Model model) {
		try {
			String resultado = inventarioService.crearInventario(inventario);
			if(resultado.toUpperCase().contains("ERROR")) {
				model.addAttribute("error", resultado);
				model.addAttribute("inventario", inventario);
				listarServicios(model);
			}else {
				model.addAttribute("success", "Inventario agregado correctamente");
				model.addAttribute("inventario", new Inventario());
				listarServicios(model);
			}
		}catch(Exception e){
			
		}
		return "agregar_servicio";
	}
	
	@PostMapping("/crearTipoPago")
	public String crearTipoPago(@ModelAttribute TipoPago tipoPago, Model model) {
		try {
			String resultado = tipoPagoService.crearTipoPago(tipoPago);
			if(resultado.toUpperCase().contains("ERROR")) {
				model.addAttribute("error", resultado);
				model.addAttribute("tipoPago", tipoPago);
				listarServicios(model);
			}else {
				model.addAttribute("success", "Tipo pago agregado correctamente");
				model.addAttribute("tipoPago", new TipoPago());
				listarServicios(model);
			}
		}catch(Exception e){
			
		}
		return "agregar_servicio";
	}
	
	@PostMapping("/crearMulta")
	public String crearMulta(@ModelAttribute Multa multa, Model model) {
		try {
			String resultado = multaService.crearMulta(multa);
			if(resultado.toUpperCase().contains("ERROR")) {
				model.addAttribute("error", resultado);
				model.addAttribute("multa", multa);
				listarServicios(model);
			}else {
				model.addAttribute("success", "Multa agregada correctamente");
				model.addAttribute("multa", new Multa());
				listarServicios(model);
			}
		}catch(Exception e){
			
		}
		return "agregar_servicio";
	}
	
	@PostMapping("/crearEstadoPropiedad")
	public String crearEstadoPropiedad(@ModelAttribute EstadoPropiedad estadoPropiedad, Model model) {
		try {
			String resultado = servicioExtraService.crearEstadoPropiedad(estadoPropiedad);
			if(resultado.toUpperCase().contains("ERROR")) {
				model.addAttribute("error", resultado);
				model.addAttribute("estadoPropiedad", estadoPropiedad);
				listarServicios(model);
			}else {
				model.addAttribute("success", "Estado Propiedad agregado correctamente");
				model.addAttribute("estadoPropiedad", new EstadoPropiedad());
				listarServicios(model);
			}
		}catch(Exception e){
			
		}
		return "agregar_servicio";
	}
	
	@PostMapping("/crearEstadoServExtra")
	public String crearEstadoServExtra(@ModelAttribute EstadoServicio estadoServExtra, Model model) {
		try {
			String resultado = servicioExtraService.crearEstadoServicio(estadoServExtra);
			if(resultado.toUpperCase().contains("ERROR")) {
				model.addAttribute("error", resultado);
				model.addAttribute("estadoServicio", estadoServExtra);
				listarServicios(model);
			}else {
				model.addAttribute("success", "Estado Servicio agregado correctamente");
				model.addAttribute("estadoServicio", new EstadoServicio());
				listarServicios(model);
			}
		}catch(Exception e){
			model.addAttribute("error", "error al intentar agregar el servicio extra");
			model.addAttribute("estadoServicio", estadoServExtra);
			listarServicios(model);
		}
		return "agregar_servicio";
	}
	
	
	@PostMapping("/reservar")
	public String reservar(Model model) {		
		//model.addAttribute("propiedad",new Propiedad());
		return "reservas_usuario";
	}
	
	
	@ModelAttribute("listarRegion")
	public List<Region> listarRegion(){			
		List<Region> regiones = comunaService.listarRegiones();
		return regiones;
	}
	
	@ModelAttribute("listarEstadosProp")
	public List<EstadoPropiedad> listarEstadosProp(){			
		List<EstadoPropiedad> estadosPropiedades = propiedadService.listarEstadosPropiedades();
		return estadosPropiedades;
	}
	
	@ModelAttribute("listarPropiedades")
	public List<Propiedad> listarPropiedades(){			
		List<Propiedad> listarPropiedades = propiedadService.listarPropiedades();
		return listarPropiedades;
	}
	
	@ModelAttribute("listarTiposPagos")
	public List<TipoPago> listarTiposPagos(){			
		List<TipoPago> listarTipoPagos = tipoPagoService.listarTiposPagos();
		return listarTipoPagos;
	}
	
	@ModelAttribute("listarServiciosExtras")
	public List<ServicioExtra> listarServiciosExtras(){			
		List<ServicioExtra> listarServiciosExtras = servicioExtraService.listarServiciosExtras();
		return listarServiciosExtras;
	}
	
	@ModelAttribute("listarInventarios")
	public List<Inventario> listarInventarios(){			
		List<Inventario> listarInventarios = inventarioService.listarInventarios();
		return listarInventarios;
	}
	
	@ModelAttribute("listarEstadoServicios")
	public List<EstadoServicio> listarEstadoServicios(){			
		List<EstadoServicio> listarEstadoServicios = servicioExtraService.listarEstadoServicio();
		return listarEstadoServicios;
	}
	
	@ModelAttribute("listarMultas")
	public List<Multa> listarMultas(){			
		List<Multa> listarMultas = multaService.listarMultas();
		return listarMultas;
	}
	
	/*@ModelAttribute("resultado")
	public void salida(Model model, String resultado) {
		if(!resultado.toUpperCase().equalsIgnoreCase("ERROR")) {
			model.addAttribute("resultado", resultado);
			//model.addAttribute("propiedad", propiedad);
		}else {
			model.addAttribute("resultado", resultado);
			//model.addAttribute("propiedad", propiedad);
		}
	}*/
}
