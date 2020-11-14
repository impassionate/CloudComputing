﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string MenuName;
    public bool open;
    public void Open() {
        Debug.Log("Open" + MenuName);
        open = true;
        gameObject.SetActive(true);
    }
    public void Close() {
        open = false;
        gameObject.SetActive(false);
    }
}
