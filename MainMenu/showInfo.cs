using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showInfo : MonoBehaviour
{
    public GUITexture info;

    void Start()
    {
       this.info.enabled = false;
    }

	void Update()
	{

	}
    
    IEnumerator DelayTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.info.enabled = false;
    }
    
    void OnMouseDown()
    {
        //this.info.enabled = true;

		if (this.info.enabled) {
			this.info.enabled = false;
		} else {
			this.info.enabled = true;
		}
		  
    }
		


}
