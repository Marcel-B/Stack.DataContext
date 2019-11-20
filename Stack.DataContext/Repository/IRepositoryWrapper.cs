namespace com.b_velop.stack.DataContext.Repository
{
    public interface IRepositoryWrapper
    {
        IMeasurePointRepository MeasurePoint { get; set; }
        IMeasureValueRepository MeasureValue { get; set; }
        ILocationRepository Location { get; set; }
        ILinkRepository Link { get; set; }
        IUnitRepository Unit { get; set; }
        IPriorityStateRepository PriorityState { get; set; }
        IActiveMeasurePointRepository ActiveMeasurePoint { get; set; }
        IBatteryStateRepository BatteryState { get; set; }
    }
}
