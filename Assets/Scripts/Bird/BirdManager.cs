﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdManager : MonoBehaviour
{
    public delegate void BirdSelectHandler(BirdManager sender, Bird affectedObject);
    public event BirdSelectHandler BirdSelected;
    public event BirdSelectHandler SelectionCleared;

    public static BirdManager Instance;

    List<Bird> birdList;
    Bird selectedBird;

    public Bird SelectedBird
    {
        get { return selectedBird; }
    }

    bool hasInitialized = false;

    void Awake()
    {
        if (hasInitialized) return;
        Instance = this;
        birdList = new List<Bird>();

        hasInitialized = true;
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void SelectBird(Bird newSelection)
    {
        if (selectedBird != null) selectedBird.Deselect();
        selectedBird = newSelection;

        if(BirdSelected != null)
        {
            BirdSelected(this, selectedBird);
        }
    }

    public void AddBird(Bird newBird)
    {
        Awake();
        birdList.Add(newBird);
    }

    public void RemoveBird(Bird bird)
    {
        if(selectedBird == bird)
        {
            if(SelectionCleared != null)
            {
                SelectionCleared(this, null);
            }
        }

        birdList.Remove(bird);
    }
}