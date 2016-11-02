using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

    public GameObject[] objects;
    private int currentActiveObject;
    
    private void OnEnable()
    {
        currentActiveObject = 0;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("c"))
        {
            SwitchCamera(currentActiveObject);
        }
    }

    public void SwitchCamera(int cameraActive)
    {
        int nextactiveobject = currentActiveObject + 1 >= objects.Length ? 0 : currentActiveObject + 1;

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == nextactiveobject);
        }
        currentActiveObject = nextactiveobject;
    }
}
