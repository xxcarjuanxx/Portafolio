package cl.turismorealweb.web.app.service;

import cl.turismorealweb.web.app.models.EmailBodyDto;

public interface EmailPort {

	public boolean sendEmail(EmailBodyDto emailBody);
}
