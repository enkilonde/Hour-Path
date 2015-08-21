using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	private Transform _ParentTransform;
	private Rigidbody _Rigidbody;

	public float _Speed = 1;

	private TimeManager _PlayerTimeManager;

	// Use this for initialization
	void Awake () 
	{
		_PlayerTimeManager = transform.parent.GetComponent<TimeManager> ();
		_ParentTransform = transform.parent;
		_Rigidbody = transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void FixedUpdate () 
	{
		if (!_PlayerTimeManager._BackInTime) 
		{
			Vector3 _Direction = _ParentTransform.forward * Input.GetAxisRaw ("Vertical") + _ParentTransform.transform.right * Input.GetAxisRaw ("Horizontal");
			_Direction *= _Speed;
			_Rigidbody.velocity = new Vector3 (_Direction.x, _Rigidbody.velocity.y, _Direction.z);
		}

	}
}
