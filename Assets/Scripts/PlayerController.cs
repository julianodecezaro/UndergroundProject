using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public 	GameObject 			Player;
	public 	Rigidbody2D 		PlayerRigidbody;
	public 	int					JumpForce;
	public 	int					RunForce;
	public 	Animator			Anim;
	public 	bool				Jumping;
	public 	bool				Sliding;
	public 	Transform			GroundCheck;
	public 	bool				Grounded;
	public 	LayerMask			WhatIsGround;
	public 	float				SlideTimeCount;
	public 	float				SlideMaxTime;
	public 	float				Speed;
	public 	float				X;
	public 	PolygonCollider2D	PlayerCollider;
	public	SpriteRenderer		PlayerSprite;
	public	string				LastPlayerSpriteName;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") && Grounded) {
			PlayerRigidbody.AddForce (new Vector2 (0, JumpForce));
			Jumping = true;
			Sliding = false;
		}

		if (Input.GetButtonDown ("Slide") && Grounded) {
			Sliding = true;
			SlideTimeCount = 0;
		}

		if (Input.GetButton ("Forward")) {
			Player.transform.localRotation = Quaternion.Euler(0, 0, 0);
			X = Player.transform.position.x;
			X += Speed * Time.deltaTime;
			Player.transform.position = new Vector3(X, Player.transform.position.y, Player.transform.position.z); 
		}

		if (Input.GetButton ("Backward")) {
			Player.transform.localRotation = Quaternion.Euler(0, 180, 0);
			X = Player.transform.position.x;
			X += (Speed*-1) * Time.deltaTime;
			Player.transform.position = new Vector3(X, Player.transform.position.y, Player.transform.position.z); 
		}

		if (Sliding) {
			SlideTimeCount += Time.deltaTime;
			if (SlideTimeCount >= SlideMaxTime) {
				Sliding = false;
			}
		}

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, WhatIsGround);

		if (PlayerSprite.sprite.name != LastPlayerSpriteName) {
			PlayerCollider.points = getCollider ();
		}

		Anim.SetBool ("jumping", !Grounded);
		Anim.SetBool ("sliding", Sliding);
		
	}

	Vector2[] getCollider()
	{
		switch(PlayerSprite.sprite.name){
			case "sprite_sheet_12":
				Vector2[] points = {
					new Vector2 (0.2111317f, 0.354152f),
					new Vector2 (0.3211317f, 0.3477366f),
					new Vector2 (0.2947162f, 0.5188682f),
					new Vector2 (0.2800354f, 0.6959928f),
					new Vector2 (0.159872f, 0.6648027f),
					new Vector2 (0.147922f, 0.7894323f),
					new Vector2 (0.3011317f, 0.9777365f),
					new Vector2 (0.32f, 1.01f),
					new Vector2 (0.1769769f, 1.047358f),
					new Vector2 (0.09716883f, 1.121132f),
					new Vector2 (-0.0679257f, 1.094716f),
					new Vector2 (-0.1239592f, 1.013206f),
					new Vector2 (-0.2456587f, 1.067926f),
					new Vector2 (-0.3324527f, 0.9530203f),
					new Vector2 (-0.0571688f, 0.7401892f),
					new Vector2 (-0.0422633f, 0.5939629f),
					new Vector2 (-0.21f, 0.1411282f),
					new Vector2 (-0.1418849f, 0.0145269f),
					new Vector2 (-0.15f, 0.0f),
					new Vector2 (-0.0222635f, 0.08302039f),
					new Vector2 (0.0124528f, 0.1883042f),
					new Vector2 (0.0562264f, 0.5001892f)
				};
				return points;
			default:
				Vector2[] points2 = {
					new Vector2 (0.1712136f, 0.7937379f),
					new Vector2 (0.01757312f, 0.7624271f),
					new Vector2 (-0.0599029f, 0.544854f),
					new Vector2 (-0.1574757f, 0.4537377f),
					new Vector2 (-0.1334455f, 0.2752436f),
					new Vector2 (-0.2712135f, 0.1238351f),
					new Vector2 (-0.2125244f, 0.06262159f),
					new Vector2 (0.09606767f, 0.05635941f),
					new Vector2 (0.1438324f, 0.22598536f),
					new Vector2 (0.1397078f, 0.3701947f),
					new Vector2 (0.2782462f, 0.4993856f),
					new Vector2 (0.2586892f, 0.7286892f)
				};
				return points2;
		}
	}
}
