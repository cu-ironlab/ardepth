using UnityEngine;
using System.Collections;

public class castShadow : MonoBehaviour {

    // Use this for initialization

    private Transform shadowTransform;
    private Vector3 shadowPostion;
    //private GameObject shadow; 



	void Start () {



    }
    void OnEnable()
    {

        GameObject arrayRan = GameObject.Find("sceneOrderData");
        random randomScript = arrayRan.GetComponent<random>();

        shadowTransform = GameObject.Find("torusShadow").transform;

       
    }	

	// Update is called once per frame
	void Update () {


        GameObject arrayRan = GameObject.Find("sceneOrderData");
        random randomScript = arrayRan.GetComponent<random>();

        shadowTransform.transform.localScale = gameObject.transform.localScale * 0.1f;
        shadowTransform.transform.rotation = gameObject.transform.rotation;
        //Shadow follow cube

        shadowTransform.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y -1.65f, gameObject.transform.position.z);

        // If billboarding scene follow the cube rotation
        if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0010" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "0011" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "0012" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "0110" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "0111" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "0112" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "1010" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "1011" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "1012" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "1110" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "1111" || randomScript.sceneOrder[GlobalControl.counter].sceneName == "1112")
        {
            Vector3 lookAtPosition = Camera.main.transform.position;
            lookAtPosition.y = shadowTransform.position.y;
            shadowTransform.transform.LookAt(lookAtPosition);
        }





    }





}
