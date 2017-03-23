using UnityEngine;
using System.Collections;

public class planeCastShadow : MonoBehaviour
{

    // Use this for initialization

    private Transform planeShadow1;
    private Transform planeShadow2;
    private Transform planeShadow3;
    private GameObject planeShadow1Obj;
    private GameObject planeShadow2Obj;
    private GameObject planeShadow3Obj;
    private Vector3 shadowPostion;
    private GameObject Light1;
    private GameObject Light2;
    private GameObject Light3;
    private Renderer planeRender1;
    private Renderer planeRender2;
    private Renderer planeRender3;
    private float finalTransparency1;
    private float finalTransparency2;
    private float finalTransparency3;
    //public Material ShadowMaterial;
    //public Material Shadow2Material;
    //public Material Shadow3Material;
     GameObject Shadows;
    public float planeShadowEyeLevel;
    private float shadowHeight;
    private float shadowHeight2;
    private float shadowHeight3;



    void Start()
    {

    }
    void OnEnable()
    {
        planeShadow1Obj = GameObject.Find("planeShadow1");
        planeShadow2Obj = GameObject.Find("planeShadow2");
        planeShadow3Obj = GameObject.Find("planeShadow3");


        planeShadow1 = GameObject.Find("planeShadow1").transform;
        planeShadow2 = GameObject.Find("planeShadow2").transform;
        planeShadow3 = GameObject.Find("planeShadow3").transform;

        Light1 = GameObject.Find("DirectionalLight1");
        Light2 = GameObject.Find("DirectionalLight2");
        Light3 = GameObject.Find("DirectionalLight3");

        planeRender1 = planeShadow1Obj.GetComponent<Renderer>();
        planeRender2 = planeShadow2Obj.GetComponent<Renderer>();
        planeRender3 = planeShadow3Obj.GetComponent<Renderer>();

        //ShadowMaterial = Resources.Load("Materials/PlaneShadow", typeof(Material)) as Material;
        //Shadow2Material = Resources.Load("Materials/PlaneShadow2", typeof(Material)) as Material;
        //Shadow3Material = Resources.Load("Materials/PlaneShadow3", typeof(Material)) as Material;

        Shadows = GameObject.Find("Shadows");








    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject arrayRan = GameObject.Find("sceneOrderData");
        random randomScript = arrayRan.GetComponent<random>();

        BoxCollider b = gameObject.GetComponent<BoxCollider>();

        Shadows.transform.rotation = gameObject.transform.rotation;

        planeShadow1.localScale = gameObject.transform.localScale;
        
        //planeShadow1Obj.transform.Rotate( 0, gameObject.transform.rotation.y , 0);
        //float rotation = planeShadow1.localRotation.y;
        //rotation = gameObject.transform.localRotation.y;
        //planeShadow1.transform.Rotate(0, gameObject.transform.rotation.eulerAngles.y, 0);
        //planeShadow1.localRotation = Quaternion.Euler(0, gameObject.transform.localRotation.eulerAngles.y, 0);
        // rotation= 90;






        planeShadow2.localScale = gameObject.transform.localScale;
        //planeShadow2.transform.Rotate(0, gameObject.transform.rotation.eulerAngles.y, 0);

        planeShadow3.localScale = gameObject.transform.localScale;
        //planeShadow3.transform.localRotation = Quaternion.Euler(0, gameObject.transform.rotation.y, 0);


        //Shadow follow center point calculated




        Vector3 cal = transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f) - Light2.transform.position;

        Vector3 newCal = new Vector3( cal.x, cal.y * 1.15f, gameObject.transform.position.z + cal.z * 1.15f);

        Vector3 cal4 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light2.transform.position;
        Vector3 newCal4 = new Vector3( cal4.x * .899f, cal4.y * .899f, gameObject.transform.position.z + cal4.z * .899f);

