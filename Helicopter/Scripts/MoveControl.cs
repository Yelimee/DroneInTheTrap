using UnityEngine;
using System.Collections;

public class MoveControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
       // moveDrone();


    }

    void moveDrone()
    {
        var moveSpeed = 5;
        // var rotSpeed = 120;

        var amtMove = moveSpeed * Time.deltaTime;
        // var amtRot = rotSpeed * Time.deltaTime;

        var ver = Input.GetAxis("Vertical");
        // var hor = Input.GetAxis("Horizontal");
        var ang = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.back * -ver * amtMove);
        transform.Translate(Vector3.right * ang * amtMove);
        // transform.Rotate(Vector3.up * ang * amtRot);
    }
}
