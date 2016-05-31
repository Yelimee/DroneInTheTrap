using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;


public class clicked2 : MonoBehaviour {
    void OnMouseDown()
    {
        SceneManager.LoadScene("Stage2");
    }
}
