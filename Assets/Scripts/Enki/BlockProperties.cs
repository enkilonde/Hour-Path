using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BlockProperties : MonoBehaviour {

	public enum Type {Blanc, Violet, Jaune, Rouge, Vert, VertFonce};
	public Type _Couleur = Type.Blanc;

	public Renderer _BlockRenderer;

	public Material _BlancMaterial;
	public Material _VioletMaterial;
	public Material _JauneMaterial;
	public Material _RougeMaterial;
	public Material _VertMaterial;
	public Material _VertFonceMaterial;


	// Use this for initialization
	void Awake () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

		SetColor ();


	}








	void SetColor()
	{

		switch (_Couleur) 
		{
		case Type.Blanc : 
			_BlockRenderer.material = _BlancMaterial;
			break;
			
		case Type.Violet : 
			_BlockRenderer.material = _VioletMaterial;
			break;
			
		case Type.Jaune : 
			_BlockRenderer.material = _JauneMaterial;
			break;
			
		case Type.Rouge : 
			_BlockRenderer.material = _RougeMaterial;
			break;
			
		case Type.Vert : 
			_BlockRenderer.material = _VertMaterial;
			break;
			
		case Type.VertFonce : 
			_BlockRenderer.material = _VertFonceMaterial;
			break;
		}

	}




}
