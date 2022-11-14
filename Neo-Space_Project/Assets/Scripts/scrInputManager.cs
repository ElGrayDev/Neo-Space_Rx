using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrInputManager : MonoBehaviour {

	public static float vertical (){

		return Input.GetAxis("Vertical");
	}

	public static float horizontal (){

		return Input.GetAxis("Horizontal");
	}

	public static bool FireKey (){

		return Input.GetMouseButtonDown(0);
	}

}
