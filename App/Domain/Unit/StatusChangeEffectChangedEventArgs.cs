using System;

namespace Srpg.App.Domain.Unit
{
    public class StatusChangeEffectChangedEventArgs : EventArgs
    {
        public StatusChangeEffectChangedEventArgs(string effectName, bool isRemoved)
        {
            this.EffectName = effectName;
            this.isRemoved = isRemoved;

        }
        public string EffectName { get; private set; }
        public bool isRemoved { get; private set; }


    }
}