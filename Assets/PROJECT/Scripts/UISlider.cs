using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UISlider : MonoBehaviour 
{
	public Slider _SliderSelf;
	public Slider _SliderTarget;

	[HideInInspector]
	public RewindBehaviour _RewindBehaviour;

	[HideInInspector]
	public TimeManager _PlayerTimeManager;

	// Use this for initialization
	void Awake () 
	{
		_RewindBehaviour = GetComponent<RewindBehaviour> ();
		_PlayerTimeManager = transform.parent.GetComponent<TimeManager> ();

		_SliderSelf.maxValue = _PlayerTimeManager._StockingCapacity;
	}
	
	// Update is called once per frame
	void Update () 
	{
		_SliderSelf.value = _PlayerTimeManager._PreviousTransforms.Count;



	}
}
