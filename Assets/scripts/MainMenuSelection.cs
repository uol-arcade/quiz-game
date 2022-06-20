using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class MenuItem
{
    public TMPro.TMP_Text item;
    public UnityEvent callback;
}

public class MenuSelection : MonoBehaviour
{
    public List<MenuItem> items;
    public int index = 0;

    public Color selectedColor;
    public Color normalColor;

    public KeyCode prevKeyCode = KeyCode.UpArrow;
    public KeyCode nextKeyCode = KeyCode.DownArrow;

    // Start is called before the first frame update
    void Start()
    {
        SelectItem(index);
    }

    private void SelectItem(int index)
    {
        //OOB? Get out of here
        if(index >= items.Count || index < 0)
            return;

        //Get item
        var selectedItem = items[index];

        //Reset colours of all the items
        foreach(var item in items)
            item.item.color = normalColor;

        //Set color of text item to selected colour
        selectedItem.item.color = selectedColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(prevKeyCode))
        {
            index--;
            index = (index < 0) ? (items.Count - 1) : (index);
            SelectItem(index);
        }
        else if(Input.GetKeyDown(nextKeyCode))
        {
            index = (index + 1) % items.Count;
            SelectItem(index);
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z))
            items[index].callback.Invoke();
    }

    public void ExitGame()
    {
        Debug.Log("Exit the game");
        Application.Quit(-1);
    }
}
