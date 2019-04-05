namespace Gremlin.Linq.Linq
{
    public static class EdgeSelectorExtensions
    {
        public static OutVertexSelector<TVertex> OutVertex<TVertex>(this EdgeSelector edgeSelector)
        {
            return new OutVertexSelector<TVertex>(edgeSelector.Client)
            {
                ParentSelector = edgeSelector
            };
        }

        public static InVertexSelector<TVertex> InVertex<TVertex>(this EdgeSelector edgeSelector)
        {
            return new InVertexSelector<TVertex>(edgeSelector.Client)
            {
                ParentSelector = edgeSelector
            };
        }
    }
}