using System.Collections.Generic;

namespace Sumsub.DataAccess.Models;

public class ReviewResult
{
    public long Id { get; set; }
    public string ModerationComment { get; set; }
    public string ClientComment { get; set; }
    public string ReviewAnswer { get; set; }
    public List<string> RejectLabels { get; set; }
    public string ReviewRejectType { get; set; } // todo could be an enum?
}