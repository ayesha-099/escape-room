using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform cartransform;
    public Transform cameraPiontTransform;
    private Vector3 velocity= Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(cartransform);
        transform.position = Vector3.SmoothDamp(transform.position , cameraPiontTransform.position, ref velocity, 5f* Time.deltaTime);     //cameraPiontTransform.position;
    }
}
