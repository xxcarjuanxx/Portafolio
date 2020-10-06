package cl.turismorealweb.web.app.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.turismorealweb.web.app.dao.ComunaDao;
import cl.turismorealweb.web.app.dao.ProvinciaDao;
import cl.turismorealweb.web.app.dao.RegionDao;
import cl.turismorealweb.web.app.entitie.Comuna;
import cl.turismorealweb.web.app.entitie.Provincia;
import cl.turismorealweb.web.app.entitie.Region;

@Service
public class ComunaService {

	@Autowired
	private ComunaDao comunaDao;
	
	@Autowired
	private ProvinciaDao provinciaDao;
	
	@Autowired
	private RegionDao regionDao;
	
	public List<Comuna> listarComunas(){
		return comunaDao.listarComunas();
	}
	
	public Comuna listarComunaPorId(Integer idComuna) {
		return comunaDao.listarComunaPorId(idComuna);
	}
	
	public List<Comuna> listarComunasPorIdProvincia(Integer idProvincia){
		return comunaDao.listarComunasPorIdProvincia(idProvincia);
	}
	
	public List<Provincia> listarProvincias(){
		return provinciaDao.listarProvincias();
	}
	
	public Provincia listarProvinciaPorId(Integer idProvincia) {
		return provinciaDao.listarProvinciaPorId(idProvincia);
	}
	
	public List<Provincia> listarProvinciasPorIdRegion(Integer idRegion){
		return provinciaDao.listarProvinciasPorIdRegion(idRegion);
	}
	
	public List<Region> listarRegiones(){
		return regionDao.listarRegiones();
	}
	
	public Region listarRegionPorId(Integer idRegion) {
		return regionDao.listarRegionPorId(idRegion);
	}
}
