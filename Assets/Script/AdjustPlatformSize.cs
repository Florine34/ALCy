using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(BoxCollider2D))]
public class AdjustPlatformSize : MonoBehaviour {
    public bool vertical;

#if UNITY_EDITOR
    [ContextMenu("Ajuster...")]
    public void Ajuster()
    {
        var collider = GetComponent<BoxCollider2D>();

        if (vertical)
        {
            var scaleX = collider.size.y / 2.5f;
            var scaleY = collider.size.x / 0.625f;

            transform.localRotation = Quaternion.Euler(0, 0, 90);
            transform.localScale = new Vector3(scaleX * transform.localScale.y, scaleY * transform.localScale.x, transform.localScale.z);
            transform.localPosition -= new Vector3(transform.localScale.y * -0.3125f, transform.localScale.x * 1.25f, 0f);
            collider.size = new Vector2(2.5f, 0.625f);
            collider.offset = new Vector2(1.25f, 0.3125f);
        }
        else
        {
            var scaleX = collider.size.x / 2.5f;
            var scaleY = collider.size.y;

            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(scaleX, scaleY, 1f));
            collider.size = new Vector2(2.5f, 1.0f);
            transform.localPosition -= Vector3.Scale(transform.localScale, new Vector3(+1.25f, 0f, 0f));
            collider.offset = new Vector2(1.25f, 0f);
        }
    }
#endif
}