        Vector3 cal2 = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f) - Light2.transform.position;
        Vector3 newCal2 = new Vector3( cal2.x, cal2.y * 1.15f, gameObject.transform.position.z + cal2.z * 1.15f);

        Vector3 cal3 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light2.transform.position;
        Vector3 newCal3 = new Vector3( cal3.x * .899f, cal3.y * .899f, gameObject.transform.position.z + cal3.z * .899f);

        
        


        //shadow Positon
        Vector3 centerCal = new Vector3(newCal.x + newCal4.x, planeShadowEyeLevel, newCal4.z - (newCal4.z - newCal.z) * 0.5f);

        //UnityEngine.Debug.Log("ShadowHeight : " + -(cal.y * shadowHeight));

        //Change shape of shadow to postion
        planeShadow1Obj.transform.localScale = new Vector3(gameObject.transform.localScale.x, planeShadow1Obj.transform.localScale.y, Mathf.Abs(newCal3.z - newCal.z));
        //float rotation = planeShadow1Obj.transform.localRotation.y;
        //rotation = gameObject.transform.localRotation.y;


        //=======================


        Vector3 cal5 = transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f) - Light3.transform.position;
        Vector3 newCal5 = new Vector3(cal5.x, cal5.y * 1.15f, gameObject.transform.position.z + cal5.z * 1.15f);

        Vector3 cal8 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light3.transform.position;
        Vector3 newCal8 = new Vector3(cal8.x * .899f, cal8.y * .899f, gameObject.transform.position.z + cal8.z * .899f);
        
        Vector3 cal6 = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f) - Light3.transform.position;
        Vector3 newCal6 = new Vector3(cal6.x, cal6.y * 1.15f, gameObject.transform.position.z + cal6.z * 1.15f);

        Vector3 cal7 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light3.transform.position;
        Vector3 newCal7 = new Vector3( cal7.x * .899f, cal7.y * .899f, gameObject.transform.position.z + cal7.z * .899f);

        Vector3 centerCal2 = new Vector3(newCal5.x + newCal8.x, planeShadowEyeLevel, newCal8.z - (newCal8.z - newCal5.z) * 0.5f);

        //Change shape of shadow to postion
        planeShadow2Obj.transform.localScale = new Vector3(gameObject.transform.localScale.x, planeShadow2Obj.transform.localScale.y, Mathf.Abs(newCal7.z - newCal5.z));



        //===============================

        Vector3 cal9 = transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f) - Light1.transform.position;
        Vector3 newCal9 = new Vector3(cal9.x, cal9.y * 1.15f, gameObject.transform.position.z + cal9.z * 1.15f);

        Vector3 cal12 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light1.transform.position;
        Vector3 newCal12 = new Vector3(cal12.x * .899f, cal12.y * .899f, gameObject.transform.position.z + cal12.z * .899f);

        Vector3 cal11 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - Light1.transform.position;
        Vector3 newCal11 = new Vector3(cal11.x * .899f, cal11.y * .899f, gameObject.transform.position.z + cal11.z * .899f);

        Vector3 cal10 = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f) - Light1.transform.position;
        Vector3 newCal10 = new Vector3(cal10.x, cal10.y * 1.15f, gameObject.transform.position.z + cal10.z * 1.15f);

        //shadow Positon
        Vector3 centerCal3 = new Vector3(newCal9.x + newCal12.x, planeShadowEyeLevel, newCal12.z - (newCal12.z - newCal9.z) * 0.5f);

        //Change shape of shadow to postion
        planeShadow3Obj.transform.localScale = new Vector3(gameObject.transform.localScale.x, planeShadow3Obj.transform.localScale.y , Mathf.Abs(newCal11.z - newCal9.z));


        //=============================================
        planeShadow1Obj.transform.position = new Vector3(centerCal.x, planeShadowEyeLevel, centerCal.z);
        //UnityEngine.Debug.Log("CenterCaly : " + centerCal.y);
        planeShadow2Obj.transform.position = new Vector3(centerCal2.x, planeShadowEyeLevel, centerCal2.z);
        //UnityEngine.Debug.Log("CenterCaly : " + centerCal2.y);
        planeShadow3Obj.transform.position = new Vector3(centerCal3.x, planeShadowEyeLevel, centerCal3.z);
       // UnityEngine.Debug.Log("CenterCaly : " + centerCal3.y);




        // calculate distance between object and lights to determine transparency

        //light 1 position z = object position.z
        float distance1 = Mathf.Abs(Light2.transform.position.z - gameObject.transform.position.z);
        float distance2 = Mathf.Abs(Light3.transform.position.z - gameObject.transform.position.z);
        float distance3 = Mathf.Abs(Light1.transform.position.z - gameObject.transform.position.z);

        //UnityEngine.Debug.Log("Distance 1 : " + distance1);
        //UnityEngine.Debug.Log("Distance 2 : " + distance2);
        //UnityEngine.Debug.Log("Distance 3 : " + distance3);


        if (distance1 >= 1)
        {
            finalTransparency1 = 0;
            //UnityEngine.Debug.Log("In 1 if");
            planeRender1.material.color = new Color(0, 0, 0, 0);
            //UnityEngine.Debug.Log("1: " + finalTransparency1);


        }
        else
        {
            float transparency1 = 1 - distance1;
            //finalTransparency1 = transparency1;
            planeRender1.material.color = new Color(0, 0, 0, transparency1);
            //UnityEngine.Debug.Log("1: " + transparency1);
        }


        if (distance2 >= 1)
        {
            finalTransparency2 = 0;
            planeRender2.material.color = new Color(0, 0, 0, 0);
            // UnityEngine.Debug.Log("2: " + finalTransparency2);
        }
        else
        {
            float transparency2 = 1 - distance2;
            //finalTransparency2 = transparency2;
            planeRender2.material.color = new Color(0, 0, 0, transparency2);
            //UnityEngine.Debug.Log("2: " + transparency2);
        }


        if (distance3 >= 1)
        {
            finalTransparency3 = 0;
            planeRender3.material.color = new Color(0, 0, 0, 0);
            //UnityEngine.Debug.Log("3:" + finalTransparency3);
        }
        else
        {
            float transparency3 = 1 - distance3;
            planeRender3.material.color = new Color(0, 0, 0, transparency3);
            //UnityEngine.Debug.Log("3:" + transparency3);
        }









        // if the scene has billboarding, have the shadow follow the rotation of the object
        string sceneName = randomScript.sceneOrder[GlobalControl.counter].sceneName;
        char billboard = sceneName[2];
        //if (billboard == '1')
        //{
           /*Vector3 lookAtPosition = Camera.main.transform.position;
            lookAtPosition.y = planeShadow1.position.y;
            planeShadow1.transform.LookAt(lookAtPosition);

            lookAtPosition.y = planeShadow2.position.y;
            planeShadow2.transform.LookAt(lookAtPosition);

            lookAtPosition.y = planeShadow3.position.y;
            planeShadow3.transform.LookAt(lookAtPosition);*/


            /*Vector3 worldLookDirection = planeShadow1.transform.position - Camera.main.transform.position;
            Vector3 localLookDirection = planeShadow1.transform.InverseTransformDirection(worldLookDirection);
            localLookDirection.y = 0;
            planeShadow1.transform.forward = planeShadow1.transform.rotation * localLookDirection;/*

            /*Vector3 worldLookDirection2 = planeShadow2.transform.position - Camera.main.transform.position;
            Vector3 localLookDirection2 = planeShadow2.transform.InverseTransformDirection(worldLookDirection);
            localLookDirection.y = 0;
            planeShadow2.transform.forward = planeShadow2.transform.rotation * localLookDirection;

            Vector3 worldLookDirection3 = planeShadow3.transform.position - Camera.main.transform.position;
            Vector3 localLookDirection3 = planeShadow3.transform.InverseTransformDirection(worldLookDirection);
            localLookDirection.y = 0;
            planeShadow3.transform.forward = planeShadow3.transform.rotation * localLookDirection;*/




        //}

    }





}
