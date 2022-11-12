using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorScalaTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(1, 2, 3) + new Vector3(2, 4, 6);   // new Vector3(3, 6, 9)

        transform.position = 3 * new Vector3(1, 2, 3);  // new Vector3(3, 6, 9)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
