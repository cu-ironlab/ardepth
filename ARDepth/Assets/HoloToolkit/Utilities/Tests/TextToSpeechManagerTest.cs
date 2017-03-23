using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class TextToSpeechManagerTest : MonoBehaviour
{
    private GestureRecognizer gestureRecognizer;
    public TextToSpeechManager textToSpeechManager;
    public bool foward = true;
    public bool back = false;
    public bool nextScene = false;

   
    


    // Use this for initialization
    void Start()
    {
        textToSpeechManager.SpeakText("This is the Practice Scene");
        // Set up a GestureRecognizer to detect Select gestures.
        gestureRecognizer = new GestureRecognizer();
        gestureRecognizer.TappedEvent += GestureRecognizer_TappedEvent;
        gestureRecognizer.StartCapturingGestures();
        

    }

    private void GestureRecognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        GazeManager gm = GazeManager.Instance;
        if (gm.Hit)
        {
            // Get the target object
            GameObject obj = gm.HitInfo.collider.gameObject;

            // Try and get a TTS Manager
            TextToSpeechManager tts = null;
            if (obj != null)
            {
                tts = obj.GetComponent<TextToSpeechManager>();
            }

            // If we have a text to speech manager on the target object, say something.
            // This voice will appear to emanate from the object.
            if (tts != null)
            {
            }
        }
    }




    public void Forward()
    {
        foward = true;
        back = false; 
        textToSpeechManager.SpeakText("You can now move the cube forward");



    }

    public void Back()
    {
        back = true;
        foward = false;
        textToSpeechManager.SpeakText("You can now move the cube backwards");

    }

    public void Done()
    {



        textToSpeechManager.SpeakText( "Scene "+ GlobalControl.counter.ToString());






    }






}
