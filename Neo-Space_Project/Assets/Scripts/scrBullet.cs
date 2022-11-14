using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrBullet : MonoBehaviour {

    [SerializeField] private float Speed;
	
	void Start () {
		
	}
	
	
	void Update () {
        transform.position += transform.up * Speed * Time.deltaTime;
	}
}
