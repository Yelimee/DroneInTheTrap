using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;

public class clicked3 : MonoBehaviour {

    void OnMouseDown()
    { 
        SceneManager.LoadScene("Stage3");
    }
}
