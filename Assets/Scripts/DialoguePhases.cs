using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialoguePhases
{
    public static int currentPhase { get; private set; }

    public static void AdvancePhase()
    {
        currentPhase++;
    }
}
