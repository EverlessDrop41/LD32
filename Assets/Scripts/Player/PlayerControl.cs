using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour {

	public Vector2 Speed;
    public int Health = 5;

    public Text HealthDisplay;

	private Rigidbody2D RB;
	
	void Start() {
		RB = GetComponent<Rigidbody2D> ();

        if (Health <= 0)
        {
            Debug.LogError("Health is too small - PlayerControl.cs");
            HealthDisplay.text = string.Format("Health: ERROR");
        }
        else
        {
            HealthDisplay.text = string.Format("Health: {0}", Health);
        }
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

        if (Health < 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else
        {
            HealthDisplay.text = string.Format("Health: {0}", Health);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.gameObject.tag == "Enemy")
        {
            EnemyBehaviour enemy = coll.collider.gameObject.GetComponent<EnemyBehaviour>();
            if (enemy.EnemyType == EnemyTypes.Brute || enemy.isRaging())
            {
                //Destroy(this.gameObject);
                //Application.LoadLevel(Application.loadedLevel);
                Health--;
            }
        }
    }
}