using System;
using System.Collections.Generic;
using NaughtyAttributes;
using TheKiwiCoder;
using Random = UnityEngine.Random;

namespace Diwide.Ziggurat.BehaviourTree.Composites
{
    [Serializable]
    public class RandomStripSelector : RandomSelector
    {
        [ReorderableList]
        public List<float> probabilityMasses; // relative size significant (need not add up to 1 or 100)
    
        protected override void OnStart()
        {
            ValidateNode();
            current = ChooseChildIndex(probabilityMasses);
        }
    
        private int ChooseChildIndex(List<float> probs) {
            float total = 0;

            foreach (float elem in probs) {
                total += elem;
            }

            float randomPoint = Random.value * total;

            // Strict test is important to deny an item to be occasionally chosen
            // even when its probability is zero
            for (int i= 0; i < probs.Count; i++) 
            {
                if (randomPoint < probs[i]) {
                    return i;
                }

                randomPoint -= probs[i];
            }
            return probs.Count - 1; // necessary because Random.value can return a result of 1
        }

        private void ValidateNode()
        {
            if ( ! ValidateProbabilitiesCount(probabilityMasses))
                throw new ArgumentException("Number of probabilities and childrens of this Node must be the same");
        }

        private bool ValidateProbabilitiesCount(List<float> probs)
        {
            return probs.Count == children.Count;
        }
    }
}
