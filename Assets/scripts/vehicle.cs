using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class vehicle : MonoBehaviour
{
    [SerializeField] private float speed =5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, speed* Time.deltaTime);
    }
}
