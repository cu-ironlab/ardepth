using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;
// Needed //////////////////////////////////////////////////
using HoloLensXboxController;
using System;
///////////////////////////////////////////////////////////
using UnityEngine.VR.WSA.Input;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity;
using System.IO;
using UnityEngine.SceneManagement;





public class moveObject : MonoBehaviour
{

    //Xbox Controller
    private ControllerInput controllerInput;

    private GestureRecognizer gestureRecognizer;
    public TextToSpeechManager textToSpeechManager;
    //private int count = 0;


    //Depth Cue Scripts
    public torusCastShadow torusCastShadowScript;
    public torusBillboarding torusBillboardingScript;

    public planeCastShadow planeCastShadowScript;
    public planeBillboarding planeBillboardingScript;

    //timers
    public float startTimer;
    public float endTimer;
    public float startTime;
    public float endTime;

    //target words
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject target4;
    public GameObject target5;
    public GameObject target6;
    public GameObject target7;
    public GameObject target8;

    //targets on the ground
    public GameObject target1Ground;
    public GameObject target2Ground;
    public GameObject target3Ground;
    public GameObject target4Ground;
    public GameObject target5Ground;
    public GameObject target6Ground;
    public GameObject target7Ground;
    public GameObject target8Ground;

    //Positions tracked
    public Vector3 targetPosition;
    public Vector3 torusPosition;
    public Vector3 planePosition;

    public Renderer renderTorus;
    public Renderer renderPlane;
    public float MoveZAxisSpeed = 0.04f;

    public bool practice;

    public GameObject torus;
    public GameObject plane;


    private GameObject torusShadow1Obj;
    private GameObject torusShadow2Obj;
    private GameObject torusShadow3Obj;

    private GameObject planeShadow1Obj;
    private GameObject planeShadow2Obj;
    private GameObject planeShadow3Obj;
    TextToSpeechManager tts;

    // Use this for initialization
    void Start()
    {
        controllerInput = new ControllerInput(0, 0.19f);

        //tts = gameObject.GetComponent<TextToSpeechManager>();
        

        //tts.SpeakText("This is the Practice Scene");

        //UnityEngine.Debug.Log("Data Script Start (Start)");


        torus = GameObject.Find("Torus");
        plane = GameObject.Find("Plane");

        renderTorus = torus.GetComponent<Renderer>();
        renderPlane = plane.GetComponent<Renderer>();

        torusBillboardingScript = torus.GetComponent<torusBillboarding>();
        planeBillboardingScript = plane.GetComponent<planeBillboarding>();

        torusCastShadowScript = torus.GetComponent<torusCastShadow>();
        planeCastShadowScript = plane.GetComponent<planeCastShadow>();

        //===========================For the practice scene==================================

        //Initialize objects
        //torus.transform.localRotation = Quaternion.identity;

        torus.SetActive(false);

        // ======================Target Words==========================
        target1 = GameObject.Find("target_1");
        target1.SetActive(false);

        target2 = GameObject.Find("target_2"); //target 2 for practice scene
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


        //====================== Init Ground Targets=============
        target1Ground = GameObject.Find("Bar1");

        target2Ground = GameObject.Find("Bar2");

        target3Ground = GameObject.Find("Bar3");

        target4Ground = GameObject.Find("Bar4");

        target5Ground = GameObject.Find("Bar5");

        target6Ground = GameObject.Find("Bar6");

        target7Ground = GameObject.Find("Bar7");

        target8Ground = GameObject.Find("Bar8");
        //=====================================================
        practice = true;

        torusShadow1Obj = GameObject.Find("torusShadow");
        torusShadow2Obj = GameObject.Find("torusShadow2");
        torusShadow3Obj = GameObject.Find("torusShadow3");

        torusShadow1Obj.SetActive(false);
        torusShadow2Obj.SetActive(false);
        torusShadow3Obj.SetActive(false);


        planeShadow1Obj = GameObject.Find("planeShadow1");
        planeShadow2Obj = GameObject.Find("planeShadow2");
        planeShadow3Obj = GameObject.Find("planeShadow3");

        planeShadow1Obj.SetActive(true);
        planeShadow2Obj.SetActive(true);
        planeShadow3Obj.SetActive(true);




    }



    //============================================Update=================================
    bool callOnce = false;
    void Update()
    {
        controllerInput.Update();

        move();
        trackPosition();



        if (controllerInput.GetButton(ControllerButton.A))
        {
            if (callOnce == false)
            {

                recordData();
                setUpScene();
                //text to speech, "scene number 2"
                takeTime();
                //textToSpeechManager.SpeakText("Scene "+ GlobalControl.counter.ToString());
                callOnce = true;

            }
        }
        if (!controllerInput.GetButton(ControllerButton.A))
        {
            callOnce = false;
        }

        //timer
        startTimer = Time.time;
        endTimer = Time.time;

    }


    


