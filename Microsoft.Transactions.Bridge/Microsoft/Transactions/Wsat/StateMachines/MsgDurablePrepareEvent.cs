﻿namespace Microsoft.Transactions.Wsat.StateMachines
{
    using Microsoft.Transactions.Wsat.Messaging;
    using Microsoft.Transactions.Wsat.Protocol;
    using System;
    using System.Runtime;

    internal class MsgDurablePrepareEvent : DurableTwoPhaseCommitCoordinatorEvent
    {
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public MsgDurablePrepareEvent(CoordinatorEnlistment coordinator) : base(coordinator)
        {
        }

        public override void Execute(StateMachine stateMachine)
        {
            if (DebugTrace.Info)
            {
                base.state.DebugTraceSink.OnEvent(this);
            }
            stateMachine.State.OnEvent(this);
        }
    }
}

