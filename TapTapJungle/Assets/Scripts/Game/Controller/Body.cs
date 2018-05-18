using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : ObjectInGame
{
    
    GameObject _Ball;
   
    bool isHead;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "ball" && this.gameObject.tag == "head")
        {
            other.transform.tag = "Untagged";
            Manager_Game.gameManager.getSnake().addBody(other.gameObject.GetComponent<Body>());

        }
    }

    public bool gsIsHead
    {
        get
        {
            return isHead;
        }
        set
        {
            this.isHead = value;
        }
    }
  
}

