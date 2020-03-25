using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks = 0;
    SceneLoader sceneLoader;
    // Start is called before the first frame update
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void decreaseBlockCount()
    {
        breakableBlocks--;
        if(breakableBlocks ==0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
