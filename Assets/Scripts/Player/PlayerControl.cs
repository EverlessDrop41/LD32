using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour {

	public Vector2 Speed;
	
	private Rigidbody2D RB;
	
	void Start() {
		RB = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		//Move
		float MoveX = Input.GetAxis ("Horizontal") * Speed.x;
		float MoveY = Input.GetAxis ("Vertical"  ) * Speed.y;
		
		RB.velocity = new Vector2 (MoveX, MoveY);
		
		//Rotate
		Vector3 ObjPos = Camera.main.WorldToScreenPoint (transform.position);
		Vector3 dir = Input.mousePosition - ObjPos;
		float rotZ = Mathf.Atan2 (dir.x, dir.y) * Mathf.Rad2Deg;
		
		RB.MoveRotation (-rotZ);
	}
}