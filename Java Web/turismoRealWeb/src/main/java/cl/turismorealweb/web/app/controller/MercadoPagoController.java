package cl.turismorealweb.web.app.controller;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

import com.mercadopago.*;
import com.mercadopago.exceptions.MPConfException;
import com.mercadopago.exceptions.MPException;
import com.mercadopago.resources.Payment;
import com.mercadopago.resources.Preference;
//import com.mercadopago.resources.Preference;
import com.mercadopago.resources.datastructures.payment.Identification;
import com.mercadopago.resources.datastructures.preference.Item;
//import com.mercadopago.resources.datastructures.preference.Payer;
import com.mercadopago.resources.datastructures.payment.Payer;

@Controller
public class MercadoPagoController {

	@Value("${mercadopago.client.token}")
	private String accessToken;
	
	
	/*
	 * Integra Checkout API para pagos con tarjetas
	 * */
	@PostMapping("/process_payment_chile")
	public String process_paymentChile(@RequestParam(value = "transactionAmount") Float transactionAmount
							   ,@RequestParam(value = "description") String description
							   ,@RequestParam(value = "installments") Integer installments
							   ,@RequestParam(value = "paymentMethodId") String paymentMethodId
							   ,@RequestParam(value = "docType") String docType
							   ,@RequestParam(value = "docNumber") String docNumber
							   ,@RequestParam(value = "email") String email
							   ,@RequestParam(value = "token") String token
			                   ,Model model) {
		
		try {
			MercadoPago.SDK.setAccessToken(accessToken);
		} catch (MPConfException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}

		Payment payment = new Payment();
		payment.setTransactionAmount(transactionAmount)
		       .setToken(token)
		       .setDescription(description)
		       .setInstallments(installments)
		       .setPaymentMethodId(paymentMethodId);

		Identification identification = new Identification();
		identification.setType(docType)
		              .setNumber(docNumber);

		Payer payer = new Payer();
		payer.setEmail(email)
		     .setIdentification(identification);

		payment.setPayer(payer);

		try {
			payment.save();
		} catch (MPException e) {
			e.printStackTrace();
		}catch (Exception e) {
			e.printStackTrace();
		}

		System.out.println("status:"+payment.getStatus());
		System.out.println("status_detail:"+payment.getStatusDetail());
		System.out.println("id:"+payment.getId());
		System.out.println("date_approved:"+payment.getDateApproved());
		System.out.println("payment_method_id:"+payment.getPaymentMethodId());
		System.out.println("payment_type_id:"+payment.getPaymentTypeId());
		
		return "login";
	}	
}
