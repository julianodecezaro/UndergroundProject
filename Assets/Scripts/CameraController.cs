using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public 	Camera			MainCamera;
	public	GameObject		Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (MainCamera.ViewportToScreenPoint());
		//Debug.Log (MainCamera.pixelHeight);
		//Debug.Log (MainCamera.pixelWidth);
		//Debug.Log (Player.transform.position);

		MainCamera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
	}
}
