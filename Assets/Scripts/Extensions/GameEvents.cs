using System;

namespace PlateTD.Extensions
{
    public static class GameEvents
    {
        public static event Action OnStartWave;
        public static event Action<bool> OnEndWave;
        public static event Action<int> OnAddGold;

        public static void InvokeStartWave()
        {
            OnStartWave?.Invoke();
        }

        public static void InvokeEndWave(bool isLastWave)
        {
            OnEndWave?.Invoke(isLastWave);
        }

        public static void InvokeAddGold(int goldAmount)
        {
            OnAddGold?.Invoke(goldAmount);
        }

    }
}