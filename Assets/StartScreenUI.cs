using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void Show()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
