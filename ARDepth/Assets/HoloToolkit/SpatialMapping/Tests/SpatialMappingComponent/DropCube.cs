using UnityEngine;
using UnityEngine.VR.WSA.Input;

/// <summary>
/// Drop Targets
/// </summary>
public class DropCube : MonoBehaviour
{
    GestureRecognizer recognizer;
    private int numClicks = 0;
    private GameObject cube;




    void Start ()
    {
        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);
        recognizer.TappedEvent += Recognizer_TappedEvent;
        recognizer.StartCapturingGestures();
        
  

    }

    void OnDestroy()
    {
        recognizer.TappedEvent -= Recognizer_TappedEvent;
    }



    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {

        //Outer target WHITE
        /*var outerTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere); // Create a sphere
        outerTarget.transform.localScale = new Vector3(0.3f, 0.01F, 0.3f); // Make the sphere smaller
        outerTarget.transform.position = Camera.main.transform.position + Camera.main.transform.forward; //drop it in front of the camera
        Rigidbody outerRigid = outerTarget.AddComponent<Rigidbody>(); // Apply physics
        outerRigid.mass = 100;

        //Physic Material
        CapsuleCollider outerPhys = outerTarget.AddComponent<CapsuleCollider>();
        outerPhys.material = (PhysicMaterial)Resources.Load("Sphere");


        // Inner target RED
        var innerTarget = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        innerTarget.transform.localScale = new Vector3(0.2f, 0.02F, 0.2f); // Make the sphere smaller
        innerTarget.transform.position = Camera.main.transform.position + Camera.main.transform.forward; // drop it in front of the camera
        Rigidbody innerRigid = innerTarget.AddComponent<Rigidbody>(); // Apply physics
        innerRigid.mass = 100;

        //Add material
        Renderer rend = innerTarget.GetComponent<Renderer>();
        Material red = Resources.Load("Red", typeof(Material)) as Material; // Assign Material
        rend.material = red;*/


        /*var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere); // Create a sphere
        sphere.transform.localScale = new Vector3(0.3f, 0.3F, 0.3f); // Make the sphere smaller
        sphere.transform.position = Camera.main.transform.position + Camera.main.transform.forward; //drop it in front of the camera
        Rigidbody outerRigid = sphere.AddComponent<Rigidbody>(); // Apply physics
        outerRigid.mass = 100;*/

        /*GameObject target = Instantiate(Resources.Load("Target", typeof(GameObject))) as GameObject;
        target.transform.localScale = new Vector3(0.3f, 0.3F, 0.3f); // Make the target smaller
        target.transform.position = Camera.main.transform.position + Camera.main.transform.forward; //drop it in front of the camera
        Rigidbody targetRig = target.AddComponent<Rigidbody>(); // Apply physics
        targetRig.mass = 100;*/

        /*Renderer rend = target.GetComponent<Renderer>();
        Material red = Resources.Load("Red", typeof(Material)) as Material; // Assign Material
        rend.material = red;*/




        // if (numClicks == 1)
        //{
        /*cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        cube.transform.position = Camera.main.transform.position + Camera.main.transform.forward;

        Renderer rend = cube.GetComponent<Renderer>();
        Material red = Resources.Load("Red", typeof(Material)) as Material; // Assign Material
        rend.material = red;*/


        GameObject targets = Instantiate(Resources.Load("Targets", typeof(GameObject))) as GameObject;
        targets.transform.position = Camera.main.transform.position + Camera.main.transform.forward; //drop it in front of the camera
        numClicks = numClicks + 1;

            if (numClicks >= 1) { 
            Rigidbody targetRigid = targets.GetComponent<Rigidbody>(); // Apply physics
            targetRigid.constraints = RigidbodyConstraints.FreezeAll;
            targetRigid.useGravity = true;

            }
           // }





        
        

    }

    


}
