using UnityEngine;
using System.Collections;

public class Fog : MonoBehaviour {



	// Use this for initialization
	void Start () {

        RenderSettings.fog = false;


    }
	
	// Update is called once per frame
	void Update () {

        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogStartDistance = 0;
        RenderSettings.fogEndDistance = 5;
        RenderSettings.fogColor = Color.gray;





    }
}
