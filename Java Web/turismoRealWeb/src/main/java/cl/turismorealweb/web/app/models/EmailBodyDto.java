package cl.turismorealweb.web.app.models;

public class EmailBodyDto {

	private String content;
	private String email;
	private String subject;
	
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getSubject() {
		return subject;
	}
	public void setSubject(String subject) {
		this.subject = subject;
	}
	
	@Override
	public String toString() {
		return "EmailBodyDto [content=" + content + ", email=" + email + ", subject=" + subject + "]";
	}		
}
