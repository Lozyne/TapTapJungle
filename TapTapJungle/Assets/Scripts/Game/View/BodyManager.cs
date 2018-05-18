
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyManager : ObjectsInGameManager
{
    public static BodyManager _BodyManager;

    [SerializeField]
    private GameObject prefabHead;

 

    private bool isSpawning ;

    Vector3 dirHeadToSpawner;

    UIManager _SUIManager;

    private void Awake()
    {
        _BodyManager = this;
        lstObjectsInGame = new List<GameObject>();
        lstUsed = new List<GameObject>();
        isSpawning = false;
        _SUIManager = UIManager.UI_Manager;
    }

    private void FixedUpdate()
    {
        if (Manager_Game.gameManager.gsIngame && isSpawning)
            rotation();
    }

    public void rotation()
    {

        prefabHead.transform.GetChild(0).RotateAround(prefabHead.transform.transform.position, new Vector3(0, 1.0f, 0), 50 * Time.deltaTime);


    }

    public override void initListObjectsInGame()
    {
        for (int i = 0; i < 100; ++i)
        {
            GameObject bodySnake = Instantiate(prefabObject, _ObjectsList.transform);
            bodySnake.name = "Body_" + i;
            bodySnake.GetComponent<Body>().gsIsHead = false;
            lstObjectsInGame.Add(bodySnake);
            bodySnake.transform.localScale = new Vector3(1, 1, 1);
            bodySnake.tag = "ball";
            bodySnake.SetActive(false);

        }
    }

    public override GameObject getObjectPooling()
    {
        GameObject bodyElement;
        if (lstObjectsInGame.Count > 0)
        {
            bodyElement = lstObjectsInGame[0];
            lstUsed.Add(bodyElement);
            lstObjectsInGame.RemoveAt(0);

            return bodyElement;
        }
        return null;
    }
   
    public override void DestroyObjectPool(GameObject obj)
    {
        lstObjectsInGame.Add(obj);
        lstUsed.Remove(obj);
        obj.SetActive(false);
    }


    public GameObject gsPrefabBody
    {
        get
        {
            return this.prefabObject;
        }
    }

    public GameObject gsPrefabHead
    {
        get
        {
            return this.prefabHead;
        }
    }

    public override void initObjectsInGamePositionInGame(GameObject pObject)
    {
        Vector3 dirHeadToSpawner = gsPrefabHead.transform.GetChild(0).gameObject.transform.position - gsPrefabHead.transform.position;
        if (_SUIManager == null)
        {
            _SUIManager = UIManager.UI_Manager;
        }
        float Xdist = Random.Range(_SUIManager.gsListDelimitation[0].transform.position.x, _SUIManager.gsListDelimitation[1].transform.position.x);
        float Ydist = Random.Range(_SUIManager.gsListDelimitation[3].transform.position.y, _SUIManager.gsListDelimitation[0].transform.position.x);
        pObject.transform.localPosition = new Vector3(Xdist * dirHeadToSpawner.normalized.x, -20, Ydist * dirHeadToSpawner.normalized.z);
    }


    public void initPositionBodies(byte nbrInit)
    {
        isSpawning = true;
        StartCoroutine("launchInit", nbrInit);
    }

    IEnumerator launchInit(byte nbrInit)
    {   
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < nbrInit; i++)
        {
            if (lstObjectsInGame.Count > 0)
            {
                GameObject body = getObjectPooling();
                body.SetActive(true);
                changeObjectInGameColor(body.GetComponent<Body>());

                yield return new WaitForSeconds(1.0f);
                initObjectsInGamePositionInGame(body);
            }
        }
        isSpawning = false;
    }

    public override void changeObjectInGameColor(Body pObject)
    {
        pObject.gsColor = (byte)Random.Range(0, 3);
        getColor(pObject);
        pObject.gsIColor.getColor(pObject);
    }

    public override void getColor(Body pObject)
    {
        switch (pObject.gsColor)
        {
            case 0:
                pObject.gsIColor = new RedColor();
                break;
            case 1:
                pObject.gsIColor = new BlueColor();
                break;
            case 2:
                pObject.gsIColor = new GreenColor();
                break;

            default:
                break;
        }
    }
}
