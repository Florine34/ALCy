using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class TextureTiling : MonoBehaviour {
	// Use this for initialization
	void Start () {
        var renderer = GetComponent<MeshRenderer>();
        var newMaterial = Material.Instantiate<Material>(renderer.material);
        var texture = newMaterial.GetTexture("_MainTex");
        var textureRatio = (float) texture.width / (float) texture.height;
        var objectRatio = transform.lossyScale.x / transform.lossyScale.y;
        var texToObjRatio = objectRatio / textureRatio;
        var tiling = Vector2.one;
        if (texToObjRatio < 1f)
            tiling = new Vector2(1f, 1.0f / texToObjRatio);
        else
            tiling = new Vector2(texToObjRatio, 1f);
        //Debug.Log(string.Format("{0} ({3}x{4}), {1}, {2}", textureRatio, objectRatio, texToObjRatio, texture.width, texture.height), newMaterial);
        newMaterial.SetTextureScale("_MainTex", tiling);
        renderer.material = newMaterial;
	}
}
