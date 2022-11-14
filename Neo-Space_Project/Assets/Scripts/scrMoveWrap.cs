using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public struct Borders
{
    public float UpBorder, DownBorder, LeftBorder, RightBorder;
}

public class scrMoveWrap : MonoBehaviour {

    public Borders borders;

	
	void Update ()
    {
        var Pos = transform.position;
        var x = transform.position.x;
        var y = transform.position.y;

        if (x < borders.LeftBorder)
        {
            Pos.x = borders.RightBorder;
            transform.position = Pos;
        }

        if (x > borders.RightBorder)
        {
            Pos.x = borders.LeftBorder;
            transform.position = Pos;
        }

        if (y > borders.UpBorder)
        {
            Pos.y = borders.DownBorder;
            transform.position = Pos;
        }

        if (y < borders.DownBorder)
        {
            Pos.y = borders.UpBorder;
            transform.position = Pos;
        }


        
  


        //Debug.DrawLine();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(new Vector3(borders.LeftBorder, borders.UpBorder, 0f), new Vector3(borders.RightBorder, borders.UpBorder, 0f));
        Gizmos.DrawLine(new Vector3(borders.LeftBorder, borders.DownBorder, 0f), new Vector3(borders.RightBorder, borders.DownBorder, 0f));
        Gizmos.DrawLine(new Vector3(borders.LeftBorder, borders.UpBorder, 0f), new Vector3(borders.LeftBorder, borders.DownBorder, 0f));
        Gizmos.DrawLine(new Vector3(borders.RightBorder, borders.UpBorder, 0f), new Vector3(borders.RightBorder, borders.DownBorder, 0f));
    }
}
