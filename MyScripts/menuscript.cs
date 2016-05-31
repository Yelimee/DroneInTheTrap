using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class menuscript : MonoBehaviour
{
	public GameObject InfoButton;
	public GameObject InfoPanel;


	// Use this for initialization
	public static menuscript runtime;

	private void Awake()
	{
		runtime = this;
	}

	void Start ()
	{
	}

	// Update is called once per frame
	void Update () {

	}

	private void ShowInfoPanel(bool isShow)
	{
		InfoButton.SetActive(!isShow);
		InfoPanel.SetActive(isShow);
	}

	public void ShowInfo()
	{
		ShowInfoPanel(true);
	}
	public void HideInfo()
	{
		ShowInfoPanel(false);
	}

	private void ShowStartPanel(bool isShow)
	{
		InfoButton.SetActive(!isShow);
	}
		
}
