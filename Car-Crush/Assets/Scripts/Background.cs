using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] float scrollSpeed = 0.4f;

    [Header("Components")]
    [SerializeField] Material myMaterial;

    Vector2 offSet;
    // Start is called before the first frame update
    void Start()
    {
        offSet = new Vector2(0f, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