    private void move()
    {
        GameObject arrayRan = GameObject.Find("sceneOrderData");
        random randomScript = arrayRan.GetComponent<random>();
        string sceneName = randomScript.sceneOrder[GlobalControl.counter].sceneName;
        float rotationY = randomScript.sceneOrder[GlobalControl.counter].rotationY;


        char shape = sceneName[0];

            if (shape == '1')// torus
            {
                float moveZAxis = MoveZAxisSpeed * controllerInput.GetAxisLeftThumbstickY();
                torus.transform.Translate(0, 0, moveZAxis, Space.World);

            }
            if (shape == '0') //plane
            {
                float moveZAxis = MoveZAxisSpeed * controllerInput.GetAxisLeftThumbstickY();
                plane.transform.Translate(0, 0, moveZAxis, Space.World);

            }
    }

     



    private void trackPosition()
    {
        GameObject arrayRan = GameObject.Find("sceneOrderData");
        random randomScript = arrayRan.GetComponent<random>();
        string sceneName = randomScript.sceneOrder[GlobalControl.counter].sceneName;


       if (!practice)
        {
            char shape = sceneName[0];

            if (shape == '1')// torus
            {
                torusPosition = torus.transform.position;
            }
            if (shape == '0') //plane
            {
                planePosition = plane.transform.position;
            }
        }


    }






    //=====================================================Set up scene=============================
    public void setUpScene()
    {
        GameObject arrayRan = GameObject.Find("sceneOrderData");
        random randomScript = arrayRan.GetComponent<random>();

        Material lambert = Resources.Load("Shaders/lambert", typeof(Material)) as Material;
        Material blinn = Resources.Load("Shaders/blinn", typeof(Material)) as Material;
        Material phong = Resources.Load("Shaders/phong", typeof(Material)) as Material;

        Material lambertCheckerTorus = Resources.Load("CheckerTextures/Materials/lambertCheckerTorus", typeof(Material)) as Material;
        Material lambertCheckerPlane = Resources.Load("CheckerTextures/Materials/lambertCheckerPlane", typeof(Material)) as Material;
        Material blinnCheckerTorus = Resources.Load("CheckerTextures/Materials/blinnCheckerTorus", typeof(Material)) as Material;
        Material blinnCheckerPlane = Resources.Load("CheckerTextures/Materials/blinnCheckerPlane", typeof(Material)) as Material;
        Material phongCheckerTorus = Resources.Load("CheckerTextures/Materials/phongCheckerTorus", typeof(Material)) as Material;
        Material phongCheckerPlane = Resources.Load("CheckerTextures/Materials/phongCheckerPlane", typeof(Material)) as Material;

        //GameObject torusShadow = GameObject.Find("torusShadow");
        //GameObject planeShadow = GameObject.Find("planeShadow");



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
            //UnityEngine.Debug.Log(" Shape = Torus");

        }
        else
        {
            plane.SetActive(true); //Plane on
            torus.SetActive(false);
            //UnityEngine.Debug.Log(" Shape = Plane");
        }

        //=======================Cast Shadow=======================
        if (castShadow == '1') //Cast shadow off
        {
            if (shape == '1') //Torus
            {
                torusShadow1Obj.SetActive(true);
                torusShadow2Obj.SetActive(true);
                torusShadow3Obj.SetActive(true);
                torusCastShadowScript.enabled = true;

                //UnityEngine.Debug.Log(" CastShadow = Torus, On");

                planeShadow1Obj.SetActive(false);
                planeShadow2Obj.SetActive(false);
                planeShadow3Obj.SetActive(false);
                planeCastShadowScript.enabled = false;

                

            }
            else //Plane
            {
                planeShadow1Obj.SetActive(true);
                planeShadow2Obj.SetActive(true);
                planeShadow3Obj.SetActive(true);
                planeCastShadowScript.enabled = true;


                torusShadow1Obj.SetActive(false);
                torusShadow2Obj.SetActive(false);
                torusShadow3Obj.SetActive(false);
                torusCastShadowScript.enabled = false;


                //UnityEngine.Debug.Log(" CastShadow = Plane, On");
            }
        }
        else //Cast shadow off
        {

                torusShadow1Obj.SetActive(false);
                torusShadow2Obj.SetActive(false);
                torusShadow3Obj.SetActive(false);
                torusCastShadowScript.enabled = false;

                //UnityEngine.Debug.Log(" CastShadow = Torus, Off");

                planeShadow1Obj.SetActive(false);
                planeShadow2Obj.SetActive(false);
                planeShadow3Obj.SetActive(false);
                planeCastShadowScript.enabled = false;
                //UnityEngine.Debug.Log(" CastShadow = Plane, Off");
     
        }

