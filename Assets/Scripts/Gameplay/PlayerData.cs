﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    [Header("Saved")]
    public static SpellEnum equippedSpell;
    public static int maxDepth;

    [Header("Dynamic")]
    public static int currentDepth;
    public static float maxHealth = 100;
    public static float currentHealth = 100;
    public static float spellCooldownMultiplier = 1;
    public static float spellDamageMultiplier = 1;
    public static float movementSpeed = 1;
    public static float invulnerabilityRemaining = 0;
    public static float spellDurationMultiplier = 1;

    public static bool debugHUD = true;
}
