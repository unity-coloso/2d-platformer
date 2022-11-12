using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLocalTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 180f * Time.deltaTime, Space.World);
        transform.Translate(Vector3.forward * 5f * Time.deltaTime, Space.World);
    }
}
