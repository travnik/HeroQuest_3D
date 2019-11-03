﻿using Assets.Travnik.HeroQuest.Scripts.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode 
{
    public int X;
    public int Y;
    public int Cost;
    public Vector3 WorldPosition;
    public Vector2Int ArrayPosition;
    public NodeType Type;
}
