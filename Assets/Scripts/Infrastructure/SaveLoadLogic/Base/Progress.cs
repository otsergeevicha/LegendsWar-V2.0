using System;

namespace Infrastructure.SaveLoadLogic.Base
{
    [Serializable]
    public class Progress
    {
        public DataWallet DataWallet;

        public Progress() => 
            DataWallet = new DataWallet();
    }
}