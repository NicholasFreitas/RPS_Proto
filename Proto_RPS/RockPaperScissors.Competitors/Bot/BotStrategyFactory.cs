using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS
{
    public class BotStrategyFactory
    {
        public static IBotStrategy GetBot(BotType botType) 
        {
            switch (botType)
            {
                case BotType.Random:
                    return RandomBotStrategy();
                case BotType.Strategic:
                    return StrategicBotStrategy();
                
                default:
                    return RandomBotStrategy();
            }
        }

        private static IBotStrategy RandomBotStrategy() 
        {
            return new RandomBotStrategy();
        }

        private static IBotStrategy StrategicBotStrategy() 
        {
            return new StrategicBotStrategy();
        }

    }
}
