﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    void Start()
    {
        PlayerData.currentDepth = 0;
        PlayerData.currentHealth = 100;
        PlayerData.invulnerabilityRemaining = 0;
        PlayerData.maxHealth = 100;
        PlayerData.movementSpeed = 1;
        PlayerData.spellCooldownMultiplier = 1;
        PlayerData.spellDamageMultiplier = 1;
        PlayerData.spellDurationMultiplier = 1;
    }
}