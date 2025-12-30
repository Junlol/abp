using System;

namespace Volo.Abp.MultiCompanies;

[Flags]
public enum MultiCompanySides
{
    Host = 1,
    Company = 2,
    Both = Host | Company
}
