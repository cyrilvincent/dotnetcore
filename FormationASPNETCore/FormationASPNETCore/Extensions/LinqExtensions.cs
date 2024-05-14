namespace FormationASPNETCore.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<TResult> FullJoinDistinct<TLeft, TRight, TKey, TResult>(
                                    this IEnumerable<TLeft> leftItems,
                                    IEnumerable<TRight> rightItems,
                                    Func<TLeft, TKey> leftKeySelector,
                                    Func<TRight, TKey> rightKeySelector,
                                    Func<TLeft, TRight, TResult> resultSelector
                                )
        {

            IEnumerable<TResult> leftJoin =
                from left in leftItems
                join right in rightItems
                  on leftKeySelector(left) equals rightKeySelector(right) into temp
                from right in temp.DefaultIfEmpty()
                select resultSelector(left, right);

            IEnumerable<TResult> rightJoin =
                from right in rightItems
                join left in leftItems
                  on rightKeySelector(right) equals leftKeySelector(left) into temp
                from left in temp.DefaultIfEmpty()
                select resultSelector(left, right);

            return leftJoin.Union(rightJoin);
        }

        public static IQueryable<TResult> LeftJoin<TOuter, TInner, TKey, TResult>(
            this IQueryable<TOuter> outer,
            IQueryable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer
                // ReSharper disable once PossibleUnintendedQueryableAsEnumerable
                .GroupJoin(inner,
                    outerKeySelector,
                    innerKeySelector,
                    (outerObj, inners) => new { outerObj, inners = inners.DefaultIfEmpty() })
                .SelectMany(a => a.inners.Select(innerObj => resultSelector(a.outerObj, innerObj)))
                .AsQueryable();
        }
    }
}
