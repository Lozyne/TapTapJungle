using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ObjectInGame {

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "head")
        {
           List<Body> lstBodies = Manager_Game.gameManager.getSnake().getLstBody();
            int countBodiesValue = lstBodies.Count;
            //yellox
            if (this.gsColor == 3)
            {
                Body lastBody = lstBodies[lstBodies.Count -1];

                //delete from data nbr of color
                byte nbrBodiesToDelete = DataManager._DataManager.gsBodiesListNumber[lastBody.gsColor];

                for (int i = nbrBodiesToDelete - 1 ; i > countBodiesValue - nbrBodiesToDelete ; i--)
                {
                    lstBodies.RemoveAt(i);
                }
                UIManager.UI_Manager.setUIColors(Color.magenta);

            }
               
        }
    }
}
