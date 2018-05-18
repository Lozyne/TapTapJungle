using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Check differents conditions of Victory
/// 0 victory
/// 1 defeat
/// 2 neutral
/// </summary>

public class Rules  {
   
    // Use this for initialization
    void Start () {
		
	}

    public byte checkVictory()
    {
        if(DataManager._DataManager!=null && DataManager._DataManager.gsScore < 0)
            return 1;
        if (DataHeartsManager._DataHeartsManager != null && DataHeartsManager._DataHeartsManager.gsLife == 0)
            return 1;
        if (DataManager._DataManager != null && DataManager._DataManager.gsBodiesNumber >= 100)
            return 1;

        return 2;
    }




}
