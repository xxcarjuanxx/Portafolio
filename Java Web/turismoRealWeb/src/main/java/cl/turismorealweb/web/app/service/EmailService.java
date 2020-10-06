package cl.turismorealweb.web.app.service;

import javax.mail.MessagingException;
import javax.mail.internet.MimeMessage;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;
import org.springframework.stereotype.Service;

import cl.turismorealweb.web.app.models.EmailBodyDto;
import cl.turismorealweb.web.app.util.PasswordGeneratorUtils;

@Service
public class EmailService implements EmailPort{

	private static final Logger LOGGER = LoggerFactory.getLogger(EmailService.class);
	
	@Autowired
	private JavaMailSender sender;
	
	@Autowired
	UsuarioService usuarioService;
	
	@Override
	public boolean sendEmail(EmailBodyDto emailBody) {
		LOGGER.info("EmailBody: {}", emailBody.toString());
		return sendEmailTool(emailBody.getContent(),emailBody.getEmail(), emailBody.getSubject());
	}

	private boolean sendEmailTool(String textMessage, String email,String subject) {
		boolean send = false;
		MimeMessage message = sender.createMimeMessage();
		
		String passAlt = PasswordGeneratorUtils.getPassword(PasswordGeneratorUtils.MINUSCULAS
                +PasswordGeneratorUtils.MAYUSCULAS
                +PasswordGeneratorUtils.ESPECIALES,10);
		
		MimeMessageHelper helper = new MimeMessageHelper(message);
		try {
			helper.setTo(email);
			helper.setText(textMessage + passAlt, true);
			helper.setSubject(subject);
			sender.send(message);
			send = true;
			LOGGER.info("Mail enviado!");
			
			//usuarioService.cambiarClaveUsuario(rut, rol, passAlt);
		} 
		catch (MessagingException e) {
			LOGGER.error("Hubo un error al enviar el mail: {}", e);
		}
		catch (Exception e) {
			LOGGER.error("Hubo un error al enviar el mail: {}", e);
		}
		return send;
	}
}
