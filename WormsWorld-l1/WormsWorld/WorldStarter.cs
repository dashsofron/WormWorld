using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace WormsWorld
{
    public class WorldStarter : IHostedService
    {
        private ActionPerformer actionPerformer;
        private FoodGenerator foodGenerator;
        private NameGenerator nameGenerator;
        private WorldStateWriter stateWriter;

        public WorldStarter(ActionPerformer actionPerformer, FoodGenerator foodGenerator, NameGenerator nameGenerator,
            WorldStateWriter stateWriter)
        {
            this.actionPerformer = actionPerformer;
            this.foodGenerator = foodGenerator;
            this.nameGenerator = nameGenerator;
            this.stateWriter = stateWriter;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Simulator simulator = new Simulator(actionPerformer, foodGenerator, nameGenerator, stateWriter);

            simulator.DoWork();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}