using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    
    void Update()
    {
        if (Input.touchCount > 0) SceneMgr.Instance.switchToScene(1);
    }
}
