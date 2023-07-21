namespace EvoSC.Modules.Official.MapListModule.Classes;

public class QueuedMap : IComparable<QueuedMap>
{
    public int Order { get; set; }
    public int Index { get; }
    
    public QueuedMap(int index, int order)
    {
        Order = order;
        Index = index;
    }

    public int CompareTo(QueuedMap? other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        return ReferenceEquals(null, other) ? 1 : Order.CompareTo(other.Order);
    }
}
