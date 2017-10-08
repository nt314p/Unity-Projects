using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

    public float speed = 0.02f;
    public float yval;
    public int posneg = 1;
	public int topPos;
	public int bottomPos;
    public float wallTarPos;
    public GameObject Wall;

	// Use this for initialization
	void Start () {
		wallTarPos = topPos;
		yval = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (wallTarPos <= Wall.transform.localPosition.y)
        {
            yval = yval - (speed);
			if (yval <= bottomPos)
            {
				wallTarPos = topPos;
            }
        }
        if (wallTarPos >= Wall.transform.localPosition.y)
        {
            yval = yval + (speed);
			if (yval >= topPos)
            {
				wallTarPos = bottomPos;
            }
        }
        Wall.transform.localPosition = new Vector3(Wall.transform.localPosition.x, yval, Wall.transform.localPosition.z);
	}
}
