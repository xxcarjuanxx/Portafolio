package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

@Entity
public class Huesped implements Serializable{

	private static final long serialVersionUID = -5927920125404322175L;

	@Column(name="RUT_HUESPED")
	@Id
	@GeneratedValue
	private Integer rutHuesped;
	
	@Column(name="DV_HUESPED")
	private String dvHuesped;
	
	@Column(name="NOMBRES_HUESPED")
	private String nombreHuesped;
	
	@Column(name="APELLIDOS_HUESPED")
	private String apellidoHuesped;
	
	@Column(name="TELEFONO_HUESPED")
	private Integer telefonoHuesped;
	
	
}
