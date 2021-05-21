using Proto_RPS.RPSGame.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proto_RPS.RPSGame.Competitors.Bot
{
    public class BotStrategyFactory
    {
        public static IBotStrategy GetBot(BotType botType)
        {
            return botType switch
            {
                BotType.Random => RandomBotStrategy(),
                BotType.Strategic => StrategicBotStrategy(),
                _ => RandomBotStrategy(),
            };
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
