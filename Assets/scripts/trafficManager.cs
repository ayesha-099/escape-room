using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficManager : MonoBehaviour
{
    [SerializeField] Transform[] lanes;
    [SerializeField] GameObject[] trafficVechicle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   IEnumerator trafficSpawner()
   {
        yield return new WaitForSeconds(2f);
        while (true)
        {

        }

   }
}
