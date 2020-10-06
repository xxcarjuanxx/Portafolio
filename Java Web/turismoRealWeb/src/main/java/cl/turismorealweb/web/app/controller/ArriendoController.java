package cl.turismorealweb.web.app.controller;

import java.util.Random;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import com.transbank.webpay.wswebpay.service.WsInitTransactionOutput;
import com.transbank.webpay.wswebpay.service.TransactionResultOutput;
import com.transbank.webpay.wswebpay.service.WsTransactionDetailOutput;

import cl.transbank.webpay.configuration.Configuration;
import cl.transbank.webpay.Webpay;
import cl.transbank.webpay.WebpayNormal;

@Controller
public class ArriendoController {

	@GetMapping("/webPay")
	public String webPay(Model model) {
		
		WebpayNormal transaction = null;
		
		try {
			transaction = new Webpay(Configuration.forTestingWebpayPlusNormal()).getNormalTransaction();
		} catch (Exception e) {
			e.printStackTrace();
		}
				
		//597020000540
		
		double amount = 1000;
		// Identificador que será retornado en el callback de resultado:
		String sessionId = "mi-id-de-sesion";
		// Identificador único de orden de compra:
		String buyOrder = String.valueOf(Math.abs(new Random().nextLong()));
		String returnUrl = "https://callback/resultado/de/transaccion";
		String finalUrl = "https://callback/final/post/comprobante/webpay";
		WsInitTransactionOutput initResult = transaction.initTransaction(amount, sessionId, buyOrder, returnUrl, finalUrl);

		String formAction = initResult.getUrl();
		String tokenWs = initResult.getToken();
		
		
		TransactionResultOutput result = transaction.getTransactionResult(tokenWs);
		WsTransactionDetailOutput output = result.getDetailOutput().get(0);
		if (output.getResponseCode() == 0) {
		    // Transaccion exitosa, puedes procesar el resultado con el contenido de
		    // las variables result y output.
		}
		
		model.addAttribute("output", output.getResponseCode());
		
		return "login";
	}
}
