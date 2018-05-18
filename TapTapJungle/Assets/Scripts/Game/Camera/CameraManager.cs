using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private GameObject _Head;



    private void Update()
    {
       // if(_Head!=null)
            //CameraMovement();
    }

    public GameObject gsHead
    {
        get
        {
            return _Head;
        }
        set
        {
            _Head = value;
        }
    }

    /*private void CameraMovement()
    {
      
        Vector3 vec = this.gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.transform.localPosition;
        vec.z -= 30.0f;
        vec.y += 10.0f;

            //vec.y = 0;


        this.gameObject.transform.transform.localPosition = vec;

        if (Input.GetKey(KeyCode.A))            
            this.gameObject.transform.localEulerAngles =new Vector3(0, gameObject.transform.localEulerAngles.y-1, 0);
        else if (Input.GetKey(KeyCode.E))
            this.gameObject.transform.localEulerAngles = new Vector3(0, gameObject.transform.localEulerAngles.y + 1, 0);

    }*/
}
