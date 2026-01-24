using System.Text;
using CarLibrary.Models.DTO;

namespace CarGate.Tools.QueryBuilders;

public static class VehiclesQueryBuilder
{
    public static string Build(VehicleFiltersDTO f)
    {
        var sb = new StringBuilder();

        sb.Append($"wojewodztwo={f.Voivodeship}&");
        sb.Append($"data-od={f.FromDate:yyyyMMdd}&");

        if (f.ToDate.HasValue)
            sb.Append($"data-do={f.ToDate.Value:yyyyMMdd}&");

        if (f.OnlyRegistered.HasValue)
            sb.Append($"tylko-zarejestrowane={f.OnlyRegistered.Value.ToString().ToLower()}&");

        if (f.Limit.HasValue)
            sb.Append($"page[size]={f.Limit.Value}&");

        sb.Append("page[number]=1");

        return sb.ToString();
    }
}
