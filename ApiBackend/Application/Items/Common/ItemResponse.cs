namespace Application.Items.Common
{
    public record ItemResponse
    (
        Guid Id,
        string ItemDescription,
        bool ItemState
    );
}
