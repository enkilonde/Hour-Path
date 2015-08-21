﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour {
	
	
	public class ObjectTransform
	{
		public Vector3 _Position;
		public Quaternion _Rotation;
		public Vector3 _Scale;
		
		public ObjectTransform (Vector3 _pos, Quaternion _rot, Vector3 _sca)
		{
			_Position = _pos;
			_Rotation = _rot;
			_Scale = _sca;
		}
		
	}
	
	public List<ObjectTransform> _PreviousTransform = new List<ObjectTransform>();
	
	public int _StockingCapacity = 50;
	public float _StockingFrequency = 0.5f;
	
	public float _BackTimeSpeed = 1;

	public bool _BackInTime = false;

	
	// Use this for initialization
	void Start () 
	{
		StartCoroutine (StockageTime ());
		StartCoroutine (Rewinding ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	IEnumerator StockageTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(_StockingFrequency);

			if (!_BackInTime)
			{
				_PreviousTransform.Add (new ObjectTransform(transform.position, transform.rotation, transform.localScale));
				
				if (_PreviousTransform.Count > _StockingCapacity)
				{
					_PreviousTransform.RemoveAt(0);
				}
			}

		}
	}


	IEnumerator Rewinding()
	{
		while (true) 
		{
			yield return new WaitForSeconds(_BackTimeSpeed);

			if (_BackInTime && _PreviousTransform.Count > 0)
			{
				transform.position = _PreviousTransform[_PreviousTransform.Count - 1]._Position;
				transform.localScale = _PreviousTransform[_PreviousTransform.Count - 1]._Scale;

				if (transform.tag != "Player")
				{
					transform.rotation = _PreviousTransform[_PreviousTransform.Count - 1]._Rotation;
				}

				_PreviousTransform.RemoveAt(_PreviousTransform.Count - 1);
			}

		}

	}





	
	
}
