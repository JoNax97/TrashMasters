using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Attack : RAINAction
{
    Unit unit;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
        unit = ai.Body.GetComponent<Unit>();
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        unit.Attack(ai.WorkingMemory.GetItem<GameObject>("reachableEnemy").GetComponent<Unit>());
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}