package cl.turismorealweb.web.app.entitie;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

@Entity
public class CheckListMulta implements Serializable{

	private static final long serialVersionUID = 6441267094118041915L;
	
	@Column(name="CHECK_LIST_ID")
	@Id
	@GeneratedValue
	private Integer checkListId;
	
	@Column(name="MULTA_ID")
	@Id
	@GeneratedValue
	private Integer multaId;
	
	@Column(name="COMENTARIO_USUARIO")
	private Integer comentarioUsuario;
	

}
