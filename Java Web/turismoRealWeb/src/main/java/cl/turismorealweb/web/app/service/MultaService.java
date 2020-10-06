package cl.turismorealweb.web.app.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.turismorealweb.web.app.dao.MultaDao;
import cl.turismorealweb.web.app.entitie.Multa;

@Service
public class MultaService {

	@Autowired
	private MultaDao multaDao;
	
	public List<Multa> listarMultas(){
		return multaDao.listarMultas();
	}
	
	public Multa listarMultaPorId(int idMulta) {
		return multaDao.listarMultaPorId(idMulta);
	}
	
	public String crearMulta(Multa multa) {
		return multaDao.crearMulta(multa);
	}
}
