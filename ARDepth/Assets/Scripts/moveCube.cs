using UnityEngine;
using UnityEngine.VR.WSA.Input;



/// <summary>
/// Drop cube
/// </summary>
public class moveCube : MonoBehaviour
{
    GestureRecognizer recognizer;



    void Start()
    {


        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);
        recognizer.TappedEvent += Recognizer_TappedEvent;
        recognizer.StartCapturingGestures();


        var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        //Move cube with camera only on x-axis for billboarding scene

    }

    void OnDestroy()
    {
        recognizer.TappedEvent -= Recognizer_TappedEvent;
    }



    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        TextToSpeechManagerTest textScript = gameObject.GetComponent<TextToSpeechManagerTest>();
        bool foward = textScript.foward;
        bool back = textScript.back;

        if (foward)
        {
            Vector3 position = transform.localPosition;
            position.z = position.z + 0.1f;
            transform.localPosition = position;

        }
        if (back)
        {
            Vector3 position = transform.localPosition;
            position.z = position.z - 0.1f;
            transform.localPosition = position;

        }

    }


    void Update()
    {


    }



}



