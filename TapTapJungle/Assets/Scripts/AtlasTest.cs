using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasTest : MonoBehaviour {
    [SerializeField]
    private enum ListSprites {a,b,c,d,e,f,g,h,i,j };

    [SerializeField]
    private ListSprites lst;

    [SerializeField]
    private SpriteAtlas _SpriteAtlas;

    [SerializeField]
    private SpriteRenderer m_renderer;

    private Sprite[] m_ArraySprite;
	// Use this for initialization
	void Start () {
        m_renderer.sprite = _SpriteAtlas.GetSprite("");

        _SpriteAtlas.GetSprites(m_ArraySprite);
    }
	
    private void selectSprite()
    {
        if (lst == ListSprites.a)
            Debug.Log(0);


            
    }


 
}
