using System;
using Infrastructure.GroupData;

namespace Infrastructure.SaveLoadLogic.Base
{
    [Serializable]
    public class Progress
    {
        public DataWallet DataWallet;
        public CharacterAttributes _characterAttributes;

        public Progress()
        {
            DataWallet = new DataWallet();
            _characterAttributes = new CharacterAttributes();
        }
    }
}