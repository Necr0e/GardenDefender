﻿using Enemy;
using UnityEngine;

namespace Defenders
{
    public class Gravestone : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            var attacker = other.GetComponent<Attacker>();
            if (attacker)
            {
                // animation
            }
        }
    }
}
