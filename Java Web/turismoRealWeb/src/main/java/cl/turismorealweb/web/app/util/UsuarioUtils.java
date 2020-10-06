package cl.turismorealweb.web.app.util;

import java.sql.Blob;

import org.apache.commons.codec.binary.Base64;
import java.text.DecimalFormat;

public class UsuarioUtils {

	public static String validarRut(String rut, String dv) {

		String error = "";
		int multiplica = 2, suma = 0, numDigito = 0;

		dv = dv.toUpperCase();
		boolean digitoCorrecto = false;

		if (dv.isEmpty()) {
			error += " - Debe ingresar digito verificador";
		}

		if (rut.length() <= 6) {
			error += "- Largo de Rut incorrecto.";
		}

		if (rut.isEmpty()) {
			error += "- Debe ingresar el rut";
		} else {

			for (int i = (rut.length() - 1); i >= 0; i--) {
				suma = suma + Integer.parseInt(rut.substring(i, i + 1)) * multiplica;
				multiplica++;
				if (multiplica == 8) {
					multiplica = 2;
				}
			}

			numDigito = 11 - (suma % 11);
			if (numDigito == 10 && dv.equals("K")) {
				digitoCorrecto = true;
			} else if (numDigito == 11 && Integer.parseInt(dv) == 0) {
				digitoCorrecto = true;
			} else if (numDigito == Integer.parseInt(dv)) {
				digitoCorrecto = true;
			}
			if (digitoCorrecto == false) {
				error += "- Rut no valido.";
			}
		}

		if (error.isEmpty()) {
			return "ok" + "Rut Validado";
		} else {
			return "error" + error;
		}
	}
	
	//Metodo para encriptar una clave
    public static String encriptarClave(String clave)
    {
        char array[] = clave.trim().toCharArray();

        for (int i = 0; i < array.length; i++) 
        {
            array[i] = (char) (array[i] + (char) 5);
        }
        
        String encriptado = String.valueOf(array);
        
        return encriptado;
    }
    
    //Metodo para desencriptar una clave
    public static String desencriptarClave(String clave)
    {
        char arrayD[] = clave.trim().toCharArray();

        for (int i = 0; i < arrayD.length; i++) 
        {
            arrayD[i] = (char) (arrayD[i] - (char) 5);
        }

        String desencriptado = String.valueOf(arrayD);
        
        return desencriptado;
    }
    
    public static boolean esNumerico(String numero) {
    	try {
			Integer.parseInt(numero);
			return true;
		} catch (Exception e) {
			return false;
		}
    }
    
  //Separador de miles
    public static String separadorMiles(int valor){
        DecimalFormat formateador = new DecimalFormat("###,###.##");
        return formateador.format (valor);
    }
    
    public static String prueba() {
        return "Hola mundooooo";
    }
	
	 //Rellena la cadena por la derecha hasta la longitud n con el caracter definido
    public static String rPad(String texto, int largo) {
        return String.format("%1$-" + largo + "s", texto);
    }
    
    //Rellena la cadena por la izquierda hasta la longitud n con el caracter definido
    public static String lPad(String texto, int largo) {
        return String.format("%1$" + largo + "s", texto);
    }
    
    public static String encodeBlobToBase64(Blob data){      
	    String base64Str = "";
	    byte[] blobToBytes = null;
	    
	    try {   
	        if(data != null && data.length() > 0){
	            blobToBytes = data.getBytes(1l, (int) data.length());
	            base64Str = Base64.encodeBase64String(blobToBytes);
	        }
	    } catch (Exception e) {
	        System.err.println("encodeBlobToBase64 error" + e);
	    }
	    
	    return base64Str;
	}
}
