using UnityEngine;
using System.Collections;

public class TilingScript : MonoBehaviour {

    public GameObject Racetrack;
    public Renderer r;
    public float XScale = 6;
    public float YScale = 6;

	// Use this for initialization
	void Start () {
        r = Racetrack.GetComponent<Renderer>();
        //r.material.mainTextureScale = new Vector2(XScale, YScale);
    }
	
	// Update is called once per frame
	void Update () {
        r.material.SetTextureScale("_MainTex", new Vector2(this.gameObject.transform.lossyScale.x, this.gameObject.transform.lossyScale.y));
    }
}
