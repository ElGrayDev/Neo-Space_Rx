using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer : MonoBehaviour {

    #region Variables

    [Header("Movimientos")]
    [SerializeField] private float AccMotion;
    [SerializeField] private float MaxVel;
    [SerializeField] private float ActualVel;


    [Header("Componentes")]
    [SerializeField] Camera Cam;
    private Rigidbody2D Rb2D;

    [Header("Input del jugador")]
    private float KeyHor;
    private float KeyVer;
    private bool KeyShot;
    private Quaternion NewRotation;
    private Vector3 Target;

    [Header("Disparo de balas")]
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform ShotPoint;
    [SerializeField] private float CD, Timer;

    #endregion

    #region Metodos importantes

    void Start () {

		Rb2D = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {

		KeyHor = scrInputManager.horizontal();
		KeyVer = scrInputManager.vertical ();
		KeyShot = scrInputManager.FireKey ();

        Rotation();

        if (KeyShot && Timer <= 0)
        {
            ShootBullet();
        }

        Timer -= Time.deltaTime * 8;
    }

	void FixedUpdate ()
	{
		var forwardMotorHor = Mathf.Clamp (KeyHor, -1f, 1f);
		Rb2D.AddForce (Vector2.right * AccMotion * forwardMotorHor);

		var forwardMotorVer = Mathf.Clamp (KeyVer, -1f, 1f);
		Rb2D.AddForce (Vector2.up * AccMotion * forwardMotorVer);
	}

    #endregion

    #region  Otros metodos 

    void Rotation ()
    {
        Target = Cam.ScreenToWorldPoint(Input.mousePosition);

        float RadAngle = Mathf.Atan2(Target.y - transform.position.y, Target.x - transform.position.x);
        float GradsAngle = (180 / Mathf.PI) * RadAngle - 90;

        NewRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, GradsAngle);

        transform.rotation = Quaternion.Slerp(transform.rotation, NewRotation, 0.3f);

        if (Rb2D.velocity.magnitude > MaxVel)
        {
            Rb2D.velocity = Rb2D.velocity.normalized * MaxVel;
        }

        ActualVel = Rb2D.velocity.magnitude;
        
    }

    void ShootBullet ()
    {
       var Bullet = Instantiate(BulletPrefab, ShotPoint.position, transform.rotation);
        Bullet.transform.parent = transform;

        Destroy(Bullet, 5);

        Timer = CD;
    }

    #endregion

}
