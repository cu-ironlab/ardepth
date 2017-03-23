using UnityEngine;
using System.Collections;

public class calculate4 : MonoBehaviour
{


    BoxCollider box;
    GameObject lightDir1;
    GameObject lightDir2;
    GameObject lightDir3;



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



        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f), .02f);
        Gizmos.DrawSphere(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f), .02f);


        lightDir2 = GameObject.Find("DirectionalLight2");




        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), lightDir2.transform.position);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), lightDir2.transform.position);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f), lightDir2.transform.position);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f), lightDir2.transform.position);



        //==================================
        Gizmos.color = Color.cyan;
        Vector3 cal = transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f) - lightDir2.transform.position;
        Vector3 newCal = new Vector3(gameObject.transform.position.x + cal.x , cal.y * 1.15f, gameObject.transform.position.z + cal.z * 1.15f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f), newCal);



        Gizmos.color = Color.blue;
        Vector3 cal2 = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f) - lightDir2.transform.position;
        Vector3 newCal2 = new Vector3(gameObject.transform.position.x + cal2.x  , cal2.y * 1.15f, gameObject.transform.position.z + cal2.z * 1.15f );
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f), newCal2);


        Gizmos.color = Color.green;
        Vector3 cal3 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - lightDir2.transform.position;
        Vector3 newCal3 = new Vector3(gameObject.transform.position.x + cal3.x * .899f, cal3.y * .899f, gameObject.transform.position.z + cal3.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), newCal3);


        Gizmos.color = Color.yellow;
        Vector3 cal4 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f) - lightDir2.transform.position;
        Vector3 newCal4 = new Vector3(gameObject.transform.position.x + cal4.x * .899f, cal4.y * .899f, gameObject.transform.position.z + cal4.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), newCal4);


        //shadow Positon
        Vector3 centerCal = new Vector3(newCal.x + newCal4.x, cal.y * 1.15f, newCal4.z - (newCal4.z - newCal.z) * 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(centerCal, .03f);






        //===========================================new Calc2======================================

        lightDir3 = GameObject.Find("DirectionalLight3");




        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), lightDir3.transform.position);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), lightDir3.transform.position);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f), lightDir3.transform.position);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f), lightDir3.transform.position);



        //==================================
        Gizmos.color = Color.cyan;
        Vector3 cal5 = transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f) - lightDir3.transform.position;
        Vector3 newCal5 = new Vector3(gameObject.transform.position.x + cal5.x, cal5.y * 1.15f, gameObject.transform.position.z + cal5.z * 1.15f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f), newCal5);



        Gizmos.color = Color.blue;
        Vector3 cal6 = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f) - lightDir3.transform.position;
        Vector3 newCal6 = new Vector3(gameObject.transform.position.x + cal6.x, cal6.y * 1.15f, gameObject.transform.position.z + cal6.z * 1.15f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f), newCal6);


        Gizmos.color = Color.green;
        Vector3 cal7 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - lightDir3.transform.position;
        Vector3 newCal7 = new Vector3(gameObject.transform.position.x + cal7.x * .899f, cal7.y * .899f, gameObject.transform.position.z + cal7.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), newCal7);


        Gizmos.color = Color.yellow;
        Vector3 cal8 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f) - lightDir3.transform.position;
        Vector3 newCal8 = new Vector3(gameObject.transform.position.x + cal8.x * .899f, cal8.y * .899f, gameObject.transform.position.z + cal8.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), newCal8);



        //shadow Positon
        Vector3 centerCal2 = new Vector3(newCal5.x + newCal8.x, cal.y * 1.15f, newCal8.z - (newCal8.z - newCal5.z) * 0.5f);




        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(centerCal2, .03f);




        //========================================================newCal 3===========================================================

        //===========================================new Calc2======================================

        lightDir1 = GameObject.Find("DirectionalLight1");




        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), lightDir1.transform.position);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), lightDir1.transform.position);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f), lightDir1.transform.position);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f), lightDir1.transform.position);



        //==================================
        Gizmos.color = Color.cyan;
        Vector3 cal9 = transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f) - lightDir1.transform.position;
        Vector3 newCal9 = new Vector3(gameObject.transform.position.x + cal9.x, cal9.y * 1.15f, gameObject.transform.position.z + cal9.z * 1.15f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f), newCal9);



        Gizmos.color = Color.blue;
        Vector3 cal10 = transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f) - lightDir1.transform.position;
        Vector3 newCal10 = new Vector3(gameObject.transform.position.x + cal10.x, cal10.y * 1.15f, gameObject.transform.position.z + cal10.z * 1.15f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f), newCal10);


        Gizmos.color = Color.green;
        Vector3 cal11 = transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f) - lightDir1.transform.position;
        Vector3 newCal11 = new Vector3(gameObject.transform.position.x + cal11.x * .899f, cal11.y * .899f, gameObject.transform.position.z + cal11.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f), newCal11);


        Gizmos.color = Color.yellow;
        Vector3 cal12 = transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f) - lightDir1.transform.position;
        Vector3 newCal12 = new Vector3(gameObject.transform.position.x + cal12.x * .899f, cal12.y * .899f, gameObject.transform.position.z + cal12.z * .899f);
        Gizmos.DrawLine(transform.TransformPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f), newCal12);



        //shadow Positon
        Vector3 centerCal3 = new Vector3(newCal9.x + newCal12.x, cal.y * 1.15f, newCal12.z - (newCal12.z - newCal9.z) * 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(centerCal3, .03f);










        // UnityEngine.Debug.Log("(" + newCal.x + " " + newCal.y + " " + newCal.z + " " + ")");

        UnityEngine.Debug.Log(cal.x + " " + cal.y + " " + cal.z);

        // Gizmos.DrawSphere(vertices[0], .02f);
    }







}
