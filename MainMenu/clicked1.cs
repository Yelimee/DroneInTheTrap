using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;

public class clicked1 : MonoBehaviour {
    
    void OnMouseDown(){ 
        SceneManager.LoadScene("Stage1");
    }
}
