using EvoSC.Modules.Official.MapListModule.Classes;

namespace EvoSC.Modules.Official.MapListModule.Interfaces;

public interface IMapListService
{
    List<QueuedMap> MapQueue { get; set; }

    /// <summary>
    /// Gets the next map that should be loaded.
    /// </summary>
    public QueuedMap? GetNextMap();
    
    /// <summary>
    /// Append the given index to the MapQueue.
    /// </summary>
    /// <param name="mapIndex">Index of the map.</param>
    public void AddMap(int mapIndex);

    /// <summary>
    /// Removed the given index from the MapQueue.
    /// </summary>
    /// <param name="mapIndex">Index of the map.</param>
    public void RemoveMapFromQueue(int mapIndex);

    /// <summary>
    /// Adds the given index to the start of the MapQueue.
    /// </summary>
    /// <param name="mapIndex">Index of the map.</param>
    public void PrependMap(int mapIndex);

    /// <summary>
    /// Inserts the given mapIndex to the MapQueue at the given index.
    /// </summary>
    /// <param name="index">Index of the position on the list</param>
    /// <param name="mapIndex">Index of the map.</param>
    public void InsertMap(int index, int mapIndex);
}
