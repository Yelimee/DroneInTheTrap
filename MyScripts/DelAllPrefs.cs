using UnityEngine;
using System.Collections;

// Yelim : To delete old saved data to test out new stages, just make this object and script enable and play
//         default nen disabled
//         play button again to stop the scene from running
//         then disable this obj and lets play
//         now all the save data is deleted

public class DelAllPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public string Attention = "";
}
