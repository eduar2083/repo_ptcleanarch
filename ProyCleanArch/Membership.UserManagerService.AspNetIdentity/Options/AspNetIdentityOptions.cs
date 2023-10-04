namespace Membership.UserManagerService.AspNetIdentity.Options;

public class AspNetIdentityOptions
{
    public const string SectionKey = "ConnectionStrings";
    public string MembershipDb { get; set; }
}
