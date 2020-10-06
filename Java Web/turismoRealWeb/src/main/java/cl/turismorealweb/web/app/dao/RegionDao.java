package cl.turismorealweb.web.app.dao;

import java.util.List;

import org.springframework.stereotype.Repository;

import cl.turismorealweb.web.app.entitie.Region;

public interface RegionDao {

	public List<Region> listarRegiones();
	public Region listarRegionPorId(Integer idRegion);
}
