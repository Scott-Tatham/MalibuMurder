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
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].transform.localScale = new Vector3(sizeCorrection.x, sizeCorrection.y, 1);
        }

        gridSize = new Vector2(cameraMap.width, cameraMap.height);

        for (int i = 0; i < (int)gridSize.x; i++)
        {
            for (int j = 0; j < (int)gridSize.y; j++)
            {
                int index = Mathf.RoundToInt(cameraMap.GetPixel(i, j).r * 16);
                GameObject go = Instantiate(panels[index], new Vector3(((-cameraMap.width / 2) - (20 - sizeCorrection.x)) * sizeCorrection.x + i * sizeCorrection.x, (-cameraMap.height * sizeCorrection.y / 2) + (sizeCorrection.y / 2) + j * sizeCorrection.y, 1), Quaternion.identity);
                go.hideFlags = HideFlags.HideInHierarchy;
                go.transform.parent = montageImage.transform;
            }
        }
    }
}