        //=======================Billboarding=======================
        if (billboarding == '1')
        {
            
            if (shape == '1')//Torus
            {
                torusBillboardingScript.enabled = true;
                //UnityEngine.Debug.Log(" Billboarding = Torus, On");
            }
            else //Plane
            {
                planeBillboardingScript.enabled = true;
                //UnityEngine.Debug.Log(" Billboarding = Plane, On");

            }
        }
        else
        {
            if (shape == '1')//Torus
            {
                torusBillboardingScript.enabled = false;
                //UnityEngine.Debug.Log(" Billboarding = Torus, Off");
            }
            else //Plane
            {
                planeBillboardingScript.enabled = false;
                //UnityEngine.Debug.Log(" Billboarding = Plane, Off");
            }
        }

        //=======================textureDensity=======================
        if (textureDensity == '1')
        {
            //UnityEngine.Debug.Log(" TextureDensity = On");
            if (shader == '0') //Lambert
            {
                if (shape == '1')//Torus
                {
                    renderTorus.material = lambertCheckerTorus;
                    //UnityEngine.Debug.Log(" TextureDensity = On, lambertCheckerTorus ");
                }
                else //Plane
                {
                    renderPlane.material = lambertCheckerPlane;
                    //UnityEngine.Debug.Log(" TextureDensity = On, lambertCheckerPlane ");
                }

            }
            else if (shader == '1') //Blinn
            {
                if (shape == '1')//Torus
                {
                    renderTorus.material = blinnCheckerTorus;
                    //UnityEngine.Debug.Log(" TextureDensity = On, blinnCheckerTorus ");
                }
                else //Plane
                {
                    renderPlane.material = blinnCheckerPlane;
                    //UnityEngine.Debug.Log(" TextureDensity = On, blinnCheckerPlane ");
                }
            }
            else //Phong
            {
                if (shape == '1')//Torus
                {
                    renderTorus.material = phongCheckerTorus;
                    //UnityEngine.Debug.Log(" TextureDensity = On, phongCheckerTorus ");
                }
                else //Plane
                {
                    renderPlane.material = phongCheckerPlane;
                    //UnityEngine.Debug.Log("TextureDensity = On, phongCheckerPlane ");
                }
            }

        }
        else  //=======================Shader=======================
        {
            //change to regular shader
            //UnityEngine.Debug.Log(" TextureDensity = Off");
            if (shader == '0') //Lambert
            {
                if (shape == '1')//Torus
                {
                    renderTorus.material = lambert;
                    //UnityEngine.Debug.Log(" Shader = Torus, Lambert");
                }
                else //Plane
                {
                    renderPlane.material = lambert;
                    //UnityEngine.Debug.Log(" Shader = Plane, Lambert");
                }

            }
            else if (shader == '1') //Blinn
            {
                if (shape == '1')//Torus
                {
                    renderTorus.material = blinn;
                    //UnityEngine.Debug.Log(" Shader = Torus, Blinn");
                }
                else //Plane
                {
                    renderPlane.material = blinn;
                    //UnityEngine.Debug.Log(" Shader = Plane, Blinn");
                }
            }
            else //Phong
            {
                if (shape == '1')//Torus
                {
                    renderTorus.material = phong;
                    //UnityEngine.Debug.Log(" Shader = Torus, Phong");
                }
                else //Plane
                {
                    renderPlane.material = phong;
                    //UnityEngine.Debug.Log(" Shader = Plane, Phong");
                }
            }
        }


        //===========================Set the target words active==============


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


        //===================================================================



        if (shape == '1')//Torus
        {
            //Get and set the random size of the torus
            float randomObjectSize = randomScript.sceneOrder[GlobalControl.counter].size;
            torus.transform.localScale = new Vector3(randomObjectSize, randomObjectSize, randomObjectSize);

            //Get the starting postion of that torus
            float positionX = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionX;
            float positionY = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionY;
            float positionZ = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionZ;
            torus.transform.localPosition = new Vector3(positionX, positionY, positionZ);

            float rotationY = randomScript.sceneOrder[GlobalControl.counter].rotationY;
            torus.transform.localRotation = Quaternion.Euler(0, rotationY, 0);
        }
        if(shape == '0') //Plane
        {
            //Get and set the random size of the Plane
            float randomObjectSize = randomScript.sceneOrder[GlobalControl.counter].size;
            plane.transform.localScale = new Vector3(randomObjectSize, randomObjectSize, randomObjectSize);

            //Get the starting postion of that Plane
            float positionX = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionX;
            float positionY = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionY;
            float positionZ = randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionZ;
            plane.transform.localPosition = new Vector3(positionX, positionY, positionZ);

            float rotationY = randomScript.sceneOrder[GlobalControl.counter].rotationY;
            plane.transform.localRotation = Quaternion.Euler(0, rotationY, 0);

        }
   

