using UnityEngine;
using System.Collections;

public class torusCastShadow : MonoBehaviour
{

    // Use this for initialization

    private Transform torusShadow1;
    private Transform torusShadow2;
    private Transform torusShadow3;
    private GameObject torusShadow1Obj;
    private GameObject torusShadow2Obj;
    private GameObject torusShadow3Obj;
    private Vector3 shadowPostion;
    private GameObject Light1;
    private GameObject Light2;
    private GameObject Light3;
    private Renderer torusRender1;
    private Renderer torusRender2;
    private Renderer torusRender3;
    private float finalTransparency1;
    private float finalTransparency2;
    private float finalTransparency3;
    private Material Shadow;
    private Material Shadow2;
    private Material Shadow3;
    public float torusShadowHeight;



    void Start()
    {

    }

    void OnEnable()
    {
        torusShadow1Obj = GameObject.Find("torusShadow");
        torusShadow2Obj = GameObject.Find("torusShadow2");
        torusShadow3Obj = GameObject.Find("torusShadow3");

        torusShadow1 = GameObject.Find("torusShadow").transform;
        torusShadow2 = GameObject.Find("torusShadow2").transform;
        torusShadow3 = GameObject.Find("torusShadow3").transform;

        Light1 = GameObject.Find("DirectionalLight1");
        Light2 = GameObject.Find("DirectionalLight2");
        Light3 = GameObject.Find("DirectionalLight3");

        torusRender1 = torusShadow1Obj.GetComponent<Renderer>();
        torusRender2 = torusShadow2Obj.GetComponent<Renderer>();
        torusRender3 = torusShadow3Obj.GetComponent<Renderer>();

        Shadow = Resources.Load("Materials/Shadow", typeof(Material)) as Material;
        Shadow2 = Resources.Load("Materials/Shadow2", typeof(Material)) as Material;
        Shadow3 = Resources.Load("Materials/Shadow3", typeof(Material)) as Material;






    }

    // Update is called once per frame
    void Update()
    {
        GameObject arrayRan = GameObject.Find("sceneOrderData");
        random randomScript = arrayRan.GetComponent<random>();

        BoxCollider b = gameObject.GetComponent<BoxCollider>();

        torusShadow1.transform.localScale = gameObject.transform.localScale; 
        torusShadow1.transform.rotation = gameObject.transform.rotation;

        torusShadow2.transform.localScale = gameObject.transform.localScale;
        torusShadow2.transform.rotation = gameObject.transform.rotation;

        torusShadow3.transform.localScale = gameObject.transform.localScale;
        torusShadow3.transform.rotation = gameObject.transform.rotation;


        //Shadow follow center point calculated




        Vector3 cal = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f) - Light3.transform.position;
        Vector3 newCal = new Vector3(cal.x * .899f, cal.y * .899f, gameObject.transform.position.z + cal.z * .899f);


        Vector3 cal3 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light3.transform.position;
        Vector3 newCal3 = new Vector3(cal3.x * .899f, cal3.y * .899f, gameObject.transform.position.z + cal3.z * .899f);


        //shadow Positon
        Vector3 centerCal = new Vector3(newCal3.x + newCal.x, torusShadowHeight, newCal3.z - (newCal3.z - newCal.z) * 0.5f);

        //=============================

  
        Vector3 cal5 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f) - Light2.transform.position;
        Vector3 newCal5 = new Vector3(cal5.x * .899f, cal5.y * .899f, gameObject.transform.position.z + cal5.z * .899f);



        Vector3 cal7 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light2.transform.position;
        Vector3 newCal7 = new Vector3(cal7.x * .899f, cal7.y * .899f, gameObject.transform.position.z + cal7.z * .899f);



        //shadow Positon
        Vector3 centerCal2 = new Vector3(newCal7.x + newCal5.x, torusShadowHeight, newCal7.z - (newCal7.z - newCal5.z) * 0.5f);
        //===============================



        Vector3 cal9 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f) - Light1.transform.position;
        Vector3 newCal9 = new Vector3(cal9.x * .899f, cal9.y * .899f, gameObject.transform.position.z + cal9.z * .899f);


        Vector3 cal11 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light1.transform.position;
        Vector3 newCal11 = new Vector3(cal11.x * .899f, cal11.y * .899f, gameObject.transform.position.z + cal11.z * .899f);



        //shadow Positon
        Vector3 centerCal3 = new Vector3(newCal11.x + newCal9.x, torusShadowHeight, newCal11.z - (newCal11.z - newCal9.z) * 0.5f);



        torusShadow1Obj.transform.position = new Vector3(centerCal.x, centerCal.y, centerCal.z);
        torusShadow2Obj.transform.position = new Vector3(centerCal2.x, centerCal2.y, centerCal2.z);
        torusShadow3Obj.transform.position = new Vector3(centerCal3.x, centerCal3.y, centerCal3.z);




        // calculate distance between object and lights to determine transparency

        //light 1 position z = object position.z
        float distance1 = Mathf.Abs(Light3.transform.position.z - gameObject.transform.position.z);
        float distance2 = Mathf.Abs(Light2.transform.position.z - gameObject.transform.position.z);
        float distance3 = Mathf.Abs(Light1.transform.position.z - gameObject.transform.position.z);

       // UnityEngine.Debug.Log("Distance 1 : " + distance1);
       // UnityEngine.Debug.Log("Distance 2 : " + distance2);
       // UnityEngine.Debug.Log("Distance 3 : " + distance3);


         if (distance1 >= 1)
         {
             finalTransparency1 = 0;
             //UnityEngine.Debug.Log("In 1 if");
            torusRender1.material.color = new Color(0, 0, 0, 0);
            //UnityEngine.Debug.Log("1: " + finalTransparency1);


        }
         else
         {
             float transparency1 = 1 - distance1;
             //finalTransparency1 = transparency1;
             torusRender1.material.color = new Color(0, 0, 0, transparency1);
            //UnityEngine.Debug.Log("1: " + transparency1);
        }


         if (distance2 >= 1)
         {
             finalTransparency2 = 0;
             torusRender2.material.color = new Color(0, 0, 0, 0);
            // UnityEngine.Debug.Log("2: " + finalTransparency2);
        }
         else
         {
             float transparency2 = 1- distance2;
             //finalTransparency2 = transparency2;
             torusRender2.material.color = new Color(0, 0, 0, transparency2);
            //UnityEngine.Debug.Log("2: " + transparency2);
        }


         if (distance3 >= 1)
         {
            finalTransparency3 = 0;
            torusRender3.material.color = new Color(0, 0, 0, 0);
            //UnityEngine.Debug.Log("3:" + finalTransparency3);
        }
         else
         {
             float transparency3 =  1 - distance3;
             torusRender3.material.color = new Color(0, 0, 0, transparency3);
            //UnityEngine.Debug.Log("3:" + transparency3);
        }
         




        
        
        








        /*
        // if the scene has billboarding, have the shadow follow the rotation of the object
        string sceneName = randomScript.sceneOrder[GlobalControl.counter].sceneName;
        char billboard = sceneName[2];
        if(billboard == '1')
        {
            /*Vector3 lookAtPosition = Camera.main.transform.position;
            lookAtPosition.y = torusShadow.position.y;
            torusShadow.transform.LookAt(lookAtPosition);


            Vector3 worldLookDirection = transform.position - Camera.main.transform.position;
            Vector3 localLookDirection = transform.InverseTransformDirection(worldLookDirection);
            localLookDirection.y = 0;
            transform.forward = transform.rotation * localLookDirection;*/




        

    }





}
