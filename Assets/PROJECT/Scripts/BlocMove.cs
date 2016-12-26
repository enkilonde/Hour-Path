using UnityEngine;
using System.Collections;

public class BlocMove : MonoBehaviour {

	private TimeManager _TM;

    public bool useLocalCohordinates = true;

	public Vector3 _TranslationTarget = Vector3.zero;
	private Vector3 _InitialPos;
	public float _VitesseDeTranslation = 1;
	private int _TranslationDirection = 1;

    public Vector3 vitesseRotation;


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
        Vector3 destination = useLocalCohordinates ? _TranslationTarget + _InitialPos : _TranslationTarget;

		Vector3 _Direction = destination - _InitialPos;
		transform.position += _Direction.normalized * (_VitesseDeTranslation/50) * _TranslationDirection;

		if ((Vector3.Distance (transform.position, destination) < _VitesseDeTranslation/50 && _TranslationDirection == 1) || (Vector3.Distance (transform.position, _InitialPos) < _VitesseDeTranslation/50 && _TranslationDirection == -1))
		{
			_TranslationDirection *= -1;
		}

	}

	void Rotate()
	{
		transform.Rotate (vitesseRotation.x, vitesseRotation.y, vitesseRotation.z);
	}

	void Scale()
	{
		
	}



}
