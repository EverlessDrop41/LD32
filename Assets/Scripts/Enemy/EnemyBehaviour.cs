using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour {

    public GameObject Player;
    public EnemyTypes EnemyType;
    public GameObject Explosion;

	private bool raging;
	
    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.gameObject.CompareTag("WordBullet"))
        {
            TextMesh text = coll.collider.GetComponent<TextMesh>();
            Debug.Log(text.text);
            Destroy(coll.collider.gameObject);
            //Destroy(this.gameObject);
            ReactToPhrase(WordActionCalculator.GetPhraseType(text.text));
        }
    }

	void Update () {
        Vector3 dir = Player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;

        RB.MoveRotation(-rotZ);

        if (raging)
        {
            RB.AddForce(dir * 10);
        }

	}

    void ReactToPhrase(PhraseActions phraseType)
    {
        if ((EnemyType == EnemyTypes.Brute && !raging ) || phraseType == PhraseActions.Rage)
        {
            raging = true;
            return;
        }

        if (EnemyType == EnemyTypes.Explosive || phraseType == PhraseActions.Explode)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            return;
        }

        if (phraseType == PhraseActions.Die)
        {
            Destroy(this.gameObject);
            return;
        }
		
		if (phraseType == PhraseActions.Rage) 
		{
			raging = true;
		}

    }
	
	public bool isRaging() { return raging; }
}
