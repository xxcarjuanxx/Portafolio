package cl.turismorealweb.web.app.models;

import cl.turismorealweb.web.app.entitie.Rol;

public class RolDto {
	
	private Integer idRol;
	private String descripcionRol;
	
	public RolDto() {
		
	}
	
	public RolDto(Rol r) {
		this.idRol = r.getIdRol();
		this.descripcionRol = getDescripcionRol();
	}
	
	public Integer getIdRol() {
		return idRol;
	}
	public void setIdRol(Integer idRol) {
		this.idRol = idRol;
	}
	public String getDescripcionRol() {
		return descripcionRol;
	}
	public void setDescripcionRol(String descripcionRol) {
		this.descripcionRol = descripcionRol;
	}
}
