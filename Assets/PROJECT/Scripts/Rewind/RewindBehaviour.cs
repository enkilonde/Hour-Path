using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewindBehaviour : BaseObject {

	public TimeManager _ObjectHit;
	private TimeManager _PlayerTimeManager;

	private UISlider _UISiderBehaviour;


    protected override void FirstAwake()
    {
        base.FirstAwake();
        _UISiderBehaviour = GetComponent<UISlider>();
        _PlayerTimeManager = transform.parent.GetComponent<TimeManager>();
    }

    protected override void BaseUpdate()
    {
        base.BaseUpdate();



        if (!RaycastMethod())
        {
            if (_ObjectHit && !Input.GetButton("RemindTarget"))
            {
                ResetObjectHit();
            }
        }


        if (_ObjectHit)
        {
            _ObjectHit.SetRewind(Input.GetButton("RemindTarget"));
            _UISiderBehaviour._SliderTarget.maxValue = _ObjectHit._StockingCapacity;
            _UISiderBehaviour._SliderTarget.value = _ObjectHit._PreviousTransforms.Count;
        }

        _PlayerTimeManager.SetRewind(Input.GetButton("RewindSelf"));


		
	}


    bool RaycastMethod()
    {
        if (Input.GetButton("RemindTarget")) return false;

        RaycastHit _Hit;
        Ray _Ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (!Physics.Raycast(_Ray, out _Hit, 10000)) return false;

        if (_Hit.collider.gameObject.tag != "Rewindable") return false;

        TimeManager hitTM = _Hit.collider.gameObject.GetComponent<TimeManager>();

        if (_ObjectHit && hitTM != _ObjectHit) ResetObjectHit();

        _ObjectHit = _Hit.collider.gameObject.GetComponent<TimeManager>();

        _UISiderBehaviour._SliderTarget.maxValue = _ObjectHit._StockingCapacity;
        _UISiderBehaviour._SliderTarget.value = _ObjectHit._PreviousTransforms.Count;

        _ObjectHit.gameObject.layer = LayerMask.NameToLayer("TransparentFX");

        return true;  
    }
	
    void ResetObjectHit()
    {

        _ObjectHit.DesactivateRewind();

        _ObjectHit.gameObject.layer = LayerMask.NameToLayer("Default");
        _ObjectHit = null;
    }

}
