package cl.turismorealweb.web.app.controller;

import java.io.UnsupportedEncodingException;
import java.sql.Blob;
import java.sql.SQLException;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import cl.turismorealweb.web.app.entitie.FotoPropiedad;
import cl.turismorealweb.web.app.entitie.Propiedad;
import cl.turismorealweb.web.app.service.ComunaService;
import cl.turismorealweb.web.app.service.PropiedadService;
import cl.turismorealweb.web.app.util.UsuarioUtils;

import java.sql.Blob;
import org.apache.commons.codec.binary.Base64;

@Controller
@RequestMapping("/propiedad")
public class PropiedadController {
	
	@Autowired
	ComunaService regionService;
	
	@Autowired
	private PropiedadService propiedadService;
	
	@GetMapping("/verPropiedades")
	public String verPropiedades(Model model) {
		List<Propiedad> listarPropiedades = propiedadService.listarPropiedadesDos();		
		//for (Propiedad propiedades : listarPropiedades) {
			//propiedades.getFotoPropiedad().get(0).setNombreImagen(UsuarioUtils.encodeBlobToBase64(propiedades.getFotoPropiedad().get(0).getImagenPropiedad()));
			//propiedades.getFotoPropiedad().get(0).setImagenPropiedad(propiedades.getFotoPropiedad().get(0).getImagenPropiedad());
		//}
		model.addAttribute("listarPropiedades", listarPropiedades);
		model.addAttribute("usuarioUtils", new UsuarioUtils());

		return "servicios";
	}
	
	@GetMapping("/listarPropiedadPorFiltro")
	public String listarPropiedadPorFiltro(@RequestParam(name="idRegion", required=false, defaultValue="0") Integer idRegion
			                              ,@RequestParam(name="idProvincia", required=false, defaultValue="0") Integer idProvincia 
			                              ,@RequestParam(name="fechaDesde", required=false, defaultValue="") String fechaDesde
			                              ,@RequestParam(name="fechaHasta", required=false, defaultValue="") String fechaHasta
			                              ,@RequestParam(name="cantHuespedes", required=false, defaultValue="0") Integer cantHuespedes
			                              ,@RequestParam(name="valor", required=false, defaultValue="0") Integer valor
			                              , Model model) {
		List<Propiedad> listarPropiedades = propiedadService.listarPropiedadPorFiltro(idRegion, idProvincia, fechaDesde
				                                                                    , fechaHasta, cantHuespedes, valor);
		model.addAttribute("listarPropiedades", listarPropiedades);
		model.addAttribute("usuarioUtils", new UsuarioUtils());

		return "servicios";
	}
	
	@GetMapping("/verDetallePropiedad")
	public String verDetallePropiedad(@RequestParam(name="idPropiedad") Integer idPropiedad, Model model) {
		Propiedad propiedad = propiedadService.listarPropiedadPorId(idPropiedad);
		
		//for (FotoPropiedad fotoPropiedad : propiedad.getFotoPropiedad()) {
			//fotoPropiedad.setNombreImagen(UsuarioUtils.encodeBlobToBase64(fotoPropiedad.getImagenPropiedad()));
		//}
		
		model.addAttribute("propiedad", propiedad);
		model.addAttribute("usuarioUtils", new UsuarioUtils());
		model.addAttribute("message", "Hola Mundoooo");
		return "verDetallePropiedad";
	}
}
