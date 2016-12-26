using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Type { Player, Block_Blanc, Block_Violet, Block_Jaune, Block_Rouge, Block_Vert };

public class TimeManager : BaseObject {

    public Type type;

    [Serializable]
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
	
	public List<ObjectTransform> _PreviousTransforms = new List<ObjectTransform>();
	
	public int _StockingCapacity = 50;
	public int _StockingFrequency = 1;
	

	public int _BackTimeSpeed = 1;

	[HideInInspector]
	public bool _BackInTime = false;

    AnimationCurve rewindCurve;

    Rigidbody localRigidbody;

    protected override void FirstAwake()
    {
        base.FirstAwake();
        rewindCurve = FindObjectOfType<GameController>().rewindCurve;
        localRigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnLoadEnded()
    {
        base.OnLoadEnded();
        StartCoroutine(StockageTime());
        StartCoroutine(Rewinding());
    }

    protected override void BaseUpdate()
    {
        base.BaseUpdate();

    }

    //On stock les position de l'objet dans une liste
    IEnumerator StockageTime()
	{
		while (true)
		{

			for (int i = 0; i < _StockingFrequency; i++) {
                yield return new WaitForFixedUpdate();
            }
            if (_BackInTime) continue;


			if (_PreviousTransforms.Count>0)
			{
				if (type != Type.Player && (transform.position != _PreviousTransforms[_PreviousTransforms.Count-1]._Position || transform.rotation != _PreviousTransforms[_PreviousTransforms.Count-1]._Rotation || transform.localScale != _PreviousTransforms[_PreviousTransforms.Count-1]._Scale))
				{
                    _PreviousTransforms.Add(new ObjectTransform(transform.position, transform.rotation, transform.localScale));
                }

                if (type == Type.Player && transform.position != _PreviousTransforms[_PreviousTransforms.Count - 1]._Position)
                {
                    _PreviousTransforms.Add(new ObjectTransform(transform.position, transform.rotation, transform.localScale));
                }


            }
			else 
			{
				_PreviousTransforms.Add (new ObjectTransform(transform.position, transform.rotation, transform.localScale));
			}


				
			if (_PreviousTransforms.Count > _StockingCapacity) _PreviousTransforms.RemoveAt(0);
			

		}
	}

	//on rewind
	IEnumerator Rewinding()
	{
		while (true) 
		{
            if (!_BackInTime || _PreviousTransforms.Count == 0)
            {
                yield return new WaitForFixedUpdate();
                continue;
            }


            Vector3 originalPos = transform.position;
            Quaternion originalRot = transform.rotation;
			for (int i = 0; i < _BackTimeSpeed; i++)
            {
                yield return new WaitForFixedUpdate();
                float interpolationIndex = (float)(i+1) / (float)_BackTimeSpeed;
                transform.position = Vector3.Lerp(originalPos, _PreviousTransforms[_PreviousTransforms.Count - 1]._Position, interpolationIndex);
                transform.rotation = Quaternion.Lerp(originalRot, _PreviousTransforms[_PreviousTransforms.Count - 1]._Rotation, interpolationIndex);
            }
            _PreviousTransforms.RemoveAt(_PreviousTransforms.Count - 1);
		}
	}


    public void SetRewind(bool State)
    {
        if (State) ActivateRewind();
        else DesactivateRewind();
    }

    public void ActivateRewind()
    {
        if (localRigidbody)
        {
            localRigidbody.isKinematic = true;
        }
        _BackInTime = true;
    }

    public void DesactivateRewind()
    {
        if (type == Type.Block_Jaune && _PreviousTransforms.Count > 0)
        {
            StartCoroutine(WaitForYellowBlockEndRewind());
            return;
        }

        if (localRigidbody)
        {
            localRigidbody.isKinematic = false;
        }

        _BackInTime = false;
    }

	IEnumerator WaitForYellowBlockEndRewind()
    {
        while (type == Type.Block_Jaune && _PreviousTransforms.Count > 0)
        {
            yield return null;
        }

        if (localRigidbody)
        {
            localRigidbody.isKinematic = false;
        }
        _BackInTime = false;
    }
	
}

