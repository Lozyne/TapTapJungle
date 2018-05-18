
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage all boxes from the game
/// </summary>

public class BoxesManager :  ObjectsInGameManager
{
    UIManager _SUIManager;
    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        _SUIManager = UIManager.UI_Manager;
        initListObjectsInGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void initListObjectsInGame()
    {
        for (int i = 0; i < 50; ++i)
        {
            GameObject boxObject = Instantiate(prefabObject, _ObjectsList.transform) as GameObject;
            boxObject.name = "Box_" + i;
            lstObjectsInGame.Add(boxObject);
            boxObject.transform.localScale = new Vector3(1, 1, 1);
            boxObject.tag = "box";
            boxObject.SetActive(false);
        }
    }


    public override GameObject getObjectPooling()
    {
        GameObject boxElement;
        if (lstObjectsInGame.Count > 0)
        {
            boxElement = lstObjectsInGame[0];
            lstUsed.Add(boxElement);
            lstObjectsInGame.RemoveAt(0);

            return boxElement;
        }
        return null;
    }

    public override void DestroyObjectPool(GameObject obj)
    {
        lstObjectsInGame.Add(obj);
        lstUsed.Remove(obj);
        obj.SetActive(false);
    }

    public override void initObjectsInGamePositionInGame(GameObject pObject)
    {
        float x = Random.Range(_SUIManager.gsListDelimitation[0].transform.position.x, _SUIManager.gsListDelimitation[1].transform.position.x);
        float z = Random.Range(_SUIManager.gsListDelimitation[2].transform.position.z, _SUIManager.gsListDelimitation[1].transform.position.z);
        pObject.transform.position = new Vector3(x,-20,z);
    }

    public override void changeObjectInGameColor(Body pObject)
    {
        pObject.gsColor = (byte)Random.Range(3, 5);
        getColor(pObject);
        pObject.gsIColor.getColor(pObject);
    }

    public override void getColor(Body pObject)
    {
        switch (pObject.gsColor)
        {
            case 3:
                pObject.gsIColor = new YellowColor();
                break;
            case 5:
                pObject.gsIColor = new BlackColor();
                break;

            default:
                break;
        }
    }
}
