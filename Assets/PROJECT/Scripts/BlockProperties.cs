using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BlockProperties : BaseObject {

	public enum Type {Blanc, Violet, Jaune, Rouge, Vert, VertFonce};
	public Type _Couleur = Type.Blanc;

	public Renderer _Mesh;

	public Material _BlancMaterial;
	public Material _VioletMaterial;
	public Material _JauneMaterial;
	public Material _RougeMaterial;
	public Material _VertMaterial;
	public Material _VertFonceMaterial;

    protected override void BaseUpdate()
    {
        base.BaseUpdate();
        SetColor();
    }




	void SetColor()
	{

		switch (_Couleur) 
		{
		case Type.Blanc : 
			_Mesh.material = _BlancMaterial;
			break;
			
		case Type.Violet : 
			_Mesh.material = _VioletMaterial;
			break;
			
		case Type.Jaune : 
			_Mesh.material = _JauneMaterial;
			break;
			
		case Type.Rouge : 
			_Mesh.material = _RougeMaterial;
			break;
			
		case Type.Vert : 
			_Mesh.material = _VertMaterial;
			break;
			
		case Type.VertFonce : 
			_Mesh.material = _VertFonceMaterial;
			break;
		}

	}




}
