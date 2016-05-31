using UnityEngine;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using UnityEngine.SceneManagement;
using System;

public class showDroneEdu : MonoBehaviour
{
    IEnumerator DelayTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("menu");
    }

    void OnMouseDown()
    {
        StartCoroutine(DelayTime(1)); // soryung: change 3 into 1 because of delay
    }
}
