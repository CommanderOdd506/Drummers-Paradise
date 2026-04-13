public interface IPurchasable
{
    float GetCost();
    bool CanPurchase(out string error);
    void OnPurchase();
}
