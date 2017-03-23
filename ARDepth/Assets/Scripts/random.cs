using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Collections.Generic;







public class random : MonoBehaviour
{

    // Use this for initialization



    public struct sceneProperties
    {
        public string sceneName;
        public int targetNum;
        public float size;
        public float randomObjectPositionX;
        public float randomObjectPositionY;
        public float randomObjectPositionZ;
        public int rotationY;
        

        public sceneProperties(string a, int b, float c, float d, float e, float f, int g)
        {
            sceneName = a;
            targetNum = b;
            size = c;
            randomObjectPositionX = d;
            randomObjectPositionY = e;
            randomObjectPositionZ = f;
            rotationY = g;
         
        }

    }

    public sceneProperties[] sceneOrder = new sceneProperties[96];

    public static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = UnityEngine.Random.Range(0, i);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    void Start()
    {


        //Order
        //      Shape | Cast Shadow | Billboarding | Texture Density | Shader
        //      1 = torus
        //      0 = plane

        string[] scenes = new string[48] { "00000" , "00001", "00002",
                                           "00010" , "00011", "00012",
                                           "00100" , "00101", "00102", // billboarded
                                           "01000" , "01001", "01002",
                                           "10000" , "10001", "10002",

                                           //two + shader
                                           "11000", "11001", "11002",
                                           "10100", "10101", "10102", //billborad
                                           "10010", "10011", "10012",
                                           "01100", "01101", "01102", //billboard
                                           "01010", "01011", "01012",
                                           "00110", "00111", "00112",

                                           //three + shader
                                           "11100", "11101", "11102",
                                           "10110", "10111", "10112",
                                           "11010", "11011", "11012",
                                           "01110", "01111", "01112",

                                           //four + shader
                                           "11110", "11111", "11112" };






        int num = 1;
        int i = 0;
        

        for (int scene = 0; scene < 48; scene++)
        {
            for(int nearTargets = 0; nearTargets < 1; nearTargets++)
            {

                int targetNum = UnityEngine.Random.Range(1, 5);  
    


                float size = UnityEngine.Random.Range(0.15f, 0.4f);
                var vectorsize = gameObject.transform.localScale; 
                vectorsize = new UnityEngine.Vector3(size, size, size);

                float randomObjectPositionX = UnityEngine.Random.Range(-0.4f, 0.4f);
                float randomObjectPositionY = -0.15f;
                float randomObjectPositionZ = UnityEngine.Random.Range(1.36f, 7.51f);

                int rotationY;

                string sceneName = scenes[scene];
                char billboard = sceneName[2];
                if (billboard == '1')//if billboarding is in the scene then rotation = 0 
                {
                    rotationY = 0;
                }
                else
                {
                    rotationY = UnityEngine.Random.Range(-45, 45);
                }

                var position = gameObject.transform.localPosition;
                position = new UnityEngine.Vector3(randomObjectPositionX, randomObjectPositionY, randomObjectPositionZ);


                sceneProperties newScene = new sceneProperties(scenes[scene], targetNum, size, randomObjectPositionX, randomObjectPositionY, randomObjectPositionZ, rotationY);

                sceneOrder[i] = newScene;

                num++;
                i++;

            }
            for (int farTargets = 0; farTargets < 1; farTargets++)
            {
                int targetNum = UnityEngine.Random.Range(5, 9);


                float size = UnityEngine.Random.Range(0.15f, 0.4f);
                var vectorsize = gameObject.transform.localScale;
                vectorsize = new UnityEngine.Vector3(size, size, size);

                float randomObjectPositionX = UnityEngine.Random.Range(-0.4f, 0.4f);
                float randomObjectPositionY = -0.15f;
                float randomObjectPositionZ = UnityEngine.Random.Range(1.36f, 7.51f);

                var position = gameObject.transform.localPosition;
                position = new UnityEngine.Vector3(randomObjectPositionX, randomObjectPositionY, randomObjectPositionZ);

                int rotationY;

                string sceneName = scenes[scene];
                char billboard = sceneName[2];
                if (billboard == '1') //if billboarding is in the scene then rotation = 0 
                {
                    rotationY = 0;
                }
                else
                {
                    rotationY = UnityEngine.Random.Range(-45, 45);
                }

                sceneProperties newScene = new sceneProperties(scenes[scene], targetNum, size, randomObjectPositionX, randomObjectPositionY, randomObjectPositionZ, rotationY);

                sceneOrder[i] = newScene;

                num++;
                i++;

            }


        }

        ShuffleArray(sceneOrder);




        string words = "Scene Number, Scene Name, Target Number, Cube Size, CubeStartingPositionX, CubeStartingPositionY, CubeStartingPositionZ, RotationY" + Environment.NewLine;
        UnityEngine.Debug.Log(words);

        for (int k = 0; k < 96; k++)
        {
            string categories= (k) + " , " + sceneOrder[k].sceneName + " , " + sceneOrder[k].targetNum + " , " + sceneOrder[k].size + " , (" + sceneOrder[k].randomObjectPositionX + ", " + sceneOrder[k].randomObjectPositionY + ", " + sceneOrder[k].randomObjectPositionZ +  ") , " + sceneOrder[k].rotationY + Environment.NewLine;
            UnityEngine.Debug.Log(categories);
            


        }





    }


    // Update is called once per frame
    void Update()
    {
        


    }

}