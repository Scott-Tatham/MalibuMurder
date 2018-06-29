using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MontageImage : MonoBehaviour
{
    [SerializeField]
    Vector2 sizeCorrection;
    [SerializeField]
    Texture2D cameraMap;
    [SerializeField]
    GameObject montageImage;
    [SerializeField]
    GameObject[] panels;

    Vector2 gridSize;

    void Start()
    {
        GenerateMontageImage();
    }

    void GenerateMontageImage()
    {
        gridSize = new Vector2(cameraMap.width, cameraMap.height);

        for (int i = 0; i < (int)gridSize.x; i++)
        {
            for (int j = 0; j < (int)gridSize.y; j++)
            {
                int index = (int)(cameraMap.GetPixel(i, j).r * panels.Length);
                Instantiate(panels[index], new Vector3(-14 + i * sizeCorrection.x, -3 + j * sizeCorrection.y, 1), Quaternion.identity, montageImage.transform);
            }
        }
    }
}
