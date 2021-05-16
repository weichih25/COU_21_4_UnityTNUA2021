using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update




    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 30, 0);
    }

    public void moveCenter()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    public void moveLeft()
    {
        transform.position = new Vector3(-1.2f, 0, 0);
    }

    public void moveRight()
    {
        transform.position = new Vector3(1.2f, 0, 0);
    }
}
