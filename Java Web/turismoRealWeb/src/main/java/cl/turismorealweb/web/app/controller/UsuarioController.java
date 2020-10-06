package cl.turismorealweb.web.app.controller;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import cl.turismorealweb.web.app.entitie.Propiedad;
import cl.turismorealweb.web.app.entitie.Provincia;
import cl.turismorealweb.web.app.entitie.Rol;
import cl.turismorealweb.web.app.entitie.ServicioExtra;
import cl.turismorealweb.web.app.models.EmailBodyDto;
import cl.turismorealweb.web.app.models.PropiedadDto;
import cl.turismorealweb.web.app.models.ProvinciaDto;
import cl.turismorealweb.web.app.models.RolDto;
import cl.turismorealweb.web.app.entitie.Usuario;
import cl.turismorealweb.web.app.models.UsuarioDto;
import cl.turismorealweb.web.app.service.ComunaService;
import cl.turismorealweb.web.app.service.EmailService;
//import cl.turismorealweb.web.app.entitie.Rol;
//import cl.turismorealweb.web.app.entitie.Usuario;
import cl.turismorealweb.web.app.service.UsuarioService;

@Controller
@RequestMapping("/usuario")
public class UsuarioController {

	@Autowired
	UsuarioService usuarioService;
	
	@Autowired
	ComunaService regionService;
	
	@Autowired
	EmailService emailService;
	
	@GetMapping("/login")
	public String login(@RequestParam(name="reservar", required=false, defaultValue="0") Integer reservar
			           ,@RequestParam(name="idPropiedad", required=false, defaultValue="0") Integer idPropiedad
			           ,@ModelAttribute ServicioExtra servicioExtra			           
			           ,Model model) {
		
		System.out.println("idPropiedad:"+idPropiedad);
		
		model.addAttribute("reservar", reservar);
		return "login";
	}
	
	@GetMapping("/mantenedor")
	public String mantenedor(Model model) {		
		return "administrador";
	}	
	
	@GetMapping("/buscarUsuarioPorRut")
	@ResponseBody
	public Usuario buscarUsuarioPorRut(@RequestParam(value = "tipoUsuario") int tipoUsuario
									  ,@RequestParam(value = "rut") String rut
									  ,Model model) {		
		rut = rut.replaceAll("-", "");
		rut = rut.substring(0, rut.length() - 1);	
		
		Usuario usuario = usuarioService.listaUsuarioPorRutyRol(Integer.parseInt(rut), tipoUsuario);				
		return usuario;
	}
	

	@PostMapping("/validarSecion")
	public String validarSecion(@RequestParam(value = "tipoUsuario") int tipoUsuario
							   ,@RequestParam(value = "rut") String rut
							   ,@RequestParam(value = "password") String password
							   ,@RequestParam(name="reservar", required=false, defaultValue="0") Integer reservar
			                   ,Model model) {
		
		rut = rut.replaceAll("-", "");
		rut = rut.substring(0, rut.length() - 1);		
		
		Usuario usuario = usuarioService.listaUsuarioPorRutyRol(Integer.parseInt(rut), tipoUsuario);
		
		if(usuario==null) {
			System.out.println("el usuario no existe, rut:"+rut+", Rol:"+tipoUsuario);
			model.addAttribute("error", "Usuario ingresado no está registrado!");
		}else {
			System.out.println("usuario existe:"+usuario.getNombre() + " " + usuario.getApellidos());
			model.addAttribute("nombreUsuario", usuario.getNombre() + " " + usuario.getApellidos());
			if(!usuario.getPassword().equals(password)) {
					model.addAttribute("error", "Usuario o Clave incorrecta");
			}else {
				if(usuario.getRol().getIdRol()==1) {
					System.out.println("Usuario es administrador");
					return "administrador";
				}else {
					if(reservar==1) {
						model.addAttribute("usuario", usuario);
						return "detalle_reserva";
					}else {
						return "cliente";
					}					
				}
			}
		}
		
		model.addAttribute("tiposClientes", usuarioService.listarRoles());
		
		return "login";
	}
	
	@PostMapping("/recuperarPassword")
	public String recuperarPassword(@RequestParam(value = "rut") String rut
			                       ,Model model) {
		
		rut = rut.replaceAll("-", "");
		rut = rut.substring(0, rut.length() - 1);		
		
		Usuario usuario = usuarioService.listaUsuarioPorRutyRol(Integer.parseInt(rut), 3);
		
		if(usuario==null) {
			model.addAttribute("error", "Usuario ingresado no está registrado!");
		}else {			
			EmailBodyDto emailBody = new EmailBodyDto();
			emailBody.setEmail(usuario.getEmail());
			emailBody.setSubject("Recuperar password");
			emailBody.setContent("Su nueva password es ");
			
			String resultado = "Email enviado !!";
			if(!emailService.sendEmail(emailBody)) {
				resultado = "No se pudo enviar el email, intenta mas tarde";
			}
			System.out.println("resultado:"+resultado);
			model.addAttribute("resultado", resultado);
		}
		
		model.addAttribute("tiposClientes", usuarioService.listarRoles());
		
		return "login";
	}
	
	@GetMapping("/registrarse")
	public String registrarse(Model model) {
		model.addAttribute("usuario", new UsuarioDto());
		return "registrarse";
	}
	
	@PostMapping("/crearUsuario")
	public String crearUsuario(@ModelAttribute UsuarioDto usuarioDto, Model model) {		
		String rut = usuarioDto.getRut().replaceAll("-", "");
		String dv = rut.substring(rut.length() - 1);
		rut = rut.substring(0, rut.length() - 1);
		
		Rol rol = new Rol();
		rol.setIdRol(3);
		
		Usuario user = new Usuario();
		user.setRut(Integer.parseInt(rut));
		user.setDv(dv);
		user.setNombre(usuarioDto.getNombre());
		user.setApellidos(usuarioDto.getApellidos());
		user.setDireccion(usuarioDto.getDireccion());
		user.setTelefono(usuarioDto.getTelefono());
		user.setEmail(usuarioDto.getEmail());
		user.setPassword(usuarioDto.getPassword());
		user.setRol(rol);
		
		String resultado = usuarioService.crearUsuario(user);
		
		if(resultado.toUpperCase().contains("ERROR")) {			
			model.addAttribute("usuario", usuarioDto);			
			model.addAttribute("error", resultado);
			return "registrarse";
		}
		
		return "login";
	}
	
	@ModelAttribute("tiposClientes")
	public List<Rol> listarRoles(){			
		List<Rol> listaRoles = usuarioService.listarRoles();
		return listaRoles;
	}
	
	@GetMapping(path = "/pdf")
    public ModelAndView report() {

        /*JasperReportsPdfView view = new JasperReportsPdfView();
        view.setUrl("classpath:report2.jrxml");
        view.setApplicationContext(appContext);

        Map<String, Object> params = new HashMap<>();
        params.put("datasource", usuarioService.listarUsuarios());

        return new ModelAndView(view, params);*/
		return new ModelAndView("");
    }
}
