package cl.turismorealweb.web.app.controller;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;

import cl.turismorealweb.web.app.models.DatosEmpresaDto;
import cl.turismorealweb.web.app.models.UsuarioDto;

@Controller
//@RequestMapping("/app")
public class IndexController {

	/*@Value("${application.controller.mensajepro}")
	private String mensajepro;
	
	@Value("${application.controller.emailTurismoReal}")
	private String emailTurismoReal;
	
	@Value("${application.controller.telefonoTurismoReal}")
	private String telefonolTurismoReal;*/
	
	@Autowired
	private DatosEmpresaDto datosEmpresaDto;
	
	@GetMapping({"/","/index"})
	public String index(Model model) {
		
		UsuarioDto usuario = new UsuarioDto();
		usuario.setNombre("Nicolás");
		usuario.setApellidos("Aravena");
		usuario.setEmail("nicolas.aravena25@gmail.com");
		
		model.addAttribute("mensaje", "Hola Muno desde el Controlador");
		model.addAttribute("usuario", usuario);
		
		return "index";
	}
	
	@GetMapping("/verMercadoPago")
	public String ver(Model model) {
		return "params/ver";
	}
	
	@GetMapping("/contactenos")
	public String contactenos(Model model) {
		return "contactenos";
	}

	@GetMapping("/listaUsuarios")
	public String listaUsuarios(Model model) {
								
		UsuarioDto usuario = new UsuarioDto();
		usuario.setNombre("Nicolás");
		usuario.setApellidos("Aravena");
		usuario.setEmail("nicolas.aravena25@gmail.com");
		
		model.addAttribute("usuario", usuario);
		
		//model.addAttribute("mensaje", "Listado de Usuarios " + listaUsuarios.size());
		//model.addAttribute("mensaje", mensajepro);
		//model.addAttribute("listaUsuarios", listaUsuarios);
		
		//return "index";
		return "usuarios";
	}
	
	@ModelAttribute("listaUsuarios")
	public List<UsuarioDto> poblarUsuarios(){
		List<UsuarioDto> listaUsuarios = new ArrayList<>();
		/*List<Usuario> listaUsuarios = 
				Arrays.asList(new Usuario("Nicolás", "Aravena", "nicolas.aravena25@gmail.com")
							 ,new Usuario("José", "Aravena", "jose.aravena@gmail.com")
							 ,new Usuario("Patricia", "Riquelme", "patricia.riquelme@gmail.com")
							 ,new Usuario("Denisse", "Mosimann", "denisse.mosimann@gmail.com")
							 ,new Usuario("Juanito", "Perez", "juanito.perez@gmail.com"));*/
		return listaUsuarios;
	}
	
	
	/*@ModelAttribute("emailTurismoReal")
	public String emailTurismoReal(Model model){
		return emailTurismoReal;
	}*/
	@ModelAttribute("datosEmpresa")
	public DatosEmpresaDto datosEmpresaDto(Model model){
		return datosEmpresaDto;
	}	
	
	/*@ModelAttribute("telefonolTurismoReal")
	public String telefonolTurismoReal(Model model){
		return telefonolTurismoReal;
	}*/
}
