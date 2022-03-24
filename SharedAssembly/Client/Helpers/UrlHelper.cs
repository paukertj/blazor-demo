namespace Client.Extensions
{
    internal static class UrlHelper
    {
        internal static string GetController<TContract>()
        {
            const string contract = "Contract";

            var typeName = typeof(TContract)?.Name;

            if (string.IsNullOrEmpty(typeName))
            {
                return string.Empty;
            }

            if (typeName.StartsWith('I'))
            {
                typeName = typeName.Substring(1);
            }

            if (typeName.EndsWith(contract))
            {
                typeName = typeName.Substring(0, typeName.Length - contract.Length);
            }

            return typeName;
        }
    }
}
