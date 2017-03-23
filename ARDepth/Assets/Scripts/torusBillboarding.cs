using UnityEngine;
using System.Collections;

public class torusBillboarding : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    //public Transform lookAt;
    void Update()
    {
        Vector3 worldLookDirection = transform.position - Camera.main.transform.position;
        Vector3 localLookDirection = transform.InverseTransformDirection(worldLookDirection);
        localLookDirection.y = 0;
        transform.forward = transform.rotation * localLookDirection;
    }


}
