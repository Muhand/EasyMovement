using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMovement;

public class PlayerMovement : MonoBehaviour {

    //This can be any vector3, in this case we have a gameobject and then we will take it's position, simply instead of gameobject you can have mouse click, etc...
    [SerializeField]
    GameObject direction;       

	void FixedUpdate () {
        Move2DObject.translateOverLine(gameObject, direction.transform.position, 0.1f, 1000);
	}
}
