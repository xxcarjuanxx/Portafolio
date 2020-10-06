package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

@Entity
public class CheckList implements Serializable{

	private static final long serialVersionUID = -3122213097208757939L;

	@Column(name="ID_CHECK_LIST")
	@Id
	@GeneratedValue
	private Integer idCheckList;
	
	@Column(name="TIPO_CHECK")
	private Integer tipocheck;
	
	@Column(name="ENTREGA_LLAVE")
	private Integer entregaLlave;
	
	@Column(name="ENTREGA_CONTROL_TV")
	private Integer entregaControlTv;
	
	@Column(name="ENTREGA_CONTROL_AIR")
	private Integer entregaControlAire;
	
	@Column(name="RECIBE_REGALO")
	private Integer recibeRegalo;
}
