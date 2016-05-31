// soryung: for CertificatePanel management
using UnityEngine;
using System.Collections;

public class CertificatePanelManager : MonoBehaviour {
	public GameObject CertificatePanel;

	// Use this for initialization
	void Start () {
		// HideCertificatePanel ();
	}
	
	void HideCertificatePanel()
	{
		CertificatePanel.SetActive (false);
	}
}
