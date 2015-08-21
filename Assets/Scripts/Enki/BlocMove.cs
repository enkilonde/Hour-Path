using UnityEngine;
using System.Collections;

public class BlocMove : MonoBehaviour {

	private TimeManager _TM;


	public Vector3 _TranslationTarget = Vector3.zero;
	private Vector3 _InitialPos;
	public float _VitesseDeTranslation = 0;
	private int _TranslationDirection = 1;


	public float _VitesseRotationX = 0;
	public float _VitesseRotationY = 0;
	public float _VitesseRotationZ = 0;

	// Use this for initialization
	void Awake () 
	{
		_InitialPos = transform.position;
		_TM = GetComponent<TimeManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!_TM._BackInTime) 
		{

			Translate ();
			
			Rotate ();

		}




	}


	void Translate()
	{

		Vector3 _Direction = _TranslationTarget - _InitialPos;
		transform.position += _Direction.normalized * (_VitesseDeTranslation/50) * _TranslationDirection;

		if ((Vector3.Distance (transform.position, _TranslationTarget) < _VitesseDeTranslation/50 && _TranslationDirection == 1) || (Vector3.Distance (transform.position, _InitialPos) < _VitesseDeTranslation/50 && _TranslationDirection == -1))
		{
			_TranslationDirection *= -1;
		}

	}

	void Rotate()
	{

		transform.Rotate (_VitesseRotationX, _VitesseRotationY, _VitesseRotationZ);


	}

	void Scale()
	{
		
	}



}
