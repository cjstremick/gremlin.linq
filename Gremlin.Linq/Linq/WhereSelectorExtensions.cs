using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gremlin.Linq.Linq
{
    public static class WhereSelectorExtensions
    {
        public static UpdateCommand<TEntity> UpdateWith<TEntity>(this IWhereSelector<TEntity> selector, TEntity entity)
        {
            var command = new UpdateCommand<TEntity>(selector.Client, entity)
            {
                ParentSelector = selector
            };
            return command;
        }

        public static AddEdgeCommand AddOut<T>(this IWhereSelector selector, T entity, string relation)
        {
            var addCommand = new AddEdgeCommand(selector.Client, entity, relation)
            {
                ParentSelector = selector,
                InsertCommand = new InsertCommand(selector.Client, entity)
            };
            return addCommand;
        }

        public static ConnectedVertexSelector<T> SelectOut<T>(this IWhereSelector selector, string relation)
        {
            var edgeSelector = new ConnectedVertexSelector<T>(selector.Client, relation)
            {
                ParentSelector = selector
            };
            return edgeSelector;
        }

        public static WhereInSelector<T> WhereIn<T>(this IWhereSelector<T> selector, Expression<Func<T, object>> func,
            IEnumerable<object> values)
        {
            var whereSelector = new WhereInSelector<T>(selector.Client, func, values)
            {
                ParentSelector = selector
            };
            return whereSelector;
        }

        public static InEdgeSelector<T> InEdge<T>(this IWhereSelector selector) where T : Edge
        {
            var outSelector = new InEdgeSelector<T>(selector.Client)
            {
                ParentSelector = selector
            };
            return outSelector;
        }

        public static OutEdgeSelector<T> OutEdge<T>(this IWhereSelector selector) where T : Edge
        {
            var outSelector = new OutEdgeSelector<T>(selector.Client)
            {
                ParentSelector = selector
            };
            return outSelector;
        }

        //public static InSelector<T> In<T>(this IWhereSelector selector, string edgeLabel = null)
        //{
        //    var inSelector = new InSelector<T>(selector.Client, edgeLabel)
        //    {
        //        ParentSelector = selector
        //    };
        //    return inSelector;
        //}
    }
}