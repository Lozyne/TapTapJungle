using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "head" || collision.gameObject.tag == "ball")
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
