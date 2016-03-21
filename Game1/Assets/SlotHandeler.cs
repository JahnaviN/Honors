using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlotHandeler : MonoBehaviour, IDropHandler {

    private Dictionary<string, int> dict;

    public Text score;

    //private int count;

    //private int score;

    void Start()
    {
        //count.text = 0.ToString();
        //count = 0;
        score.text = 0.ToString();
    }

	public GameObject item
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            Transform prevParent = DragHandeler.itemBeingDragged.transform.parent;
            DragHandeler.itemBeingDragged.transform.SetParent(transform);
            Transform nowParent = DragHandeler.itemBeingDragged.transform.parent;
            string tag = "slot" + DragHandeler.itemBeingDragged.tag;
            if(tag == nowParent.tag)
            {
                score.text = (Int32.Parse(score.text) + 20).ToString();
            }
            else if(tag == prevParent.tag)
            {
                score.text = (Int32.Parse(score.text) - 20).ToString();
            }

            if (Int32.Parse(score.text) == 100)
                SceneManager.LoadScene(1);

            //for(int i=1; i<=5; i++)
            //{
            //    string pTag = "slot" + i.ToString();
            //    GameObject slot = GameObject.FindGameObjectWithTag(pTag);
            //    string iTag = i.ToString();
            //    if(slot.transform.childCount !=0 && slot.transform.GetChild(0).tag == iTag)
            //    {
            //        count += 1;
            //    }
            //}
            //if (count == 5)
            //    SceneManager.LoadScene(1);
            //else
            //    count = 0;
        }
    }
}
