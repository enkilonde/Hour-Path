using UnityEngine;
using System.Collections;

public class FootCollider : MonoBehaviour {


	private Jump _JumpScript;

	// Use this for initialization
	void Start () 
	{
		_JumpScript = transform.parent.Find ("Scripts").GetComponent<Jump> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider _Coll)
	{
		_JumpScript._Grounded = true;
	}

	void OnTriggerExit(Collider _Coll)
	{
		_JumpScript._Grounded = false;
	}


}
