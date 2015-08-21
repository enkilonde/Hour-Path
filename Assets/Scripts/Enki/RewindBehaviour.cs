using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewindBehaviour : MonoBehaviour {

	private GameObject _ObjectHit;
	private TimeManager _PlayerTimeManager;

	// Use this for initialization
	void Start () 
	{
		_PlayerTimeManager = transform.parent.GetComponent<TimeManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_ObjectHit) 
		{
			//_ObjectHit.GetComponent<TimeManager>()._BackInTime = false;
		}
		RaycastHit _Hit;
		Ray _Ray = Camera.main.ViewportPointToRay (new Vector3(0.5f, 0.5f, 0));
		if (Physics.Raycast (_Ray, out _Hit, 10000)) 
		{


			if (_Hit.collider.gameObject.tag == "Rewindable")
			{
				if (!Input.GetButton("RemindTarget"))
				{
					_ObjectHit = _Hit.collider.gameObject;
				}

				if (Input.GetButtonDown("RemindTarget"))
				{
					_Hit.collider.gameObject.GetComponent<TimeManager>()._BackInTime = true;
				}

			}
		}


		if (Input.GetButtonUp ("RemindTarget") && _ObjectHit) 
		{
			_ObjectHit.GetComponent<TimeManager>()._BackInTime = false;
		}


		if (Input.GetButton ("RewindSelf")) 
		{
			_PlayerTimeManager._BackInTime = true;

		}
		else
		{
			_PlayerTimeManager._BackInTime = false;
		}


		
	}
	


}
