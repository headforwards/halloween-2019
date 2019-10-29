using System.Collections.Generic;
using UnityEngine;

public class BloodSplatter : MonoBehaviour
{

    public float MinScale = 0f;
    public float MaxScale = 4f;
    public Canvas canvas;

    private List<GameObject> _splats;

    void Start()
    {
        _splats = new List<GameObject>();
    }

    public void Splat()
    {
        var rt = canvas.GetComponent<RectTransform>();

        var w = rt.rect.width;
        var h = rt.rect.height;

        var x = Random.Range(0, w);
        var y = Random.Range(0, h);
        var rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        var scale = Random.Range(MinScale, MaxScale);

        var idx = Random.Range(1, 7);
        var splat = Resources.Load($"blood{idx}");

        var splatObject = Instantiate(splat, new Vector3(x, y, 0), rotation, canvas.transform) as GameObject;

        _splats.Add(splatObject);

        splatObject.transform.localScale += new Vector3(scale, scale, scale);
        
    }

    public void Clear()
    {
        foreach(var splat in _splats)
        {
            Destroy(splat, 3f);
        }

        _splats.Clear();
    }
}