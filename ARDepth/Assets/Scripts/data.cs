using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using System.Diagnostics;






public class data : MonoBehaviour {

    // Use this for initialization

    //public string path;
    //public float startTime = Time.time;

    public Billboarding BillboardScript;
    public torusCastShadow CastShadowScript;
    public Renderer cube;
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public GameObject target6;
    public GameObject target7;
    public GameObject target8;
    public GameObject shadow;
    public Vector3 objectPosition;
    public float startTimer;
    public float endTimer;
    public float startTime;
    public float endTime;
    public bool practice;
    public GameObject target1Ground;
    public GameObject target2Ground;
    public GameObject target3Ground;
    public GameObject target4Ground;
    public GameObject target5Ground;
    public GameObject target6Ground;
    public GameObject target7Ground;
    public GameObject target8Ground;
    public Vector3 targetPosition;


    void Start () {
        UnityEngine.Debug.Log("ITS WORKING!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

        //GameObject torus = GameObject.Find("Torus");


        cube = gameObject.GetComponent<Renderer>();

        // ======================Target Words==========================
        target1 = GameObject.Find("target_1");
        target1.SetActive(false);

        target2 = GameObject.Find("target_2");
        target2.SetActive(true);

        target3 = GameObject.Find("target_3");
        target3.SetActive(false);

        target4 = GameObject.Find("target_4");
        target4.SetActive(false);

        target5 = GameObject.Find("target_5");
        target5.SetActive(false);

        target6 = GameObject.Find("target_6");
        target6.SetActive(false);

        target7 = GameObject.Find("target_7");
        target7.SetActive(false);

        target8 = GameObject.Find("target_8");
        target8.SetActive(false);
        //=======================================================


        //======================Ground Targets===================
        target1Ground = GameObject.Find("Bar1");

        target2Ground = GameObject.Find("Bar2");

        target3Ground = GameObject.Find("Bar3");

        target4Ground = GameObject.Find("Bar4");

        target5Ground = GameObject.Find("Bar5");

        target6Ground = GameObject.Find("Bar6");

        target7Ground = GameObject.Find("Bar7");

        target8Ground = GameObject.Find("Bar8");

        string words = "Scene Number, Scene Name, Target Number, Cube Size, CubeStartingPositionX, CubeStartingPositionY, CubeStartingPositionZ, RotationY, FinalCubePositionX, FinalCubePositionY, FinalCubePositionZ, Time Taken, PositionOfTargetX, PositionOfTargetY, PositionOfTargetZ, Error" + Environment.NewLine;
        UnityEngine.Debug.Log(words);

    }


    // Update is called once per frame
    void Update () {

        objectPosition = gameObject.transform.position;
        startTimer = Time.time;
        endTimer = Time.time;


      
    }


    public void next()
    {
        GameObject intro = GameObject.Find("Intro");
        intro.SetActive(true);
        //startTime = startTimer;
        practice = true;

    }



    public void setScene()
    {
        GameObject arrayRan = GameObject.Find("sceneOrderData");
        random randomScript = arrayRan.GetComponent<random>();

        //Material lambert = Resources.Load("lambert1", typeof(Material)) as Material;
        //Material blinn = Resources.Load("blinn1", typeof(Material)) as Material;
        //Material phong = Resources.Load("phong1", typeof(Material)) as Material;

        GameObject torus = GameObject.Find("Torus");
        GameObject plane = GameObject.Find("Plane");

        GameObject torusShadow = GameObject.Find("torusShadow");
        GameObject planeShadow = GameObject.Find("planeShadow");


        string sceneName = randomScript.sceneOrder[GlobalControl.counter].sceneName;

        char shape = sceneName[0];
        char castShadow = sceneName[1];
        char billboarding = sceneName[2];
        char textureDensity = sceneName[3];
        char shader = sceneName[4];

        //=======================Shape=======================
        if (shape == '1')
        {
            torus.SetActive(true); //Torus on
            plane.SetActive(false);
        }
        else
        {
            plane.SetActive(true); //Plane on
            torus.SetActive(false);
        }

        //=======================Cast Shadow=======================
        if (castShadow == '1') //Cast shadow off
        {
            if (shape == '1') //Torus
            {
                torusShadow.SetActive(true);
                //CastShadowScriptTorus.enabled = true;
            }
            else //Plane
            {
                planeShadow.SetActive(true);
                //CastShadowScriptPlane.enabled = true;
            }
        }
        else //Cast shadow off
        {
            if (shape == '1')//Torus
            {
                torusShadow.SetActive(false);
                //CastShadowScriptTorus.enabled = false;
            }
            else //Plane
            {
                planeShadow.SetActive(false);
                //CastShadowScriptPlane.enabled = false;
            }
        }

        //=======================Billboarding=======================
        if (billboarding == '1')
        {
            BillboardScript.enabled = true;
        }
        else
        {
            BillboardScript.enabled = false;
        }

        //=======================textureDensity=======================
        if (textureDensity == '1')
        {
            //shape.texture = checker;
        }
        else
        { 
            //shape color = grey/blue
        }

        //=======================Shader=======================
        if (shader == '0')
        {
            //shape.material = lambert;
        }
        else if (shader == '1')
        {
            //shape.material = blinn;
        }
        else
        {
            //shape.material = phong;
        }


       
        //Get the postion of that target
        //GameObject targetPostion = GameObject.Find("Target" + target);
        //Vector3 pos = targetPostion.transform.localPosition;


        //Get and set the random size of the cube
        float randomCubeSize = randomScript.sceneOrder[GlobalControl.counter].size;
        gameObject.transform.localScale = new Vector3(randomCubeSize, randomCubeSize, randomCubeSize);

        //Get the starting postion of that cube
        float positionX = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionX;
        float positionY = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionY;
        float positionZ = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionZ;
        gameObject.transform.localPosition = new Vector3(positionX, positionY, positionZ);

        float rotationY = randomScript.sceneOrder[GlobalControl.counter].rotationY;
        gameObject.transform.rotation = Quaternion.Euler(0, rotationY, 0);


        //string data = "       " + randomScript.sceneOrder[GlobalControl.counter].sceneName + " , " + randomScript.sceneOrder[GlobalControl.counter].targetNum + " , " + randomScript.sceneOrder[GlobalControl.counter].size + " , (" + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionX + ", " + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionY + ", " + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionZ + ")";

        // Exception e = new Exception(data);
        //throw e;


        //string thing = targetNum.ToString() + pos + randomCubeSize + postion + Environment.NewLine;
        //File.AppendAllText(path, thing);

        practice = false;



        //---------------------------------------------------------------------------------------------------------------




        if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 1)
        {
            target1.SetActive(true);
            targetPosition = target1Ground.transform.position;

            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);
            target5.SetActive(false);
            target6.SetActive(false);
            target7.SetActive(false);
            target8.SetActive(false);
        }
        if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 2)
        {
            target1.SetActive(false);

            target2.SetActive(true);
            targetPosition = target2Ground.transform.position;

            target3.SetActive(false);
            target4.SetActive(false);
            target5.SetActive(false);
            target6.SetActive(false);
            target7.SetActive(false);
            target8.SetActive(false);
        }
        if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 3)
        {
            target1.SetActive(false);
            target2.SetActive(false);

            target3.SetActive(true);
            targetPosition = target3Ground.transform.position;

            target4.SetActive(false);
            target5.SetActive(false);
            target6.SetActive(false);
            target7.SetActive(false);
            target8.SetActive(false);
        }
        if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 4)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(false);

            target4.SetActive(true);
            targetPosition = target4Ground.transform.position;

            target5.SetActive(false);
            target6.SetActive(false);
            target7.SetActive(false);
            target8.SetActive(false);
        }
        if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 5)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);

            target5.SetActive(true);
            targetPosition = target5Ground.transform.position;

            target6.SetActive(false);
            target7.SetActive(false);
            target8.SetActive(false);
        }
        if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 6)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);
            target5.SetActive(false);

            target6.SetActive(true);
            targetPosition = target6Ground.transform.position;

            target7.SetActive(false);
            target8.SetActive(false);
        }
        if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 7)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);
            target5.SetActive(false);
            target6.SetActive(false);

            target7.SetActive(true);
            targetPosition = target7Ground.transform.position;

            target8.SetActive(false);


        }
        if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 8)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);
            target5.SetActive(false);
            target6.SetActive(false);
            target7.SetActive(false);

            target8.SetActive(true);
            targetPosition = target8Ground.transform.position;
        }

    }




    /*public void setScene ()
    {

            GameObject arrayRan = GameObject.Find("sceneOrderData");
            random randomScript = arrayRan.GetComponent<random>();


            Material phong = Resources.Load("phong1", typeof(Material)) as Material;
            Material lambert = Resources.Load("lambert1", typeof(Material)) as Material;
            Material blinn = Resources.Load("blinn1", typeof(Material)) as Material;


            //castShadow   on/off  1/0
            //Fog          on/off  1/0
            //Billboarding on/off  1/0
            //Shader       Phong/Lambert/Blinn 0/1/2

            // Scene "0101" = castShadow off, Fog on, Billboarding off, Lambert shader



            //Scene 1
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0000")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = false;
                cube.material = phong;


            }
            //Scene 2
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0001")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = false;
                cube.material = lambert;


            }
            //Scene 3
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0002")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = false;
                cube.material = blinn;

            }
            //Scene 4
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0010")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = true;
                cube.material = phong;

            }
            //Scene 5
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0011")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = true;
                cube.material = lambert;

            }
            //Scene 6
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0012")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = true;
                cube.material = blinn;

            }
            //Scene 7
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0100")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = true;

                BillboardScript.enabled = false;
                cube.material = phong;

            }
            //Scene 8
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0101")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = true;

                BillboardScript.enabled = false;
                cube.material = lambert;
            }
            //Scene 9
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0102")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = true;

                BillboardScript.enabled = false;
                cube.material = blinn;

            }
            //Scene 10
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1000")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = false;
                cube.material = phong;

            }
            //Scene 11
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1001")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = false;
                cube.material = lambert;

            }
            //Scene 12
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1002")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = false;
                cube.material = blinn;

            }
            //Scene 13
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1100")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = true;

                BillboardScript.enabled = false;
                cube.material = phong;

            }
            //Scene 14
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1101")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = true;

                BillboardScript.enabled = false;
                cube.material = lambert;

            }
            //Scene 15
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1102")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = true;

                BillboardScript.enabled = false;
                cube.material = blinn;

            }
            //Scene 16
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0110")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = true;
                BillboardScript.enabled = true;
                cube.material = phong;

            }
            //Scene 17
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0111")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = true;

                BillboardScript.enabled = true;
                cube.material = lambert;

            }
            //Scene 18
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "0112")
            {
                shadow.SetActive(false);
                CastShadowScript.enabled = false;

                FogScript.enabled = true;

                BillboardScript.enabled = true;
                cube.material = blinn;

            }
            //Scene 19
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1010")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = true;
                cube.material = phong;

            }
            //Scene 20
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1011")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = true;
                cube.material = lambert;

            }
            //Scene 21
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1012")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = false;
                RenderSettings.fog = false;

                BillboardScript.enabled = true;
                cube.material = blinn;
            }
            //Scene 22
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1110")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = true;

                BillboardScript.enabled = true;
                cube.material = phong;

            }
            //Scene 23
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1111")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = true;

                BillboardScript.enabled = true;
                cube.material = lambert;

            }
            //Scene 24
            if (randomScript.sceneOrder[GlobalControl.counter].sceneName == "1112")
            {
                shadow.SetActive(true);
                CastShadowScript.enabled = true;

                FogScript.enabled = true;

                BillboardScript.enabled = true;
                cube.material = blinn;

            }

            //===========================Target Word===================
            if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 1)
            {
                target1.SetActive(true);
                targetPosition = target1Ground.transform.position;

                target2.SetActive(false);
                target3.SetActive(false);
                target4.SetActive(false);
                target5.SetActive(false);
                target6.SetActive(false);
                target7.SetActive(false);
                target8.SetActive(false);
            }
            if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 2)
            {
                target1.SetActive(false);

                target2.SetActive(true);
                targetPosition = target2Ground.transform.position;

                target3.SetActive(false);
                target4.SetActive(false);
                target5.SetActive(false);
                target6.SetActive(false);
                target7.SetActive(false);
                target8.SetActive(false);
            }
            if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 3)
            {
                target1.SetActive(false);
                target2.SetActive(false);

                target3.SetActive(true);
                targetPosition = target3Ground.transform.position;

                target4.SetActive(false);
                target5.SetActive(false);
                target6.SetActive(false);
                target7.SetActive(false);
                target8.SetActive(false);
            }
            if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 4)
            {
                target1.SetActive(false);
                target2.SetActive(false);
                target3.SetActive(false);

                target4.SetActive(true);
                targetPosition = target4Ground.transform.position;

                target5.SetActive(false);
                target6.SetActive(false);
                target7.SetActive(false);
                target8.SetActive(false);
            }
            if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 5)
            {
                target1.SetActive(false);
                target2.SetActive(false);
                target3.SetActive(false);
                target4.SetActive(false);

                target5.SetActive(true);
                targetPosition = target5Ground.transform.position;

                target6.SetActive(false);
                target7.SetActive(false);
                target8.SetActive(false);
            }
            if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 6)
            {
                target1.SetActive(false);
                target2.SetActive(false);
                target3.SetActive(false);
                target4.SetActive(false);
                target5.SetActive(false);

                target6.SetActive(true);
                targetPosition = target6Ground.transform.position;

                target7.SetActive(false);
                target8.SetActive(false);
            }
            if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 7)
            {
                target1.SetActive(false);
                target2.SetActive(false);
                target3.SetActive(false);
                target4.SetActive(false);
                target5.SetActive(false);
                target6.SetActive(false);

                target7.SetActive(true);
                targetPosition = target7Ground.transform.position;

                target8.SetActive(false);

                
            }
            if (randomScript.sceneOrder[GlobalControl.counter].targetNum == 8)
            {
                target1.SetActive(false);
                target2.SetActive(false);
                target3.SetActive(false);
                target4.SetActive(false);
                target5.SetActive(false);
                target6.SetActive(false);
                target7.SetActive(false);

                target8.SetActive(true);
                targetPosition = target8Ground.transform.position;
        }

            //Get the postion of that target
            //GameObject targetPostion = GameObject.Find("Target" + target);
            //Vector3 pos = targetPostion.transform.localPosition;


            //Get and set the random size of the cube
            float randomCubeSize = randomScript.sceneOrder[GlobalControl.counter].size;
            gameObject.transform.localScale = new Vector3(randomCubeSize, randomCubeSize, randomCubeSize);

            //Get the starting postion of that cube
            float positionX = randomScript.sceneOrder[GlobalControl.counter].randomCubePositionX;
            float positionY = randomScript.sceneOrder[GlobalControl.counter].randomCubePositionY;
            float positionZ = randomScript.sceneOrder[GlobalControl.counter].randomCubePositionZ;
            gameObject.transform.localPosition = new Vector3(positionX, positionY, positionZ);

            float rotationY = randomScript.sceneOrder[GlobalControl.counter].rotationY;
            gameObject.transform.rotation = Quaternion.Euler(0, rotationY, 0);


            //string data = "       " + randomScript.sceneOrder[GlobalControl.counter].sceneName + " , " + randomScript.sceneOrder[GlobalControl.counter].targetNum + " , " + randomScript.sceneOrder[GlobalControl.counter].size + " , (" + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionX + ", " + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionY + ", " + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionZ + ")";

            // Exception e = new Exception(data);
            //throw e;


            //string thing = targetNum.ToString() + pos + randomCubeSize + postion + Environment.NewLine;
            //File.AppendAllText(path, thing);
            
             practice = false;
        
       



    }*/







    public void recordData()
    {
        if(!practice)
        {
            //record data
            GameObject arrayRan = GameObject.Find("sceneOrderData");
            random randomScript = arrayRan.GetComponent<random>();
            endTime = endTimer;
            float totalTimeTaken = endTime - startTime;

            float error = objectPosition.z - targetPosition.z;


            /*string data = "Scene Number: " + GlobalControl.counter + Environment.NewLine
                         + "Scene Name: " + randomScript.sceneOrder[GlobalControl.counter].sceneName + Environment.NewLine
                         + "TargetNum: " + randomScript.sceneOrder[GlobalControl.counter].targetNum + Environment.NewLine
                         + "cubeSize: " + randomScript.sceneOrder[GlobalControl.counter].size + Environment.NewLine
                         + "cubeStartingPosition: (" + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionX + ", " + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionY + ", " + randomScript.sceneOrder[GlobalControl.counter].randomCubePositionZ + ")" + Environment.NewLine
                         + "rotationDegreesY: " + randomScript.sceneOrder[GlobalControl.counter].rotationY + Environment.NewLine
                         + "cubeEndingPosition: " + cubePosition + Environment.NewLine
                         + "totalTimeTaken:" + totalTimeTaken + "s" + Environment.NewLine
                         + "positionOfTarget"+ randomScript.sceneOrder[GlobalControl.counter].targetNum +": (" + targetPosition.x   + ", " + targetPosition.y + ", " + targetPosition.z + ") , " + //Environment.NewLine
                         + "Error(CubePosition.z - TargetPosition.z): " + error;*/



            string data = GlobalControl.counter + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].sceneName + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].targetNum + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].size + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionX + ", " + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionY + ", " + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionZ + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].rotationY + //Environment.NewLine
             ", " + objectPosition.x + ", " + objectPosition.y + ", " + objectPosition.z + //Environment.NewLine
             ", " + totalTimeTaken +  //Environment.NewLine
             ", " +  targetPosition.x + ", " + targetPosition.y + ", " + targetPosition.z + //Environment.NewLine
             ", " + error;

            
            UnityEngine.Debug.Log(data);

            GlobalControl.counter++;
        }
        if (practice)
        {
            UnityEngine.Debug.Log("Done with practice scene");
        }


    }


    public void takeTime()
    {
        startTime = startTimer;
        

    }






}




