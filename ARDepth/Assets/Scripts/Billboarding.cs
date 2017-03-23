using UnityEngine;
using System.Collections;

public class Billboarding : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



        //Cube follow camera
        transform.LookAt(Camera.main.transform.position, -Vector3.up);


    }
}
