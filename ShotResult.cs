internal struct ShotResult
{
    public ShipType? ShipType { get; init; }
    public bool ShipSunk { get; init; }
    public bool IsHit => ShipType.HasValue;
}