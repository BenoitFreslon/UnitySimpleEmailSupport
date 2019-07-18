////////////////////////////////////////////////////////////////////////////////
//  
// @author Benoît Freslon @benoitfreslon
// https://github.com/BenoitFreslon/UnitySimpleEmailSupport
// https://benoitfreslon.com
//
////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SimpleEmailSupport : MonoBehaviour
{
	// Replace to your support email
	public string myEmail = "support@mystudio.com";

	// No space char in the subject
	public string subject = "[MyGame] Feedback";

	public void SendEmail()
	{
		string body = "\n\n----"
			+ "\nVersion: " + Application.version
			+ "\nSystem: " + SystemInfo.operatingSystem
			+ "\nPlateform: " + SystemInfo.deviceModel
			+ "\nLanguage: " + Application.systemLanguage;

		body = UnityWebRequest.EscapeURL(body).Replace("+", "%20");
		subject = subject.Replace(" ", "%20");

		string emailToSend = "mailto:" + myEmail + "?subject=" + subject + "&body=" + body;

		Debug.Log("Send Email: " + emailToSend);

		Application.OpenURL(emailToSend);
	}
}
