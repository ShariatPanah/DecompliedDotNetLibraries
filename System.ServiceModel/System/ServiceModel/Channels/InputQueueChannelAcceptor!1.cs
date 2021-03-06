﻿namespace System.ServiceModel.Channels
{
    using System;
    using System.Runtime;
    using System.ServiceModel.Diagnostics;

    internal class InputQueueChannelAcceptor<TChannel> : ChannelAcceptor<TChannel> where TChannel: class, IChannel
    {
        private InputQueue<TChannel> channelQueue;

        public InputQueueChannelAcceptor(ChannelManagerBase channelManager) : base(channelManager)
        {
            this.channelQueue = TraceUtility.CreateInputQueue<TChannel>();
        }

        public override TChannel AcceptChannel(TimeSpan timeout)
        {
            base.ThrowIfNotOpened();
            return this.channelQueue.Dequeue(timeout);
        }

        public override IAsyncResult BeginAcceptChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            base.ThrowIfNotOpened();
            return this.channelQueue.BeginDequeue(timeout, callback, state);
        }

        public override IAsyncResult BeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            base.ThrowIfNotOpened();
            return this.channelQueue.BeginWaitForItem(timeout, callback, state);
        }

        public void Dispatch()
        {
            this.channelQueue.Dispatch();
        }

        public override TChannel EndAcceptChannel(IAsyncResult result)
        {
            return this.channelQueue.EndDequeue(result);
        }

        public override bool EndWaitForChannel(IAsyncResult result)
        {
            return this.channelQueue.EndWaitForItem(result);
        }

        public void EnqueueAndDispatch(TChannel channel)
        {
            this.channelQueue.EnqueueAndDispatch(channel);
        }

        public void EnqueueAndDispatch(TChannel channel, Action dequeuedCallback)
        {
            this.channelQueue.EnqueueAndDispatch(channel, dequeuedCallback);
        }

        public void EnqueueAndDispatch(TChannel channel, Action dequeuedCallback, bool canDispatchOnThisThread)
        {
            this.channelQueue.EnqueueAndDispatch(channel, dequeuedCallback, canDispatchOnThisThread);
        }

        public virtual void EnqueueAndDispatch(Exception exception, Action dequeuedCallback, bool canDispatchOnThisThread)
        {
            this.channelQueue.EnqueueAndDispatch(exception, dequeuedCallback, canDispatchOnThisThread);
        }

        public bool EnqueueWithoutDispatch(TChannel channel, Action dequeuedCallback)
        {
            return this.channelQueue.EnqueueWithoutDispatch(channel, dequeuedCallback);
        }

        public virtual bool EnqueueWithoutDispatch(Exception exception, Action dequeuedCallback)
        {
            return this.channelQueue.EnqueueWithoutDispatch(exception, dequeuedCallback);
        }

        public void FaultQueue()
        {
            base.Fault();
        }

        protected override void OnClosed()
        {
            base.OnClosed();
            this.channelQueue.Dispose();
        }

        protected override void OnFaulted()
        {
            this.channelQueue.Shutdown(() => base.ChannelManager.GetPendingException());
            base.OnFaulted();
        }

        public override bool WaitForChannel(TimeSpan timeout)
        {
            base.ThrowIfNotOpened();
            return this.channelQueue.WaitForItem(timeout);
        }

        public int PendingCount
        {
            get
            {
                return this.channelQueue.PendingCount;
            }
        }
    }
}

