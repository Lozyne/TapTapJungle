using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Services for objects In Game (example: Boxes, Bodies ...)
/// Manage All object pooling concept of the game
/// </summary>

public abstract class ObjectsInGameManager: MonoBehaviour
{

    [SerializeField]
    protected GameObject prefabObject;

    [SerializeField]
    protected GameObject _ObjectsList;

    [SerializeField]
    protected List<GameObject> lstObjectsInGame;

    [SerializeField]
    protected List<GameObject> lstUsed;

    abstract public void initListObjectsInGame();

    abstract public GameObject getObjectPooling();

    abstract public void DestroyObjectPool(GameObject obj);

    abstract public void initObjectsInGamePositionInGame(GameObject pObject);

    abstract public void changeObjectInGameColor(Body pObject);

    abstract public void getColor(Body pObject);
}
