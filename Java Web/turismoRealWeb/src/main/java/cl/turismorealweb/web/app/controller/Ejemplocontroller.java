package cl.turismorealweb.web.app.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import cl.turismorealweb.web.app.entitie.Region;
import cl.turismorealweb.web.app.entitie.Usuario;
import cl.turismorealweb.web.app.service.ComunaService;
import cl.turismorealweb.web.app.service.UsuarioService;

@Controller
@RequestMapping("/params")
public class Ejemplocontroller {

	@Autowired
	UsuarioService usuarioService;
	
	@Autowired
	ComunaService regionService;
	
	@GetMapping("/")
	public String index() {
		return "index";
	}
	
	@GetMapping("/login")
	public String login(Model model) {
		
		return "login";
	}
	
	@GetMapping("/string")
	public String listarUsuarios(@RequestParam(name="texto", required=false, defaultValue = "álgun valor") String texto, Model model) {
		model.addAttribute("resultado","el texto enviado es: " + texto);
		return "/params/ver";
	}
	
	@GetMapping("/mix-params")
	public String mixParams(@RequestParam String saludo, @RequestParam Integer numero, Model model) {
		model.addAttribute("resultado","el saludo enviado es: '" + saludo + "' y el número es: " + numero + "'");
		return "/params/ver";
	}
	
	@GetMapping("/mix-params-request")
	public String mixParams(HttpServletRequest request, Model model) {		
		String saludo = request.getParameter("saludo");
		Integer numero = null;
		try {
			numero = Integer.parseInt(request.getParameter("numero"));
		}catch (NumberFormatException e) {
			numero = 0;
		}
		model.addAttribute("resultado","el saludo enviado es: '" + saludo + "' y el número es: " + numero + "'");
		return "/params/ver";
	}
	
	@GetMapping("/listarUsuarios")
	public String listarUsuarios(Model model) {
		
		List<Usuario> usuarios = usuarioService.listarUsuarios();
		model.addAttribute("listaUsuarios",usuarios);
		
		List<Region> regiones = regionService.listarRegiones();
				
		return "usuarios";
	}
}
