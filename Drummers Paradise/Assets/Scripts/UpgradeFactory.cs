public static class UpgradeFactory
{
    public static Upgrade Create(UpgradeData data)
    {
        Upgrade upgrade = new Upgrade();

        upgrade.name = data.name;
        upgrade.cost = data.cost;
        upgrade.costIncrease = data.costIncrease;
        upgrade.tier = data.tier;

        upgrade.upgradeMultiplier = new UpgradeMultiplier
        {
            multiplier = data.multiplier,
            type = (data.resourceType == "Money")
                ? ResourceType.Money
                : ResourceType.Followers
        };

        upgrade.currentState = UpgradeState.Available;

        return upgrade;
    }
}
