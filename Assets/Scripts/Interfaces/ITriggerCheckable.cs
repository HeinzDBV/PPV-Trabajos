using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool IsAggroed { get; set; }
    bool IsInAttackRange { get; set; }

    void SetAggroed(bool value);
    void SetInAttackRange(bool value);
}
