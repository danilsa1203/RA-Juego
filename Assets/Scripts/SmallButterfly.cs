using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallButterfly : MonoBehaviour
{
    public float speed = 0.4f;
    public float rotation_damping = 4f;
    public Transform BigButterfly;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] BigButterflies = GameObject.FindGameObjectsWithTag("BigButterfly");
        int chosen = Random.Range(0, BigButterflies.Length);
        BigButterfly = BigButterflies[chosen].GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        //Rotate to camera
        var rotation = Quaternion.LookRotation(BigButterfly.transform.position - transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotation_damping);

        //Follow big butterfly
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, BigButterfly.position, step);
    }
}
