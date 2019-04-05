using System.Threading.Tasks;

namespace Gremlin.Linq.Linq
{
    public static class CommandExtensions
    {
        public static AddEdgeCommand<TEdgeEntity> AddOut<TFromEntity, TEdgeEntity>(this Command<TFromEntity> command,
            TEdgeEntity entity, string relation)
        {
            var addCommand = new AddEdgeCommand<TEdgeEntity>(command.Client, entity, relation)
            {
                ParentCommand = command,
                InsertCommand = new InsertCommand(command.Client, entity)
            };
            return addCommand;
        }

        public static async Task<QueryResult<TEntity>> SubmitAsync<TEntity>(this Command<TEntity> command)
            where TEntity : new()
        {
            var query = command.BuildGremlinQuery();
            var queryResult = await command.Client.SubmitWithSingleResultAsync<TEntity>(query);
            return queryResult;
        }

        public static async Task SubmitAsync(this Command command)
        {
            var query = command.BuildGremlinQuery();
            await command.Client.SubmitAsync(query);
        }
    }
}