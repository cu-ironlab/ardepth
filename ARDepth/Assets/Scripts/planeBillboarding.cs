using UnityEngine;
using System.Collections;

public class planeBillboarding : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    /*void Update () {

        //Camera.main.transform.LookAt(transform.position, Vector3.up);
        Vector3 CameraPosition = new Vector3(Camera.main.transform.position.x,
                                       this.transform.position.y + 180,
                                       Camera.main.transform.position.z);
        this.transform.LookAt(CameraPosition);

    }*/

    public Transform lookAt;
	void Update()
	{
        Vector3 worldLookDirection = transform.position - Camera.main.transform.position; 
		Vector3 localLookDirection = transform.InverseTransformDirection(worldLookDirection);
		localLookDirection.y = 0;
		transform.forward = transform.rotation * localLookDirection;
	}
}
