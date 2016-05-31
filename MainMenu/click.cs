using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class click : MonoBehaviour {
	public GameObject Back_Button;

    void OnMouseDown()
    {
		SceneManager.LoadScene ("menu");
    }
}
