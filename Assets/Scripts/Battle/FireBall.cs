using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Velocity;
    public Vector3 Dir;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = this.Velocity * this.Dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(this.gameObject);
    }
}