        practice = false;



    }

    public void recordData()
    {
        if (!practice)
        {
            //record data
            GameObject arrayRan = GameObject.Find("sceneOrderData");
            random randomScript = arrayRan.GetComponent<random>();
            endTime = endTimer;
            float totalTimeTaken = endTime - startTime;

            string sceneName = randomScript.sceneOrder[GlobalControl.counter].sceneName;

            float errorTorus = 0;
            float errorPlane = 0;



            char shape = sceneName[0];
            if (shape == '1')//torus
            {
                errorTorus = torusPosition.z - targetPosition.z;
            }
            else
            {
                errorTorus = 0;
                torusPosition = Vector3.zero;
            }
            if (shape == '0')//plane
            {
                errorPlane = planePosition.z - targetPosition.z;
            }
            else
            {
                errorPlane = 0;
                planePosition = Vector3.zero;
            }


            /*string data = "Scene Number: " + GlobalControl.counter + Environment.NewLine
                         + "Scene Name: " + randomScript.sceneOrder[GlobalControl.counter].sceneName + Environment.NewLine
                         + "TargetNum: " + randomScript.sceneOrder[GlobalControl.counter].targetNum + Environment.NewLine
                         + "objectSize: " + randomScript.sceneOrder[GlobalControl.counter].size + Environment.NewLine
                         + "objectStartingPosition: (" + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionX + ", " + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionY + ", " + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionZ + ")" + Environment.NewLine
                         + "rotationDegreesY: " + randomScript.sceneOrder[GlobalControl.counter].rotationY + Environment.NewLine
                         + "torusEndingPosition: " + torusPosition + Environment.NewLine
                         + "planeEndingPosition: " + planePosition + Environment.NewLine
                         + "totalTimeTaken:" + totalTimeTaken + "s" + Environment.NewLine
                         + "positionOfTarget"+ randomScript.sceneOrder[GlobalControl.counter].targetNum +": (" + targetPosition.x   + ", " + targetPosition.y + ", " + targetPosition.z + ") , "  + Environment.NewLine
                         + "Error(torusPosition.z - TargetPosition.z): Torus: " + errorTorus + Environment.NewLine
                         + "Error(planePosition.z - TargetPosition.z): Plane: " + errorPlane;*/



            string data = GlobalControl.counter + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].sceneName + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].targetNum + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].size + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionX + ", " + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionY + ", " + randomScript.sceneOrder[GlobalControl.counter].randomObjectPositionZ + //Environment.NewLine
             ", " + randomScript.sceneOrder[GlobalControl.counter].rotationY + //Environment.NewLine
             ", " + torusPosition.x + ", " + torusPosition.y + ", " + torusPosition.z + //Environment.NewLine
             ", " + planePosition.x + ", " + planePosition.y + ", " + planePosition.z + //Environment.NewLine
             ", " + totalTimeTaken +   //Environment.NewLine
             ", " + targetPosition.x + ", " + targetPosition.y + ", " + targetPosition.z + //Environment.NewLine
             ", " + errorTorus +
             ", " + errorPlane;


            UnityEngine.Debug.Log(data);

            GlobalControl.counter++;
            if (GlobalControl.counter == 96)
                Application.Quit();
        }
        if (practice)
        {
          UnityEngine.Debug.Log("Done with practice scene");
          UnityEngine.Debug.Log("HALLWAY");

           string words = "Scene Number, Scene Name, Target Number, Object Size, objectStartingPositionX, objectStartingPositionY, objectStartingPositionZ, RotationY, FinalTorusPositionX, FinalTorusPositionY, FinalTorusPositionZ, FinalPlanePositionX, FinalPlanePositionY, FinalPlanePositionZ,Time Taken, PositionOfTargetX, PositionOfTargetY, PositionOfTargetZ, torusError , planeError" + Environment.NewLine;
          UnityEngine.Debug.Log(words);
        }


    }


    public void takeTime()
    {
        startTime = startTimer;


    }


}
