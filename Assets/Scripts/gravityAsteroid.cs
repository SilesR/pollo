using UnityEngine;
using System.Collections;

public class gravityAsteroid : MonoBehaviour {

	

	

	void Update () {
		if (Input.GetKey ("t"))
						rigidbody2D.gravityScale = 1;
			}
}
