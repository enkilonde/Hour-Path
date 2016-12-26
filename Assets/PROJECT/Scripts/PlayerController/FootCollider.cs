using UnityEngine;
using System.Collections;

public class FootCollider : MonoBehaviour {

	private Jump _JumpScript;
    private CheckpointsBehaviour respanwScript;
	

	private Vector3 _parentposChange = Vector3.zero;

	private Vector3 _previousParentPos;
	private float _PreviousParentRotY = 0.0f;

	public Transform _Parent;
	private bool _NoParent = true;



	// Use this for initialization
	void Awake () 
	{
        respanwScript = FindObjectOfType<CheckpointsBehaviour>();
		_JumpScript = transform.parent.Find ("Scripts").GetComponent<Jump> ();
	}

	void Update()
	{
		if (_Parent) 
		{
			if (!_NoParent)
			{
				_parentposChange = _Parent.position - _previousParentPos;
				transform.parent.position += _parentposChange;
				MouseLook._RotationCustom += _Parent.localRotation.eulerAngles.y - _PreviousParentRotY;
			}
			_previousParentPos = _Parent.position;
			_PreviousParentRotY = _Parent.localRotation.eulerAngles.y;

			_NoParent = false;
		}
		else 
		{
			_NoParent = true;

		}

	}


	// Update is called once per frame
	void FixedUpdate () 
	{
        

      //  _JumpScript._Grounded = false;

	}

	void OnTriggerEnter(Collider _Coll)
	{

        _JumpScript._Grounded = true;

        if (_Coll.GetComponent<TimeManager>())
        {
            if (_Coll.GetComponent<TimeManager>().type == Type.Block_Vert)
                respanwScript.checkPoint = _Coll.transform.position + new Vector3(0, 1 + _Coll.transform.localScale.y / 2, 0);
        }

        _Parent = _Coll.transform;

	}

	void OnTriggerExit(Collider _Coll)
	{
		_JumpScript._Grounded = false;
        _Parent = null;

    }




}
