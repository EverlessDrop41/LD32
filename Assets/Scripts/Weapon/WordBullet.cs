using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class WordBullet : MonoBehaviour {

    public float Force = 25f;

    Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RB.AddForce(transform.right * Force, ForceMode2D.Force);
    }
}
