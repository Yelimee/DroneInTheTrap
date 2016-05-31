using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;


public class MenuButtons : MonoBehaviour
{

    public GUITexture info;
    public GUITexture startUnpressed;
    public GUITexture startPressed;
    public GUITexture InfoUnpressed;
    public GUITexture InfoPressed;
    public GUITexture EndUnpressed;
    public GUITexture EndPressed;
  

    void Start()
    {
        this.info.enabled = false;
    }

    

}



