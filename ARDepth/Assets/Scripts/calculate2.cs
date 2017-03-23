using UnityEngine;
using System.Collections;

public class calculate2 : MonoBehaviour
{


    BoxCollider box;
    GameObject lightDir;



    void Start()
    {


        //OnDrawGizmosSelected();



    }



    void Update()
    {
        //DoStuff();

        //DebugOurStuff();

        //Vector3 pos = obj2.transform.position;
        // Vector3 dir = (this.transform.position - obj2.transform.position).normalized;
        //Debug.DrawLine(pos, pos + dir * 10, Color.red, Mathf.Infinity);
        //OnDrawGizmosSelected();
    }

    /*void DoStuff()
    {
        if (obj2 != null)
            direction = CalculateMidVector(obj2.transform.position, this.transform.position);
    }

    Vector3 CalculateMidVector(Vector3 first, Vector3 second)
    {
        return first + second;
    }

    void DebugOurStuff()
    {
        Debug.DrawLine(Vector3.zero, obj2.transform.position, Color.blue);
        Debug.DrawLine(Vector3.zero, this.transform.position, Color.cyan);
        Debug.DrawLine(Vector3.zero, direction, Color.green);
    }

    */
    /* Vector3[] GetColliderVertexPositions(GameObject gameObject) {

         box = gameObject.GetComponent<BoxCollider>();
         Vector3[] vertices = new Vector3[8];
     var thisMatrix = gameObject.transform.localToWorldMatrix;
     var storedRotation = gameObject.transform.rotation;
     gameObject.transform.rotation = Quaternion.identity;



     Vector3 extents = box.bounds.extents;
     vertices[0] = thisMatrix.MultiplyPoint3x4(extents);
     vertices[1] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, extents.z));
     vertices[2] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, extents.y, -extents.z));
     vertices[3] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, extents.y, -extents.z));
     vertices[4] = thisMatrix.MultiplyPoint3x4( new Vector3(extents.x, -extents.y, extents.z));
     vertices[5] = thisMatrix.MultiplyPoint3x4(new Vector3(-extents.x, -extents.y, extents.z));
     vertices[6] = thisMatrix.MultiplyPoint3x4(new Vector3(extents.x, -extents.y, -extents.z));
     vertices[7] = thisMatrix.MultiplyPoint3x4(-extents);

     gameObject.transform.rotation = storedRotation;
     return vertices;
     }*/




    void OnDrawGizmosSelected()
    {
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        // Vector3[] vertices = GetColliderVertexPositions(gameObject);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f), .02f);
        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f), .02f);
        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), .02f);
        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), .02f);


        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f), .02f);
        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f), .02f);
        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f), .02f);
        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f), .02f);

        lightDir = GameObject.Find("DirectionalLight3");



        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f), lightDir.transform.position);


        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f), lightDir.transform.position);


        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), lightDir.transform.position);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), lightDir.transform.position);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f), lightDir.transform.position);

        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f), lightDir.transform.position);




        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f), lightDir.transform.position);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f), lightDir.transform.position);





        //Gizmos.DrawSphere(transform.TransformPoint(newCal), .05f);



        //==================================
        Gizmos.color = Color.blue;
        Vector3 cal = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f) - lightDir.transform.position;
        Vector3 newCal = new Vector3(cal.x * .899f, cal.y * .899f, gameObject.transform.position.z + cal.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f), newCal);



        Gizmos.color = Color.cyan;
        Vector3 cal2 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f) - lightDir.transform.position;
        Vector3 newCal2 = new Vector3(cal2.x * .899f, cal2.y * .899f, gameObject.transform.position.z + cal2.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f), newCal2);


        Gizmos.color = Color.green;
        Vector3 cal3 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - lightDir.transform.position;
        Vector3 newCal3 = new Vector3(cal3.x * .899f, cal3.y * .899f, gameObject.transform.position.z + cal3.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), newCal3);


        Gizmos.color = Color.yellow;
        Vector3 cal4 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f) - lightDir.transform.position;
        Vector3 newCal4 = new Vector3(cal4.x * .899f, cal4.y * .899f, gameObject.transform.position.z + cal4.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), newCal4);








        // UnityEngine.Debug.Log("(" + newCal.x + " " + newCal.y + " " + newCal.z + " " + ")");

        UnityEngine.Debug.Log(cal.x + " " + cal.y + " " + cal.z);

        // Gizmos.DrawSphere(vertices[0], .02f);
    }







}
