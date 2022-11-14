using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(scrMoveWrap))]
[RequireComponent(typeof(Rigidbody2D))]
public class scrAsteroid : MonoBehaviour {

    [SerializeField] private Sprite[] Sprites;
    private SpriteRenderer SprRender;

    [SerializeField] private float Speed;

    private Rigidbody2D Rb2D;

    void Start () {

        Rb2D = GetComponent<Rigidbody2D>();

        SprRender = GetComponent<SpriteRenderer>();
        SprRender.sprite = Sprites[Random.Range(0, Sprites.Length)];

        //transform.rotation = Quaternion.Euler(0f,0f,Random.Range(0f,360f));

        Rb2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Speed;

        Rb2D.angularVelocity = Random.Range(-100f, 100f);

    }
	
	
	void Update () {

      
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(Other.gameObject);
        }
    }
}
