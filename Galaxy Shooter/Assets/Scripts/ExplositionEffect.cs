using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplositionEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, 3.0f);
	}
	
	
}
