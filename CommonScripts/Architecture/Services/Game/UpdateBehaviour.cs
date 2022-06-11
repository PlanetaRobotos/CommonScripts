using System.Collections.Generic;
using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class UpdateBehaviour : MonoBehaviour
    {
        private Queue<ITick> _ticks;
        private Queue<IFixedTick> _fixedTicks;
        
        private void Update()
        {
            foreach (ITick tick in _ticks) 
                tick.Tick();
        }

        private void FixedUpdate()
        {
            foreach (IFixedTick tick in _fixedTicks) 
                tick.FixedTick();
        }
    }

    public interface ITick
    {
        void Tick();
    }
    
    public interface IFixedTick
    {
        void FixedTick();
    }
}