using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/StateChannel")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "StateChannel", message: "Change [State]", category: "Events", id: "5cb738d0bb68873d2c611faec3be8ac4")]
public sealed partial class StateChannel : EventChannel<EnemyState> { }

