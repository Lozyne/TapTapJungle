using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake:MonoBehaviour {
    [SerializeField] 
    float coef_dist ;

    [SerializeField]
    GameObject _Camera;
    //Managers
    private DataManager _DataManager;
    [SerializeField]
    private UIManager _UIManager;

    [SerializeField]
    private DataHeartsManager _DataHeartsManager;

    [SerializeField]
    private UILifeManager _UILifeManager;

    [SerializeField]
    private List<Body> _lstBodies;
    private byte[] _nbrColorsBodies;
    private byte _points;


    [SerializeField]
    private float minDistBodies;
    private float tmpMinDist;

    private Vector3 _SnakeDirection;

    [SerializeField]
    private float _Speed = 1f;
    private float _MinDistance = 1f;
    [SerializeField]
    private float _SpeedRotation = 1000f;

    [SerializeField]
    private GameObject BodiesObjects;
    [SerializeField]
    private GameObject headsObjects;


    private bool isMoving;
    private void Update()
    {
        if (Manager_Game.gameManager.gsIngame)
            MoveSnake();
    }

    private void Awake()
    {
        coef_dist = 1.5f;
        _DataManager = new DataManager();
        _DataHeartsManager = new DataHeartsManager();
        _lstBodies = new List<Body>();
        _nbrColorsBodies = new byte[4];
        _points = 0;

        tmpMinDist = minDistBodies;
        _SnakeDirection = new Vector3(0, 0, 0);

        /////////////////////////
        _UILifeManager.OnLifeChanged += HandleSetUILife;
        _DataHeartsManager.OnDataChanged += this.HandleSetDataLife;

        isMoving = false;
    }
    //TEST MVC
    #region test mvc
    private void HandleSetDataLife()
    {
        _UILifeManager.LoseLife(_DataHeartsManager.gsLife);
    }

    private void HandleSetUILife()
    {   if (_DataHeartsManager.gsLife>=0)
            _DataHeartsManager.gsLife -= 1;
       
    }
    #endregion
    public GameObject gsBodiesObjects
    {
        get { return this.BodiesObjects; }
    }

    public List<Body> getLstBody()
    {
        return this._lstBodies;
    }

    public void set_nbrColorsBodies(byte _idColor)
    {
        this._nbrColorsBodies[_idColor] ++;
    }


    /// <summary>
    /// Add a ball to the body's snake
    /// </summary>
    /// <param name="pBody"></param>
    public void addBody(Body pBody)
    {
        Transform TBody= pBody.gameObject.transform;
       
        if (this.getLstBody().Count > 0)
        {
            Vector3 vecPosition = this.getLstBody()[this.getLstBody().Count - 1].gameObject.transform.localPosition;
            TBody.parent = null;//this.BodiesObjects.transform;
            TBody.localPosition = new Vector3(vecPosition.x, vecPosition.y, vecPosition.z-5.5f);
            _DataManager.addBodiesNumberValue(pBody.gsColor);
            
            
            _DataManager.gsScore = pBody.gsPoints;
            _UIManager._UIScore = _DataManager.gsScore.ToString();
            //if 3 same balls
            if (_DataManager.gsBodiesListNumber[pBody.gsColor] == 3)
            {
                _DataManager.gsScore = _DataManager.gsComboConstPoints;
                _UIManager._UIScore = _DataManager.gsScore.ToString();

                //Delete last 3 balls


            }

            //set UI Bodies
            _UIManager.setUIColors(pBody.gameObject.GetComponent<Renderer>().material.color);

            Manager_Game.gameManager.gsBodyManager.initPositionBodies(1);
            Debug.Log("initPosition");
        }
        else
        {
            TBody.position = this.gameObject.transform.position;
          //  BodiesObjects.transform.GetChild(0).gameObject.GetComponent<CameraManager>().gsHead = pBody.gameObject;
        }

        this.getLstBody().Add(pBody);
    }

    public void MoveSnake()
    {
        GameObject currentBody;
        GameObject previousBody;
        Vector3 newPosition;
        float T;

        int initSize = 0;
        this.getLstBody()[0].gameObject.transform.Translate(Vector3.forward*Time.smoothDeltaTime * _Speed, Space.Self);

       if (Input.GetAxis("Horizontal") != 0)
           this.getLstBody()[0].transform.Rotate(Vector3.up * Time.deltaTime * _SpeedRotation * Input.GetAxis("Horizontal"));

        if (!isMoving)
            isMoving = true;

        initSize = this.getLstBody().Count;

           for (int i = 1; i < this.getLstBody().Count; ++i)
           {
               currentBody = this.getLstBody()[i].gameObject;
               previousBody = this.getLstBody()[i - 1].gameObject;

               float distance = Vector3.Distance(previousBody.transform.position, currentBody.transform.position);

               newPosition = previousBody.transform.localPosition;
            // newPosition.y = 0;
            T =  ( distance*coef_dist) / _Speed;//distance*_Speed *Time.deltaTime*1.5f;
            if (T > 0.5)
                   T = 0.5f;
               currentBody.transform.localPosition = Vector3.Lerp(currentBody.gameObject.transform.localPosition, newPosition, T);
               currentBody.transform.localRotation = Quaternion.Slerp(currentBody.gameObject.transform.localRotation, previousBody.transform.localRotation, T);
           }
     
        isMoving = false;
    }


    public float gsSpeed
    {
        get
        {
            return this._Speed;
        }
        set
        {
            this._Speed = value;
        }
    }

    public bool gsMoving
    {
        get
        {
            return isMoving;
        }
    }

    public float gsCoef_Dist
    {
        get
        {
            return coef_dist;
        }
        set
        {
            coef_dist = value;
        }
    }
}
